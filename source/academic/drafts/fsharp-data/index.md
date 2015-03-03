@{ 
  Layout = "paper";
  Title = "F# Data: Making structured data first-class citizens";
  Description = "";
}

# F# Data: Making structured data first-class citizens

> Tomas Petricek, Gustavo Guerra, Don Syme
>
> Draft - Work in progress
  
Most static type systems assume that a program runs in a closed world, but this is not the 
case. Modern applications interact with external services and often access data in structured 
formats such as XML, CSV and JSON. Static type systems do not understand such external data sources
and only make accessing data more cumbersome. Should we just give up and leave the messy world of 
external data to dynamic typing and runtime checks?

Of course, we should not give up! In this paper, we show how to integrate external data sources 
into the F# type system. As most real-world data on the web do not come with an explicit schema, 
we develop a type inference algorithm that infers a type from representative samples. Next, we use 
the type provider mechanism for integrating the inferred structures into the F# type
system. 

The resulting library significantly reduces the amount of code that developers need to write when 
accessing data. It also provides additional safety guarantees. Arguably, as much safety as possible 
if we abandon the incorrect closed world assumption.

## Draft and more information

 - Download [the draft (PDF)](fsharp-data.pdf)
 - For more info, see [F# Data homepage](http://fsharp.github.io/FSharp.Data/)

## Comments are welcome!

If you have any comments, suggestions or related ideas, I'll be happy to 
hear from you! Send me an email at [tomas.petricek@cl.cam.ac.uk](mailto:tomas.petricek@cl.cam.ac.uk)
or get in touch via Twitter at [@@tomaspetricek](http://twitter.com/tomaspetricek).