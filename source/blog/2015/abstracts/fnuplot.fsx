(**
<img src="http://fsprojects.github.io/FnuPlot/img/logo.png" style="width:120px;float:right;margin:10px" />

There is a bunch of visualization and charting libraries for F#. Sadly, perhaps the most
advanced one, [F# Charting](http://fsharp.github.io/FSharp.Charting/), does not work 
particularly well outside of Windows at the moment. There are also some work-in-progress
libraries based on HTML like [Foogle Charts](http://fsprojects.github.io/Foogle.Charts/) and
[FsPlot](http://tahahachana.github.io/FsPlot/), which are cross-platform, but not quite
ready yet. 

Before Christmas, I got a [notification from GitHub](https://github.com/fsprojects/FnuPlot/pull/2)
about a pull request for a simple gnuplot wrapper that I wrote a long time ago (and which used
to be carefully hidden [on CodePlex](http://fsxplat.codeplex.com)).

The library is incomplete and I don't expect to dedicate too much time to maintaining it,
but it works quite nicely for basic charts and so I though I'd add the 
[ProjectScaffold](http://fsprojects.github.io/ProjectScaffold/) structure, do a few tweaks
and make it available as a modern F# project.

*)