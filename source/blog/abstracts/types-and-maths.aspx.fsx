(**

<img src="http://tomasp.net/articles/types-and-maths/distributivity.png" class="rdecor" />

One of the most amazing aspects of mathematics is that it applies to such a wide range 
of areas. The same mathematical rules can be applied to completely different objects 
(say, forces in physics or markets in economics) and they work exactly the same way.

In this article, we'll look at one such fascinating use of mathematics - we'll use 
elementary school algebra to reason about functional data types.

In functional programming, the best way to start solving a problem is to think about
the data types that are needed to represent the data that you will be working with.
This gives you a simple starting point and a great tool to communicate and
develop your ideas. I call this approach [Type-First Development and I wrote about
it earlier](http://tomasp.net/blog/type-first-development.aspx), so I won't repeat
that here. 

The two most elementary types in functional languages are _tuples_ (also called pairs 
or product types) and _discriminated unions_ (also called algebraic data types, case 
classes or sum types). It turns out that these two types are closely related to 
_multiplication_ and _addition_ in algebra...

*)
