namespace TildeLib

open System.IO
open RazorEngine
open RazorEngine.Text
open RazorEngine.Templating
open RazorEngine.Configuration

type Razor(layoutsRoot) =
    do
        let config = new TemplateServiceConfiguration()
        config.Namespaces.Add("TildeLib") |> ignore
        config.EncodedStringFactory <- new RawStringFactory()
        config.Resolver <- 
          { new ITemplateResolver with
              member x.Resolve name =
                let layoutFile = Path.Combine(layoutsRoot, name + ".cshtml")
                if File.Exists(layoutFile) then File.ReadAllText(layoutFile)
                else failwithf "Could not find template file: %s\nSearching in: %s" name layoutsRoot }
        config.BaseTemplateType <- typedefof<TildeLib.TemplateBaseExtensions<_>>
        config.Debug <- true        
        let templateservice = new TemplateService(config)
        Razor.SetTemplateService(templateservice)
(*    
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
*)               
    member val Model = obj() with get, set
    member val ViewBag = new DynamicViewBag() with get,set

    member x.ProcessFile(source) = 
      try
        x.ViewBag <- new DynamicViewBag()
        let html = Razor.Parse(File.ReadAllText(source), x.Model, x.ViewBag, null)
        html
      with :? TemplateCompilationException as ex -> 
        let csharp = Path.GetTempFileName() + ".cs"
        File.WriteAllText(csharp, ex.SourceCode)
        failwithf "Processing the file '%s' failed with exception:\n%O\nSource written to: '%s'." source ex csharp
