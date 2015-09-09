(**
Most programming languages were designed before the age of web.
This matters because the web changes many assumptions that typed functional 
language designers tak for granted. For example, programs do not run in a 
_closed world_, but must instead interact with (changing and likely unreliable) 
services and data sources, communication is often asynchronous or event-driven, 
and programs need to interoperate with untyped environments like JavaScript
libraries.

How can statically-typed programming languages adapt to the modern world?
In this article, I look at one possible answer that is inspired by the F# 
language and various F# libraries. In F#, we use _type providers_ for 
integration with external information sources and for integration with untyped
programming environments. We use _lightweight meta-programming_ for targeting 
JavaScript and _computation expressions_ for writing asynchronous code.

This blog post is a shorter version of a [ML workshop paper](http://tomasp.net/academic/papers/age-of-web/)
that I co-authored earlier this year and you should see this more as a position
statement. I'm not sure if F# and the solutions shown here are the best ones,
but I think they highlight very important questions in programming language 
design that I very much see as unsolved.

The article has two sections. First, I'll go through a simple case study showing
how F# can be used to build a client-side web widget. Then, I'll discuss some
of the implications for programming language design based on the example.
*)