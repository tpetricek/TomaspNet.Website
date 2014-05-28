(**

As Howard Mansell already [announced on the BlueMountain Tech blog](http://techblog.bluemountaincapital.com/2014/05/21/deedle-v1-0-release/),
we have officially released the "1.0" version of Deedle. In case you have not 
heard of Deedle yet, it is a .NET library for interactive data analysis and 
exploration. Deedle works great with both C# and F#. It provides two main data
structures: _series_ for working with data and time series and _frame_ for working
with collections of series (think CSV files, data tables etc.)

The great thing about Deedle is that it has been becoming a foundational library
that makes it possible to integrate a wide range of diverse data-science components.
For example, the [R type provider](http://bluemountaincapital.github.io/FSharpRProvider/)
works well with Deedle and so does [F# Charting](http://fsharp.github.io/FSharp.Charting/).
We've been also working on integrating all of these into a single package called 
[FsLab](https://github.com/tpetricek/FsLab), but more about that next time! 

In this blog post, I'll have a quick look at a couple of new features in Deedle 
(and corresponding R type provider release). Howard's announcement has a 
[more detailed list](http://techblog.bluemountaincapital.com/2014/05/21/deedle-v1-0-release/), 
but I just want to give a couple of examples and briefly comment on performance
improvemens we did.

*)