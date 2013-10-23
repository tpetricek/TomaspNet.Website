// --------------------------------------------------------------------------------------
// FAKE build script - push to github
// --------------------------------------------------------------------------------------

#r @"packages/FAKE/tools/FakeLib.dll"
open System
open Fake 
open Fake.Git

let gitLocation = "https://github.com/tpetricek/TomaspNet.Website.git"

Target "Publish" (fun _ ->
    let ghPagesLocal = __SOURCE_DIRECTORY__ @@ "../output"
    CommandHelper.runSimpleGitCommand ghPagesLocal "add ." |> printfn "%s"
    let cmd = sprintf """commit -a -m "Update generated web site (%s)""" (DateTime.Now.ToString("dd MMMM yyyy"))
    CommandHelper.runSimpleGitCommand ghPagesLocal cmd |> printfn "%s"
    Branches.push ghPagesLocal
)

RunTargetOrDefault "Publish"