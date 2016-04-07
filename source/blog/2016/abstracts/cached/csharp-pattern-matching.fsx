<img src="http://tomasp.net/blog/2015/csharp-pattern-matching/hat.png" style="float:right;margin:20px" />

<p>On year ago, on this very day, <a href="http://tomasp.net/blog/2014/csharp-6-released/index.html">I wrote about the open-sourcing of C# 
6.0</a>. Thanks to a very special
information leak, I learned about this about a week before Microsoft officially announced
it. However, my information were slightly incorrect - rather then releasing the <a href="https://github.com/Microsoft/visualfsharp/">much 
improved version of the language</a>, Microsoft
continued working on language version internally called "Small C#", which is now available
as "C# 6" in the <a href="https://www.visualstudio.com/en-us/news/vs2015-vs.aspx">Visual Studio 2015 preview</a>.</p>

<p>It is my understanding that, with this release, Microsoft is secretly testing the reaction of the 
developer audience to some of the amazing features that F# developers loved and used for 
the last 7 years and that are coming to C# <em>very soon</em>. To avoid shock, these are however
carefuly hidden!</p>

<p>In this blog post, I'm going to show you <em>pattern matching</em> which is probably the most useful
hidden C# feature and its improvements in C# 6. For reasons that elude me, pattern matching in 
C# 6 is called <em>exception filters</em> and has some unfortunate restrictions. But we can still 
use it to write nice functional code!</p>

