(**

<img src="http://tomasp.net/blog/2015/csharp-pattern-matching/hat.png" style="float:right;margin:20px" />

On year ago, on this very day, [I wrote about the open-sourcing of C# 
6.0](http://tomasp.net/blog/2014/csharp-6-released/index.html). Thanks to a very special
information leak, I learned about this about a week before Microsoft officially announced
it. However, my information were slightly incorrect - rather then releasing the [much 
improved version of the language](https://github.com/Microsoft/visualfsharp/), Microsoft
continued working on language version internally called "Small C#", which is now available
as "C# 6" in the [Visual Studio 2015 preview](https://www.visualstudio.com/en-us/news/vs2015-vs.aspx).

It is my understanding that, with this release, Microsoft is secretly testing the reaction of the 
developer audience to some of the amazing features that F# developers loved and used for 
the last 7 years and that are coming to C# _very soon_. To avoid shock, these are however
carefuly hidden!

In this blog post, I'm going to show you _pattern matching_ which is probably the most useful
hidden C# feature and its improvements in C# 6. For reasons that elude me, pattern matching in 
C# 6 is called _exception filters_ and has some unfortunate restrictions. But we can still 
use it to write nice functional code!

*)