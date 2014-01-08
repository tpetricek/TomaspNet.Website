@{ 
  Layout = "paper";
  Title = "Analysing context dependence in programs";
  Description = "";
}

# Analysing context dependence in programs 

> Tomas Petricek, Dominic Orchard, Alan Mycroft
>
> Draft - Work in progress
  
The concept of a _coeffect_ system has been recently introduced to analyse context-dependence
in programs. It has been shown to capture various contextual properties such as liveness, caching
requirements in causal dataﬂow and dynamic variable scoping. Although the existing work provides 
a useful mechanism for tracking overall properties of the context, it has limited use for contextual
properties associated with individual variables in the context, such as liveness. 

We remedy this limitation by developing _structural coeffects_ that captures fine-grained information 
about the usage of free variables. This captures additional instances of contextual properties and 
also makes the analysis of liveness and dataﬂow computations more precise and practically useful. 

Since the work onc oeffects is recent, we revisit the development here. We present the existing 
system as the _flat coeffect_ calculus and further develop its syntactic and semantic properties.
We then define the _structural coeffect_ calculus and analyse its syntax and semantics. For contextual 
properties of variables, the structural coeffect calculus has desirable syntactic properties that 
are lacking in ﬂat coeffect calculus. Finally, we extend indexed comonads, which models coeffects, 
to a structural variant. 

## Draft and more information

 - Download [the draft (PDF)](coeffects-structural.pdf)
   
## Comments are welcome!

If you have any comments, suggestions or related ideas, I'll be happy to 
hear from you! Send me an email at [tomas.petricek@cl.cam.ac.uk](mailto:tomas.petricek@cl.cam.ac.uk)
or get in touch via Twitter at [@@tomaspetricek](http://twitter.com/tomaspetricek).