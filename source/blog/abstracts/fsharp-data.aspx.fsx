(**

<img src="https://raw.github.com/fsharp/FSharp.Data/master/misc/logo.png" class="rdecor" style="width:120px;height:120px;" />

When F# 3.0 type providers were still in beta version, I wrote a couple of type 
providers as examples for talks. These included the WorldBank type provider
(now available [on Try F#](http://www.tryfsharp.org)) and also type provider for
XML that infered the structure from sample.   
For some time, these were hosted as part of [FSharpX](https://github.com/fsharp/fsharpx/) 
and the authors of FSharpX also added a number of great features.

When I found some more time earlier this year, I decided to start a new library
that would be fully focused on data access in F# and on type providers and
I started working on **F# Data**. The library has now reached a stable state
and [Steffen also announced](http://www.navision-blog.de/blog/2013/03/27/fsharpx-1-8-removes-support-for-document-type-provider/) 
that the document type providers (JSON, XML and CSV) are not going to be available
in FSharpX since the next version. 

This means that if you're interested in accessing data using F# type providers, 
you should now go to F# Data. Here are the most important links:

 * [F# Data source code on GitHub](https://github.com/fsharp/FSharp.Data)
 * [F# Data documentation & tutorials](http://fsharp.github.com/FSharp.Data/)
 * [F# Data on NuGet](http://nuget.org/packages/FSharp.Data)

Before looking at the details, I would like to thank to [Gustavo Guerra](https://github.com/ovatsus)
who made some amazing contributions to the library! (More contributors are always welcome,
so continue reading if you're interested...)

*)