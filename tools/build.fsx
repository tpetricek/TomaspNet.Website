#I "FsBlogLib/bin/Debug"
#r "FsBlogLib.dll"
#r "RazorEngine.dll"
open System
open System.IO
open FsBlogLib.FileHelpers
open FsBlogLib.BlogPosts
open FsBlogLib.Blog
open FsBlogLib.Calendar
open FSharp.Http

// --------------------------------------------------------------------------------------
// Configuration
// --------------------------------------------------------------------------------------

// Root URL for the generated HTML & other basic information
let root = "http://tomasp.net" 
let title = "Tomas Petricek's blog"
let description = 
   "Writing about software development in F# and .NET, sharing materials from " +
   "my F# trainings and talks, writing about programming language research and theory."

// Information about source directory, blog subdirectory, layouts & content
let source = __SOURCE_DIRECTORY__ ++ "../source"
let blog = __SOURCE_DIRECTORY__ ++ "../source/blog"
let blogIndex = __SOURCE_DIRECTORY__ ++ "../source/blog/index.cshtml"
let layouts = __SOURCE_DIRECTORY__ ++ "../layouts"
let content = __SOURCE_DIRECTORY__ ++ "../content"
let template = __SOURCE_DIRECTORY__ ++ "empty-template.html"
let calendar = __SOURCE_DIRECTORY__ ++ "../calendar"
let calendarMonth = __SOURCE_DIRECTORY__ ++ "../source/calendar/month.cshtml"
let calendarIndex = __SOURCE_DIRECTORY__ ++ "../source/calendar/index.cshtml"

// F# code generation - skip 'exclude' directory & add 'references'
let exclude = 
  [ yield __SOURCE_DIRECTORY__ ++ "../source/blog/packages"
    yield __SOURCE_DIRECTORY__ ++ "../source/blog/abstracts"
    yield __SOURCE_DIRECTORY__ ++ "../source/calendar"
    for y in 2013 .. 2025 do
      yield __SOURCE_DIRECTORY__ ++ "../source/blog" ++ (string y) ++ "abstracts"  ]

let references = []

let special =
  [ source ++ "index.cshtml"
    source ++ "blog" ++ "index.cshtml" ]

// Output directory (gh-pages branch)
let output = __SOURCE_DIRECTORY__ ++ "../../output"

// Dependencies - if any of these files change, then we must regenerate all
let dependencies =
  [ yield! Directory.GetFiles(layouts) 
    yield calendarMonth 
    yield calendarIndex ]

// --------------------------------------------------------------------------------------
// Clean, build 
// --------------------------------------------------------------------------------------

let tagRenames = 
  [ ("F# language", "f#"); ("Functional Programming in .NET", "functional");
    ("Materials & Links", "links"); ("C# language", "c#"); (".NET General", ".net") ] |> dict

let clean() = 
  for dir in Directory.GetDirectories(output) do
    if not (dir.EndsWith(".git")) then SafeDeleteDir dir true
  for file in Directory.GetFiles(output) do
    File.Delete(file)

let build (updateTagArchive) =
  let noModel = { Model.Root = root; MonthlyPosts = [||]; Posts = [||]; TaglyPosts = [||]; GenerateAll = true }
  let razor = FsBlogLib.Razor(layouts, Model = noModel)
  let model = LoadModel(tagRenames, TransformAsTemp (template, source) razor, root, blog)

  // Generate RSS feed
  GenerateRss root title description model (output ++ "rss.xml")
  GenerateCalendar root layouts output dependencies calendar calendarMonth calendarIndex model

  let uk = System.Globalization.CultureInfo.GetCultureInfo("en-GB")
  GeneratePostListing 
    layouts template blogIndex model model.MonthlyPosts 
    (fun (y, m, _) -> output ++ "blog" ++ "archive" ++ (m.ToLower() + "-" + (string y)) ++ "index.html")
    (fun (y, m, _) -> y = DateTime.Now.Year && m = uk.DateTimeFormat.GetMonthName(DateTime.Now.Month))
    (fun (y, m, _) -> sprintf "%d %s" y m)
    (fun (_, _, p) -> p)

  if updateTagArchive then
    GeneratePostListing 
      layouts template blogIndex model model.TaglyPosts
      (fun (_, u, _) -> output ++ "blog" ++ "tag" ++ u ++ "index.html")
      (fun (_, _, _) -> true)
      (fun (t, _, _) -> t)
      (fun (_, _, p) -> p)

  let filesToProcess = 
    GetSourceFiles source output
    |> SkipExcludedFiles exclude
    |> TransformOutputFiles output
    |> FilterChangedFiles dependencies special
    
  let razor = FsBlogLib.Razor(layouts, Model = model)
  for current, target in filesToProcess do
    EnsureDirectory(Path.GetDirectoryName(target))
    printfn "Processing file: %s" (current.Substring(source.Length + 1))
    TransformFile template true razor None current target

  CopyFiles content output 
  CopyFiles calendar (output ++ "calendar")

// --------------------------------------------------------------------------------------
// Test using local HTTP server
// --------------------------------------------------------------------------------------

let server : ref<option<HttpServer>> = ref None
let stop () =
  server.Value |> Option.iter (fun v -> v.Stop())
let run() =
  let url = "http://localhost:8080/" 
  stop ()
  server := Some(HttpServer.Start(url, output, Replacements = ["http://tomasp.net/", url]))
  printfn "Starting web server at %s" url
  System.Diagnostics.Process.Start(url) |> ignore

// --------------------------------------------------------------------------------------
// Commands
// --------------------------------------------------------------------------------------

run ()
stop ()

build (true) // true - update tag archives
build (false)

clean()

