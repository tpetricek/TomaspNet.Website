(**

F# [computation expressions](http://msdn.microsoft.com/en-us/library/dd233182.aspx) are the 
syntactic language mechanism that is used by features like sequence expressions and asynchronous
workflows. The aim of F# computation expressions is to provide a _single_ syntactic mechanism
that provides convenient notation for writing a wide range of computations.

The syntactic mechanisms that are unified by computation expressions include Haskell `do` 
notation and list comprehensions, C# iterators, asynchronous methods and LINQ queries,
Scala `for` comprehensions and Python generators to name just a few.

Some time ago, I started working on an academic article to explain what makes computation
expressions unique - and I think there is quite a few interesting aspects. Sadly, this is 
often not very well explained and so the general perception is more like this...

*)