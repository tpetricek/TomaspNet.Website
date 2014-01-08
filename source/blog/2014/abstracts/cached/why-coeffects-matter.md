<p>Many advances in programming language design are driven by some practical motivations.
Sometimes, the practical motivations are easy to see - for example, when they come from
some external change such as the rise of multi-core processors. Sometimes, discovering 
the practical motivations is a tricky task - perhaps because everyone is used to a 
certain way of doing things that we do not even <em>see</em> how poor our current solution is.</p>

<p>The following two examples are related to the work done in F# (because this is what
I'm the most familiar with), but you can surely find similar examples in other languages:</p>

<ul>
<li><p><strong>Multi-core</strong> is an easy to see challenge caused by an external development. 
It led to the popularity of <em>immutable</em> data structures (and functional programming,
in general) and it was also partly motivation for <a href="http://msdn.microsoft.com/en-us/library/dd233250.aspx" title="Asynchronous Workflows (F#)">asynchronous workflows</a>.</p></li>
<li><p><strong>Data access</strong> is a more subtle challenge. Technologies like <a href="http://msdn.microsoft.com/en-us/library/bb397926.aspx" title="LINQ (Language-Integrated Query)">LINQ</a> make it
significantly easier, but it was not easy to see that inline SQL was a poor solution.
This is even more the case for F# <em>type providers</em>. You will not realize how poor the
established data access story is until you <em>see</em> something like
the <a href="http://www.youtube.com/watch?v=cCuGgA9Yqrs" title="F# R Type Provider Demo">WorldBank and R provider</a> or <a href="http://fsharp.github.io/FSharp.Data/library/CsvProvider.html" title="F# Data: CSV type provider">CSV type provider</a>.</p></li>
</ul>

<p>I believe that the next important practical challenge for programming language designers
is of the kind that is not easy to see - because we are so used to doing things in 
certain ways that we cannot see how poor they are. The problem is designing languages
that are better at working with (and understanding) the <em>context</em> in which programs are
executed.</p>

