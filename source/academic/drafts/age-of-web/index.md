@{ 
  Layout = "paper";
  Title = "Teaching Functional Programming to Professional .NET Developers";
  Description = "";
}

# In the Age of Web: Typed Functional-First Programming Revisited

> Tomas Petricek, Don Syme
>
> Draft - Work in progress
  
Most programming languages were designed before the age of web.
This matters because the web changes many assumptions that typed functional language designers take 
for granted. For example, programs do not run in a closed word, but must instead interact with 
(changing and likely unreliable) services and data sources, communication is often asynchronous 
or event-driven, and programs need to interoperate with untyped environments.

In this paper, we present how F# language and libraries face the challenges posed by the web.
Technically, this comprises using _type providers_ for integration with external information 
sources and for integration with untyped programming environments, using _lightweight 
meta-programming_ for targeting JavaScript and _computation expressions_ for writing 
asynchronous code.

In this inquiry, the holistic perspective is more important than each of the features in isolation.
We use a practical case study as a starting point and look how F# language and libraries approach 
the challenges posed by the web. The specific lessons learned are perhaps less interesting than 
our attempt to uncover hidden assumptions that no longer hold in the age of web.

## Watch the talk

Thanks to the ML workshop organizers, the video from my original talk,
[Doing web-based data anlytics with F#](https://www.youtube.com/watch?v=_YOSAXKY-JI) is on YouTube!
  
<iframe style="margin-left:25px" width="420" height="315" src="//www.youtube.com/embed/_YOSAXKY-JI" frameborder="0" allowfullscreen></iframe>

## Draft and more information

 - Download [the draft (PDF)](age-of-web.pdf)
 - Download (shorter) [extended abstract (PDF)](ml-abstract.pdf)
 - View [slides from ML workshop talk](ml-talk.pdf)
 - The source code & running demo of the case study is [on the FunScript website](http://funscript.info/samples/worldbank/)

## Comments are welcome!

If you have any comments, suggestions or related ideas, I'll be happy to 
hear from you! Send me an email at [tomas.petricek@cl.cam.ac.uk](mailto:tomas.petricek@cl.cam.ac.uk)
or get in touch via Twitter at [@@tomaspetricek](http://twitter.com/tomaspetricek).