(**
<img src="http://tomasp.net/blog/2015/library-frameworks/diagram-narrow.png" style="float:right;margin:25px 0px 25px 20px" />

This article is a follow up to my previous blog post about [functional library 
design](http://tomasp.net/blog/2015/library-layers), but you do not need to read the previous one,
because I'll focus on a different topic.

In the previous article, I wrote about a couple of principles that I find useful when 
designing libraries in a functional style. This follows from my experience with building
F# libraries, but the ideas are quite general and can be useful in any programming language.
Previously, I wrote how _multiple layers of abstraction_ let you build libraries that make
80% of scenarios easy while still supporting the more interesting use cases.

In this article, I'll focus on two other points from the list - how to design _composable_
libraries and how (and why) to _avoid callbacks_ in library design. As the title suggests, this
boils down to one thing - build **libraries** rather than **frameworks**!

*)