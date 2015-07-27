// --------------------------------------------------------------------------------------
// FAKE build script - push to github
// --------------------------------------------------------------------------------------

#r @"packages/FAKE/tools/FakeLib.dll"
#load "tools/generate.fsx"
open System
open System.IO
open Fake
open Fake.Git

let gitLocation = "https://github.com/tpetricek/TomaspNet.Website.git"

Target "Run" (fun _ ->
  let sources =
    { BaseDirectory = __SOURCE_DIRECTORY__
      Includes = [ "**/*.*" ]
      Excludes = [] }
  use watcher = sources |> WatchChanges (fun _ ->
    printfn "Updating site..."
    Generate.buildSite(false)
  )
  Generate.run()
  System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite)
)

Target "Generate" (fun _ ->
    Generate.buildSite(true)
)

Target "Publish" (fun _ ->
    let ghPagesLocal = __SOURCE_DIRECTORY__ @@ "../output"
    CommandHelper.runSimpleGitCommand ghPagesLocal "add ." |> printfn "%s"
    let cmd = sprintf """commit -a -m "Update generated web site (%s)""" (DateTime.Now.ToString("dd MMMM yyyy"))
    CommandHelper.runSimpleGitCommand ghPagesLocal cmd |> printfn "%s"
    Branches.push ghPagesLocal
)

// --------------------------------------------------------------------------------------
// Targets for running build script in background (for Atom)
// --------------------------------------------------------------------------------------

open System.Diagnostics

let runningFileLog = __SOURCE_DIRECTORY__ @@ "build.log"
let runningFile = __SOURCE_DIRECTORY__ @@ "build.running"

Target "Spawn" (fun _ ->
  if File.Exists(runningFile) then
    failwith "The build is already running!"

  let ps =
    ProcessStartInfo
      ( WorkingDirectory = __SOURCE_DIRECTORY__,
        FileName = __SOURCE_DIRECTORY__  @@ "packages/FAKE/tools/FAKE.exe",
        Arguments = "run --fsiargs build.fsx",
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false )
  use fs = new FileStream(runningFileLog, FileMode.Create, FileAccess.ReadWrite, FileShare.Read)
  use sw = new StreamWriter(fs)
  let p = Process.Start(ps)
  p.ErrorDataReceived.Add(fun data -> printfn "%s" data.Data; sw.WriteLine(data.Data); sw.Flush())
  p.OutputDataReceived.Add(fun data -> printfn "%s" data.Data; sw.WriteLine(data.Data); sw.Flush())
  p.EnableRaisingEvents <- true
  p.BeginOutputReadLine()
  p.BeginErrorReadLine()

  File.WriteAllText(runningFile, string p.Id)
  while File.Exists(runningFile) do
    System.Threading.Thread.Sleep(500)
  p.Kill()
)

Target "Attach" (fun _ ->
  if not (File.Exists(runningFile)) then
    failwith "The build is not running!"
  use fs = new FileStream(runningFileLog, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
  use sr = new StreamReader(fs)
  while File.Exists(runningFile) do
    let msg = sr.ReadLine()
    if not (String.IsNullOrEmpty(msg)) then
      printfn "%s" msg
    else System.Threading.Thread.Sleep(500)
)

Target "Stop" (fun _ ->
  if not (File.Exists(runningFile)) then
    failwith "The build is not running!"
  File.Delete(runningFile)
)


RunTargetOrDefault "Run"
