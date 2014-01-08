Many advances in programming language design are driven by some practical motivations.
Sometimes, the practical motivations are easy to see - for example, when they come from
some external change such as the rise of multi-core processors. Sometimes, discovering 
the practical motivations is a tricky task - perhaps because everyone is used to a 
certain way of doing things that we do not even _see_ how poor our current solution is. 

The following two examples are related to the work done in F# (because this is what
I'm the most familiar with), but you can surely find similar examples in other languages:

 * **Multi-core** is an easy to see challenge caused by an external development. 
   It led to the popularity of _immutable_ data structures (and functional programming,
   in general) and it was also partly motivation for [asynchronous workflows][async].

 * **Data access** is a more subtle challenge. Technologies like [LINQ][linq] make it
   significantly easier, but it was not easy to see that inline SQL was a poor solution.
   This is even more the case for F# _type providers_. You will not realize how poor the
   established data access story is until you _see_ something like 
   the [WorldBank and R provider][rdemo] or [CSV type provider][csv].

I believe that the next important practical challenge for programming language designers
is of the kind that is not easy to see - because we are so used to doing things in 
certain ways that we cannot see how poor they are. The problem is designing languages
that are better at working with (and understanding) the _context_ in which programs are
executed.


 [async]: http://msdn.microsoft.com/en-us/library/dd233250.aspx "Asynchronous Workflows (F#)"
 [linq]: http://msdn.microsoft.com/en-us/library/bb397926.aspx "LINQ (Language-Integrated Query)"
 [rdemo]: http://www.youtube.com/watch?v=cCuGgA9Yqrs "F# R Type Provider Demo"
 [csv]: http://fsharp.github.io/FSharp.Data/library/CsvProvider.html "F# Data: CSV type provider"
 