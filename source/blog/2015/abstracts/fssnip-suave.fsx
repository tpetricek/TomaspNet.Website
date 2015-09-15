(**
<img src="http://tomasp.net/blog/2015/fssnip-suave/logo.png" style="width:130px;float:right;margin-left:10px" />

The core of many web sites and web APIs is very simple. Given an HTTP request,
produce a HTTP response. In F#, we can represent this as a function with type
`Request -> Response`. To make our server scalable, we should make the function
_asynchronous_ to avoid unnecessary blocking of threads. In F#, this can be 
captured as `Request -> Async<Response>`. Sounds pretty simple, right? So why 
are there so many [evil frameworks](http://tomasp.net/blog/2015/library-frameworks/)
that make simple web programming difficult?  

Fortunately, there is a nice F# library called [Suave.io](http://suave.io) that 
is based exactly on the above idea:

> Suave is a simple web development F# library providing a lightweight web server 
> and a set of combinators to manipulate route flow and task composition.

I recently decided to start a new version of the [F# Snippets](http://www.fssnip.net)
web site and I wanted to keep the implementation functional, simple, 
cross-platform and easy to contrbute to. I wrote a [first prototype of the 
implementation](https://github.com/tpetricek/FsSnip.Website/) using Suave and 
already received a few contributions via pull requests! In this blog post, I'll
share a few interesting aspects of the implementation and I'll give you some
good pointers where you can learn more about Suave. _There is no excuse for not
contributing to F# Snippets v2 after reading this blog post_!
*)