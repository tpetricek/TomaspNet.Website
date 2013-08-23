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

/// Concantenate path using the right separator
let (++) p1 p2 = Path.Combine(p1, p2)

/// Delete directory if it exists
let SafeDeleteDir directory recurse = 
  if Directory.Exists(directory) then Directory.Delete(directory, recurse)

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

// --------------------------------------------------------------------------------------
// Razor
// --------------------------------------------------------------------------------------

open RazorEngine
open RazorEngine.Text
open RazorEngine.Templating
open RazorEngine.Configuration

let root_ = @"C:\Tomas\Projects\WebSites\TomaspNet.New"
 
type TemplateResolver () =
    interface ITemplateResolver with
        member x.Resolve name =
            printfn "  Resolving: %s" name
            //if File.Exists(name) then File.ReadAllText(name)
            //elif File.Exists(name + ".cshtml") then File.ReadAllText(name + ".cshtml")
            if File.Exists(root_ + "\\layouts\\" + name + ".cshtml") then 
              File.ReadAllText(root_ + "\\layouts\\" + name + ".cshtml")
            else failwithf "Could not find template file %s" name   

type RazorHandler (model) =
    do
        let config = new TemplateServiceConfiguration()
        config.Namespaces.Add("TildeLib") |> ignore
        config.EncodedStringFactory <- new RawStringFactory()
        config.Resolver <- new TemplateResolver()
        
        config.BaseTemplateType <- typedefof<TildeLib.TemplateBaseExtensions<_>>
        config.Debug <- true
        
        let templateservice = new TemplateService(config)
        Razor.SetTemplateService(templateservice)
    
    member x.LoadMarkdownFragment fragment = 
        x.viewBag <- new DynamicViewBag()
        
        let markdownGuid = (new System.Guid()).ToString()
        try
            Razor.Compile(fragment, markdownGuid)
            let tmpl = Razor.Resolve(markdownGuid, model)
            let result = tmpl.Run(new ExecuteContext(x.viewBag))
            let utmpl = (tmpl :?> TildeLib.TemplateBaseExtensions<_>)
            let z = (utmpl :> RazorEngine.Templating.ITemplate)
            (utmpl, result)
        with
            | :? TemplateCompilationException as ex -> 
                printfn "-- Source Code --"
                ex.SourceCode.Split('\n')
                |> Array.iteri(printfn "%i: %s")
                ex.Errors |> Seq.iter(fun w -> printfn "%i(%i): %s" w.Line w.Column w.ErrorText)
                failwithf "Exception compiling markdown fragment: %A" ex.Message
               
    member x.LoadFile filename = 
        x.viewBag <- new DynamicViewBag()
        Razor.Parse(File.ReadAllText(filename), model, x.viewBag, null)
    
    member val viewBag = new DynamicViewBag() with get,set


let razor = new RazorHandler(0)

module Razor = 
  let transform source output = 
    try 
      printfn "Transforming: %s" source
      File.WriteAllText(output, razor.LoadFile(source))
      printfn "Finished transforming: %s" source
    with :? TemplateCompilationException as e ->
      let csharp = Path.GetTempFileName() + ".cs"
      File.WriteAllText(csharp, e.SourceCode)
      printfn "Processing the file '%s' failed with exception:\n%O\nSource written to: '%s'." source e csharp

// --------------------------------------------------------------------------------------
//
// --------------------------------------------------------------------------------------

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
      let output = Path.ChangeExtension(output ++ file.Remove(0, source.Length + 1), ".html")
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

// --------------------------------------------------------------------------------------

// Root URL for the generated HTML
let output = __SOURCE_DIRECTORY__ ++ "../output"
let root = "file:///C:\Tomas\Projects\WebSites\TomaspNet.New\output" // TODO: Move under Blue Mountain!
let source = __SOURCE_DIRECTORY__ ++ "../source"

let layouts = __SOURCE_DIRECTORY__ ++ "../layouts"
let content = __SOURCE_DIRECTORY__ ++ "../content"

let references = []

// Global dependencies - if any of these files change, then we must regenerate all
let dependencies = 
  [ yield! Directory.GetFiles(layouts) ] 

let filesToProcess = 
  GetSourceFiles source output
  |> FilterChangedFiles dependencies 

for source, target in filesToProcess do
  match Path.GetExtension(source).ToLower() with
  | ".html" | ".cshtml" ->
    Razor.transform source target
  | _ -> ()

|> Seq.iter (fun (inp, out) -> 
    EnsureDirectory (Path.GetDirectoryName(out))
    File.WriteAllText(out, "hi") )

CopyFiles content output 

let changedFiles = seq { 
  let newest = dependencies |> List.map Directory.GetLastWriteTime |> List.max
  for file 

GetFiles source

// Generate HTML from all FSX files in samples & subdirectories
let build() = 
  Literate.ProcessDirectory
    ( sources, template, output, 
      replacements = [ "root", root ],
      compilerOptions = String.concat " " (List.map (sprintf "-r:\"%s\"") references) )

build()