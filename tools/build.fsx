#I "lib"
#load "lib/literate.fsx"
#r "lib/System.Web.Razor.dll"
#r "lib/RazorEngine.dll"
#r "tilde/bin/Debug/TildeLib.dll"
open System.IO
open FSharp.Literate

// --------------------------------------------------------------------------------------
// Various file & directory helpers
// --------------------------------------------------------------------------------------
module FileHelpers =

  /// Concantenate path using the right separator
  let (++) p1 p2 = Path.Combine(p1, p2)

  /// Delete directory if it exists
  let SafeDeleteDir (directory:string) recurse =     
    if Directory.Exists(directory) then 
      Directory.Delete(directory, recurse)
    

  /// Ensure that a given directory exists
  let rec EnsureDirectory directory = 
    if Directory.Exists(directory) |> not then 
      EnsureDirectory (Path.GetDirectoryName(directory))
      Directory.CreateDirectory(directory) |> ignore

  /// Copy files recursively and ensure all directories are created
  /// (overwrites older files)
  let rec CopyFiles source target = 
    EnsureDirectory target
    for dir in Directory.GetDirectories(source) do
      CopyFiles dir (target ++ Path.GetFileName(dir))
    for file in Directory.GetFiles(source) do
      let fullTarget = target ++ Path.GetFileName(file)
      if not (File.Exists(fullTarget)) || 
         File.GetLastWriteTime(file) > File.GetLastWriteTime(fullTarget) then
        File.Copy(file, fullTarget, true)

  /// Returns a file name in the TEMP folder and deletes it when disposed
  type DisposableFile(file, deletes) =
    static member Create(file) =
      new DisposableFile(file, [file])
    static member CreateTemp(?extension) = 
      let temp = Path.GetTempFileName()
      let file = match extension with Some ext -> temp + ext | _ -> temp
      new DisposableFile(file, [temp; file])
    member x.FileName = file
    interface System.IDisposable with
      member x.Dispose() = 
        for delete in deletes do
          if File.Exists(delete) then File.Delete(delete)


  /// Get all *.cshtml, *.html, *.md and *.fsx files in the source directory
  /// and return tuple containing the source file and required target file
  let GetSourceFiles source output = seq {
    let exts = set [ ".md"; ".fsx"; ".cshtml"; ".html" ]
    let rec getFiles source = seq {
      yield! Directory.GetFiles(source)
      for dir in Directory.GetDirectories(source) do
        yield! getFiles dir }
    for file in getFiles source do
      if exts |> Set.contains (Path.GetExtension(file).ToLower()) then
        let relativeFile = file.Remove(0, source.Length + 1)
        let relativeFolder = 
          let idx = relativeFile.LastIndexOf('.') 
          relativeFile.Substring(0, idx)
        let output = output ++ relativeFolder
        yield file, output }


  /// Given a sequence of source - output files, return only those where the
  /// source has changed since the output was generated. If any of the dependencies
  /// is newer than the output, then a file is also returned.
  let FilterChangedFiles dependencies files = seq {
    let newestDependency = dependencies |> List.map Directory.GetLastWriteTime |> List.max
    for source, output in files do 
      let outputWrite = Directory.GetLastWriteTime(output)
      if outputWrite < Directory.GetLastWriteTime(source) ||
         outputWrite < newestDependency then
        yield source, output }


  /// Skip all files whose name starts with any string in the exclusion list
  let SkipExcludedFiles exclusions (files:seq<string * string>) = seq {
    for file, output in files do
      let fileNorm = System.Uri(file).LocalPath.ToLower()
      let excl = exclusions |> Seq.exists (fun (excl:string) -> 
        let excl = System.Uri(excl).LocalPath.ToLower()
        fileNorm.StartsWith(excl))
      if not excl then yield file, output }

  /// If the output file is in some subdirectory, then generate /blog/foo.index.html
  /// For files in the root, generate just /index.html (etc.)
  let TransformOutputFiles (output:string) files = seq {
    for file, (target:string) in files ->
      let relativeOut = target.Substring(output.Length + 1)
      if relativeOut.Contains("\\") || relativeOut.Contains("/") 
      then file, output ++ relativeOut ++ "index.html"
      else file, output ++ (relativeOut + ".html") }
      
      
