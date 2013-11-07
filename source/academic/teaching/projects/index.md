@{ 
  Layout = "academic";
  Title = "Part II Project Ideas";
  Description = "";
}

<div class="row academic">
<div class="large-6 columns main-content">

# Part II Project Ideas

I'm generally happy to supervise any interesting project related to programming languages.
I prefer project that are related to some of my interests such as F#, type providers, 
functional languages, data science, applied programming language research (etc.), but
if you have onother interesting project, feel free to get in touch too. 

You might have noticed that I'm an F# fan :-). I'm happy to supervise projects that use
other languages too, the only disadvantage is that I might not be able to help you if you
run into some unexpected issues.

I had the pleasure of supervising some great Part II students in the past. Check out what 
they did if you're looking for an inspiration:

 - **Eduardo Munoz**, working on [Type-safe multilanguage programming](http://edua.rdomunoz.com/diss.pdf)
 - **Lewis Brown's** [Refactoring tool for F#](https://github.com/Lewix/fsharp-refactor), also at [GSoC 2013](http://monosoc.blogspot.com/2013/10/the-google-summer-of-code-is-over-and.html)
 - **David Barker**, working on [Functional Reactive Programming for Data Binding in C# (Bitbucket)](https://bitbucket.org/animatinator/c-arrows)

</div><div class="large-6 columns main-content" style="padding-top:50px">

Working with data and F# type providers:
 
 - [F# type providers](#ftp)
 - [Combinators for schematized data](#cfsd)
 
Functional programming, tools, functional languages and libraries:

 - [Types for cross-compilation](#xcoc) (OCamlLabs related)
 - [Visual editor for domain specific languages](#vefdsl)
 - [Web programming with alternative formlets](#wpwaf)
 - [Fuzzy type-checking](#ftc)

Archived ideas that have already been done by someone:

 - [Functional data-binding](#fdb) (Completed)
 - [Refactoring tool for functional languages](#rtffl) (Completed)

If you have your own idea, check out a few notes about [other projects](#op)

</div></div>
<div class="row academic">
<div class="large-12 columns main-content">

## Working with data and F# type providers

</div></div>
<div class="row academic">
<div class="large-6 columns main-content">

### F# type providers <a name="ftp" class="anchor"></a>

F# 3.0 makes it possible to write "compiler plugins" called _type providers_ that
provide access to external data sources, such as web services, databases, or other online
information sources. The plugin takes the schema of the external data source and maps it to
F# types. The programmer can then easily access any external data source (for which there is a type 
provider). Here is an example:

<img src="http://tomasp.net/articles/fsharp-loosely-typed/tooltip.png" style="margin-bottom:10px;margin-left:40px" />

There is a number of interesting data sources that do not have a type provider yet, so
one project would be to implement a type provider for accessing some interesting data source.
Other interesting projects could deal with unstructured data - for example, how to 
extract reasonable structure from HTML pages or how to easily describe REST services 
(so that the provider can map them to programming language).

#### Related articles

 - [Open Data (WikiPedia)](http://en.wikipedia.org/wiki/Open_data) - a list
   interesting data sources
 - [The Future of F#: Type Providers](http://www.infoq.com/presentations/The-Future-of-FSharp-Type-Providers/) - a 
   talk about type providers
 - [F# Data](https://github.com/fsharp/FSharp.Data) is a library with interesting type providers.  
   Look at the [issue list](https://github.com/fsharp/FSharp.Data/issues?labels=discussion&page=1&state=open) for some ideas.

</div><div class="large-6 columns main-content">

### Combinators for schematized data<a name="cfsd" class="anchor"></a>

When working with external data sources, there is a number of common operations that 
one needs to perform. For example, you can:

 - Merge two data sources that provide similar information (for example, two movie databases)
   and combine the overlapping information (i.e. ratings)
 - Add data source as an extension to another - for example, if you have a directory with
   software companies, you could enhance it by adding their stock prices from data source
   such as Yahoo Finance.
 - And there are probably many other options...

The goal of this project would be to find more interesting operations that can work
on schematized data and to implement them as a library. Ideally, this could be integrated
with F# type providers (so that you could easily create type providers that combine
different data sources).

</div></div>
<div class="row academic">
<div class="large-12 columns main-content">

## Functional programming, tools, languages & libraries

</div></div>
<div class="row academic">
<div class="large-6 columns main-content">

### Types for cross-compilation (OCamlLabs related) <a name="xcoc" class="anchor"></a>

Increasing number of applications are targetting heterogenous execution environments such as server-side, 
client-side, GPU, embedded and web. This is supported by a number of OCaml compiler backends (JavaScript, 
Java, ARM, LLVM) and libraries allowing interoperability. In such a scenario, certain parts of code may be 
compiled only for certain platform-specific environments, but some can be safely shared. This project should
extend the OCaml type system in order to track execution environments for which an expression can be compiled, 
and simplify writing code that cross-compiles for multiple platforms and diverse execution environments.

This project could be done as part of the [OCamlLabs](http://www.cl.cam.ac.uk/projects/ocamllabs/tasks/compiler.html),
but it could be equally implemented as an extension to another programming language.

#### Related articles

 - [Ezra Cooper, Sam Lindley, Philip Wadler, and Jeremy Yallop: Links - web programming without tiers](http://groups.inf.ed.ac.uk/links/papers/links-fmco06.pdf) (PDF) -
   a programming language that has similar cross-compilation feature to the one discussed in this project
 - [Tom Murphy VII, Karl Crary, and Robert Harper: Type-safe distributed programming with ML5](http://www.cs.cmu.edu/~rwh/papers/ml5/tgc.pdf) (PDF) -
   another similar language, this one with more formal background about the types used
 - [Tomas Petricek, Dominic Orchard and Alan Mycroft: Coeffects: Unified static analysis of context-dependence](../../papers/coeffects/) - 
   paper that discusses related type systems in a more general way, talking about any context-dependence (but cross-compilation is a good example)


### Web programming with alternative formlets<a name="wpwaf" class="anchor"></a>

Formlets provide an interesting abstraction for web programming - they represent 
a web "form" that can be rendered (on the server-side) to get HTML representing a form.
When the user fills in form information and submits the result, the "formlet" can 
process the incoming data to get a data-structure representing the result of the form
(such as customer information).

Formlets are designed for old-fashioned web programming where most of the 
processing happens on the server-side, so the question is, could we adapt them
to make them more useful on the client-side too?

One interesting option is using the <code>Alternative</code> type, which 
extends the core concept behind formlets and adds a notion of _choice_.
This means that one could build forms with multiple different options
and the option could be chosen on the client-side dynamically. However, there
are probably many other interesting approaches!

#### Related articles

 - [Web/Libraries/Formlets](http://www.haskell.org/haskellwiki/Formlets) - a brief
   overview of formlets in some Haskell libraries
 - [E. Cooper, S. Lindley, P. Wadler and J. Yallop. The Essence of Form Abstraction](http://groups.inf.ed.ac.uk/links/papers/formlets-essence.pdf) - a
   research paper that first introduced formlets
 - [Control.Applicative - Alternatives](http://hackage.haskell.org/packages/archive/base/latest/doc/html/Control-Applicative.html#g:2) - 
   Haskell documentation for the "Alternative" type class

</div><div class="large-6 columns main-content">

### Visual editor for domain specific languages

Domain specific languages (DSLs) give a powerful technique for writing reusable libraries
(not just) in functional languages. Given a problem (i.e. processing lists), we design a 
set of reusable combinators (mapping, filtering, etc.). A specific problem (such as a task
to multiply elements of two lists by some number and then combine them in some way) can then
be easily solved just by using the available combinators.
  
The approach is used not just for list processing, but in many other areas - for 
composing user interfaces, specifying event handling, modelling financial contracts, 
etc. Here is an example of list processing (using F#):

    List.zip (list1 |> List.map (fun x -> x * 10))
    (list2 |> List.map (fun x -> x * -10))
    |> List.iter (fun (a, b) -> printfn "left %d, right %d" a b)

The code can be quite nicely represented visually, showing how the data flow through
the combinators:

<img src="dsl.png" style="margin-bottom:10px; margin-left:40px" />

The idea of this project is to design some editor (or, at least, visualizer) that
can take code written using DSL and display it visually and allow the user to edit 
it. This should work for any DSL (although it may need to be annotated in some way).

#### Related articles

 - [Research papers/Domain specific languages](http://www.haskell.org/haskellwiki/Research_papers/Domain_specific_languages) - 
a very long list of papers about interesting domain-specific languages in Haskell

### Fuzzy type-checking <a name="ftc" class="anchor"></a>

In statically typed programming languages, the type system is used to check that types
of expressions are used correctly and are correctly composed (i.e. you call a function
with an argument of a correct type).

However, sometimes we do not quite surely know what the type of an expression is. This
may be because we're calling some dynamically typed code or because we're loading data
from an external data source that does not have a clear type.

The goal of this project is to create a "fuzzy" type system that can deal with such
uncertainty in programs. For example, if the type system can tell us that the 
property "Name" is a string in 99% of the cases, then that's quite useful information!

This is probably more theoretical or experimental project, but it could be implemented
as a simple language (i.e. for data processing) or it could be written as an additional
checker for dynamic programs or programs in Haskell, F# or other language.

#### Related articles

 - [Fuzzy Logic](http://en.wikipedia.org/wiki/Fuzzy_logic) - type systems
   for functional languages are connected to logics, so the new type system would be 
   probably related to _fuzzy logics_ in some way


</div></div>
<div class="row academic">
<div class="large-12 columns main-content">

## Completed projects

Below are some project ideas that have been already completed in the past years, but
may be useful as an inspiration (both projects received very good marks, although
a lot of time had to be put into thinking about the evaluation).

</div></div>
<div class="row academic">
<div class="large-6 columns main-content">

### Functional data-binding (Completed) <a name="fdb" class="anchor"></a>

At the basic level, data-binding is a mechanism (known from various JavaScript or .NET libraries) 
that is used to specify how to display data in a user-interface. It is possible to _bind_
various user-interface elements to properties from some data source. More interestingly, 
_two-way data binding_ can be used to create connection that works in both ways - 
the data are displayed in the UI, but when they are changed in the UI, the change is 
propagated back to the data source.

In functional programming, _functional reactive programming (FRP)_ serves a similar
purpose, but it is generally focused on just one way information flow (i.e. how data 
from robot sensors flow and influence the behaviour of a robot).

There is a number of interesting problems here. For example, how could we implement
data-binding library that is less ad-hoc than those used in JavaScript or .NET and is
inspired by functional programming ideas? Could the FRP concepts be extended to work
_bothways_?

#### Related articles

 - [Conal Elliot: Composing Reactive Animations](http://conal.net/fran/tutorial.htm) -
   one of the first incarnations of FRP and a nice introduction
 - [MSDN: Data Binding Overview](http://msdn.microsoft.com/en-us/library/ms752347.aspx) - 
   documentation to data-binding in .NET (it can get incredibly complex)
 - [JavaScript Frameworks And Data Binding](http://tunein.yap.tv/javascript/2012/06/11/javascript-frameworks-and-data-binding/) - 
   somewhat randomly selected article on data-binding in JavaScript (includes discussion 
   about two-way binding)
 - [Arrows: A General Interface to Computation](http://www.haskell.org/arrows/) -
   a functional (Haskell) abstraction that could be (probably) nicely used to model data binding

</div><div class="large-6 columns main-content">


### Refactoring tool for functional languages (Completed) <a name="rtffl" class="anchor"></a>

Any modern IDE like Eclipse or Visual Studio provides a number of automated refactoring 
ranging from simple ones (like rename) to fairly complicated operations (extract part
of a class into a superclass, etc.)

The goal of this project would be to implement some advanced refactorings for  
a functional programming language (probably using open-source compiler for Haskell,
F# or some other).
The interesting question is, what kind of advanced refactorings would be useful
in functional languages?

 - Turn purely functional code to monadic code (i.e. asynchronous in F# or to support I/O in Haskell)
 - Turn a tuple type into a data type such as record
 - Group function parameters into a data type or un-group a data type
 - Extract common parts of two functions into a higher-order function


</div><div class="large-6 columns main-content">
</div>
<div class="row academic">
<div class="large-12 columns main-content">

## Do you have your own project idea? <a name="op" class="anchor"></a>

I'm happy to supervise other interesting projects related to functional programming, F# language
(and other functional languages), programming with data, web programming and JavaScript, as well as 
distributed, concurrent and reactive programming. This is not a complete list, just a list of 
areas that I know more about (and might be able to supervise better). If you have some 
idea that you'd like to discuss,  [get in touch](mailto:tomas.petricek@cl.cam.ac.uk)!

</div>
</div>
