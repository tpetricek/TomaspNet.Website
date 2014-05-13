(**
<img src="http://tomasp.net/blog/2014/update-monads/code.png" style="float:right;margin:20px;width:200px" />

Most discussions about monads, even in F#, start by looking at the well-known standard 
monads for handling state from Haskell. The _reader_ monad gives us a way to propagate 
some read-only state, the _writer_ monad makes it possible to (imperatively) produce 
values such as logs and the _state_ monad encapsulates state that can be read and changed.

These are no doubt useful in Haskell, but I never found them as important for F#.
The first reason is that F# supports state and mutation and often it is just easier
to use a mutable state. The second reason is that you have to implement three 
different computation builders for them. This does not fit very well with the F# style
where you need to name the computation explicitly, e.g. by writing `async { ... }`
(See also my [recent blog about the F# Computation Zoo paper][zoo]).

When visiting the Tallinn university in December (thanks to James Chapman, Juhan Ernits 
& Tarmo Uustalu for hosting me!), I discovered the work on _update monads_ by Danel Ahman 
and Tarmo Uustalu on [update monads][um], which elegantly unifies _reader_, _writer_ and 
_state_ monads using a single abstraction.

In this article, I implement the idea of _update monads_ in F#. Update monads are 
parameterized by _acts_ that capture the operations that can be done on the state.
This means that we can define just a single computation expression `update { ... }` 
and use it for writing computations of all three aforementioned kinds. 

  [zoo]: http://tomasp.net/blog/2013/computation-zoo-padl
  [zoopaper]: http://tomasp.net/academic/papers/computation-zoo/
  [um]: http://cs.ioc.ee/~tarmo/papers/types13.pdf
  [smc]: http://msdn.microsoft.com/en-us/library/dd233203.aspx
  [fsspec]: http://fsharp.org/about/index.html#specification
*)