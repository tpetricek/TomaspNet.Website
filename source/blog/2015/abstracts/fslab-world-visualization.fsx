(**

In case you missed my recent [official FsLab announcement](http://tomasp.net/blog/2015/announcing-fslab/), 
FsLab is a data-science package for .NET built around F# that makes it easy to get data using _type providers_, 
analyze them interactively (with great R integration) and visualize the results. You can find more on
on [fslab.org](http://fslab.org), which also has links to [some](http://channel9.msdn.com/posts/Understanding-the-World-with-F)
[videos](https://channel9.msdn.com/Events/dotnetConf/2015/The-F-Path-to-Data-Scripting-Nirvana) and
[download page with templates](http://fslab.org/download/) and other instructions.

Last time, I mentioned that we are working on integrating FsLab with the [XPlot charting 
library](http://tahahachana.github.io/XPlot/). XPlot is a wonderful F# library built by 
[Taha Hachana](https://twitter.com/TahaHachana) that wraps two powerful HTML5 visualization libraries - 
[Google Charts](https://developers.google.com/chart/) and [plot.ly](https://plot.ly/). 

I thought I'd see what interesting visualizations I can built with XPlot, so I opened the [World Bank type
provider](http://fsharp.github.io/FSharp.Data/library/WorldBank.html) to get some data about the world
and Euro area, to make the blog post relevant to what is happening in the world today.

<img src="http://tomasp.net/blog/2015/fslab-world-visualization/world-sm.png" />
*)