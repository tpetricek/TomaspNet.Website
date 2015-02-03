(**
<img src="http://tomasp.net/blog/2015/library-layers/layers.png" style="float:right;margin:15px 0px 15px 10px" />

Over the last few years, I created or contributed to a number of libraries including 
[F# Data](https://github.com/fsharp/FSharp.Data) for data access,
[Deedle](http://bluemountaincapital.github.io/Deedle/) for exploratory data science with C# and F#,
Markdown parser and code-formatter [F# Formatting](http://tpetricek.github.io/FSharp.Formatting/)
and other fun libraries such as one for composing 3D objects [used in my Christmas blog 
post](http://tomasp.net/blog/2014/composing-christmas/).

Building libraries is a fun and challenging task - even if we ignore all the additional things
that you need to get right such as testing, documentation and building (see [my earlier blog
post](http://tomasp.net/blog/2013/great-open-source/)) and focus just on the API design.
In this blog post (or perhaps a series), I'll share some of the things I learned when trying 
to answer the question: What should a good library look like?

I was recently watching Mark Seemann's course [A Functional architecture with F#](http://blog.ploeh.dk/2014/01/22/a-functional-architecture-with-f/),
which is a great material on designing functional *applications*. But I also realised that not much
has been written on designing functional *libraries*. For some aspect, you can use functional patterns
like monads (see [Scott Wlaschin's presentation](https://skillsmatter.com/skillscasts/6120-functional-programming-design-patterns-with-scott-wlaschin)),
but this only answers a part of the question - it tells you how to design individual types, but
not an entire library...
*)