// --------------------------------------------------------------------------------------
// Parsing blog posts etc.
// --------------------------------------------------------------------------------------
module Blog = 
  open System.Text.RegularExpressions

  /// Type that stores information about blog posts
  type BlogHeader = 
    { Title : string
      Description : string
      Date : System.DateTime
      Url : string
      Tags : seq<string> }

  /// Get all *.cshtml, *.html, *.md and *.fsx files in the blog directory
  let GetBlogFiles blog = seq {
    let exts = set [ ".md"; ".fsx"; ".cshtml"; ".html" ]
    for file in Directory.GetFiles(blog) do
      if exts |> Set.contains (Path.GetExtension(file).ToLower()) then
        yield file }
  
  let scriptHeaderRegex = 
    Regex("^\(\*\@(?<header>[^\*]*)\*\)(?<content>.*)$", RegexOptions.Singleline)
  let razorHeaderRegex = 
    Regex("^\@{(?<header>[^\*]*)}(?<content>.*)$", RegexOptions.Singleline)

  /// An FSX file must start with a header (*@ ... *) which is removed 
  /// before Literate processing (and then added back as @{ ... }
  let RemoveScriptHeader file = 
    let content = File.ReadAllText(file)
    let reg = scriptHeaderRegex.Match(content)
    if not reg.Success then 
      failwithf "The following F# script file is missing a header:\n%s" file  
    let header = reg.Groups.["header"].Value
    let body = reg.Groups.["content"].Value
    "@{" + header + "}\n", body

  /// Return the header block of any blog post file
  let GetBlogHeader file =
    let regex =
      match Path.GetExtension(file).ToLower() with
      | ".fsx" -> scriptHeaderRegex
      | ".html" | ".cshtml" -> razorHeaderRegex
      | _ -> failwith "File format not supported!"
    let reg = regex.Match(File.ReadAllText(file))
    if not reg.Success then 
      failwithf "The following source file is missing a header:\n%s" file  
    file, reg.Groups.["header"].Value

  /// Simple function that parses the header of the blog post. Everybody knows
  /// that doing this with regexes is silly, but the blog post headers are simple enough.
  let ParseBlogHeader (blog:string) =
    let concatRegex = Regex("\"[\s]*\+[\s]*\"", RegexOptions.Compiled)
    fun (file:string, header:string) ->
      let lookup =
        header.Split(';')
        |> Array.filter (System.String.IsNullOrWhiteSpace >> not)
        |> Array.map (fun (s:string) -> 
            match s.Trim().Split('=') |> List.ofSeq with
            | key::values -> 
                let value = String.concat "=" values
                key.Trim(), concatRegex.Replace(value.Trim(' ', '\t', '\n', '\r', '"'), "")
            | _ -> failwithf "Invalid header in the following blog file: %s" file ) |> dict
      let relativeFile = file.Substring(blog.Length + 1)
      let relativeFile = let idx = relativeFile.LastIndexOf('.') in relativeFile.Substring(0, idx)
      try
        { Title = lookup.["Title"]
          Url = relativeFile
          Description = lookup.["Description"]
          Tags = lookup.["Tags"].Split([|','|], System.StringSplitOptions.RemoveEmptyEntries) |> Array.map (fun s -> s.Trim())
          Date = lookup.["Date"] |> System.DateTime.Parse }
      with _ -> failwithf "Invalid header in the following blog file: %s" file

  /// Loads information about all blog posts
  let LoadBlogPosts blog =
    GetBlogFiles blog 
    |> Seq.map (GetBlogHeader >> (ParseBlogHeader blog))
    |> Seq.sortBy (fun b -> b.Date)
    |> Array.ofSeq 

// --------------------------------------------------------------------------------------
// Configuration
// --------------------------------------------------------------------------------------
open Blog

/// Represents the model that is passed to all pages
type Model = 
  { Posts : BlogHeader[] 
    Root : string }

let LoadModel(root, blog) = 
  { Posts = LoadBlogPosts(blog)
    Root = root }



open FileHelpers
open Blog

// Root URL for the generated HTML
let root = "http://test.tomasp.net" 
//let root = @"file:///C:\Tomas\Projects\WebSites\TomaspNet.New\output"

// Information about source directory, blog subdirectory, layouts & content
let source = __SOURCE_DIRECTORY__ ++ "../source"
let blog = __SOURCE_DIRECTORY__ ++ "../source/blog"
let layouts = __SOURCE_DIRECTORY__ ++ "../layouts"
let content = __SOURCE_DIRECTORY__ ++ "../content"
let template = __SOURCE_DIRECTORY__ ++ "empty-template.html"

// F# code generation - skip 'exclude' directory & add 'references'
let exclude = [ __SOURCE_DIRECTORY__ ++ "../source/blog/packages" ]
let references = []

// Output directory (gh-pages branch)
let output = __SOURCE_DIRECTORY__ ++ "../../output"

// Dependencies - if any of these files change, then we must regenerate all
let dependencies = 
  [ yield! Directory.GetFiles(layouts) ]
   @ [ __SOURCE_DIRECTORY__ ++ __SOURCE_FILE__ ]


let clean() = 
  for dir in Directory.GetDirectories(output) do
    if not (dir.EndsWith(".git")) then SafeDeleteDir dir true
  for file in Directory.GetFiles(output) do
    File.Delete(file)

let build () =
  let model = LoadModel(root, blog)
  let razor = TildeLib.Razor(layouts, Model = model)

  let filesToProcess = 
    GetSourceFiles source output
    |> SkipExcludedFiles exclude
    |> TransformOutputFiles output
    |> FilterChangedFiles dependencies 
    
  for current, target in filesToProcess do
    EnsureDirectory(Path.GetDirectoryName(target))
    printfn "Processing file: %s" (current.Substring(source.Length + 1))
    match Path.GetExtension(current).ToLower() with
    | ".fsx" ->
        let header, content = RemoveScriptHeader(current)
        use fsx = DisposableFile.Create(current.Replace(".fsx", "_.fsx"))
        use html = DisposableFile.CreateTemp(".html")
        File.WriteAllText(fsx.FileName, content)
        Literate.ProcessScriptFile(fsx.FileName, template, html.FileName)
        let processed = File.ReadAllText(html.FileName)
        File.WriteAllText(html.FileName, header + processed)
        EnsureDirectory(Path.GetDirectoryName(target))
        razor.ProcessFile(html.FileName, target)
    | ".html" | ".cshtml" ->
        razor.ProcessFile(current, target)
    | _ -> failwith "Not supported file!"

  CopyFiles content output 

build()
clean()