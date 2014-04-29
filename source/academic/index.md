@{ 
  Layout = "academic";
  Title = "Tomas Petricek @ University of Cambridge";
  Description = "Tomas Petricek's research and teaching home page. Here you'll find" + 
    " information about my current research interests, supervisions and recent publications.";
}

<div class="row academic">
<div class="large-7 columns main-content">

# Tomas Petricek @@ [Computer Lab](http://www.cl.cam.ac.uk)

I'm a third (final) year PhD Student in the [Computer Laboratory](http://www.cl.cam.ac.uk) at the 
[University of Cam­bridge](http://www.cam.ac.uk) and a member of the [Programming, Logic and 
Semantics Group](http://www.cl.cam.ac.uk/research/pls). My supervisors are 
[Alan Mycroft](http://www.cl.cam.ac.uk/~am21/) from the Computer Lab and 
[Don Syme](http://research.microsoft.com/en-us/people/dsyme/). 
Before joining the Computer Laboratory, I studied at the [Faculty of Mathematics and 
Physics](http://www.mff.cuni.cz) in Prague and I did two internships at Microsoft Research. 
I also did an internship at BlueMountain Capital, working on [data science library Deedle](http://bluemountaincapital.github.io/Deedle).

I'm an active member of the F# community, I often speak at [various industry 
events and user groups](http://lanyrd.com/profile/tomasp/), I wrote 
[a book about F#](http://www.manning.com/petricek) and I have a blog. 
For my work in the industry, see [my professional home page](http://tomasp.net). 

To learn about my research, continue reading, or go straight to the [list of publications](#pubs).
If you're a Cambridge student or a <abbr title="Director of Studies, not Denial of Service!">DoS</abbr>, 
scroll to [teaching & supervisions](#supervis).

</div>
<div class="large-5 columns main-content">
<div id="acad-photo" style="margin-top:20px">
<div><img src="@Model.Root/academic/img/photo.jpg" alt="Tomas Petricek" /></div>

Connect via twitter: [@@tomaspetricek](http://twitter.com/tomaspetricek)  
Email me at: [tomas.petricek@cl.cam.ac.uk](mailto:tomas.petricek@cl.cam.ac.uk)  
For more see my: [GitHub](https://github.com/tpetricek) | [LinkedIn](http://www.linkedin.com/in/tomaspetricek) | [Lanyrd](http://lanyrd.com/profile/tomasp/)  

</div>
</div>
</div>

<!-- ------------------------------------------------------------------------------------------ -->

<div class="row academic">
<div class="large-4 columns main-content">

### Theory of coeffects

<div>
<img src="@Model.Root/academic/img/coeffects.png" title="Typing rule for coeffect systems" 
  style="float:right;margin:5px 0px 5px 5px" />
</div>

I believe that tracking what applications _require_ from the envirnoment in which they 
run is perhaps more important than tracking how they _affect_ the envirnoment. 

In a modern 
application, the environment includes services called, resources, system capabilities, 
and so on. Yet, most existing research focuses on the second problem. Coeffects attempt 
to provide the missing piece of the puzzle.

 * See [overview slides](@Model.Root/academic/talks/coeffects-highlevel.pdf) or [view online](http://reelapp.com/e38aae)
 * Read [ICALP'13 paper on coeffects](@Model.Root/academic/papers/coeffects/)

</div>
<div class="large-4 columns main-content">

### Data science

<img src="@Model.Root/academic/img/fsdata.png" title="Accessing JSON with JSON type provider" style="float:right;margin:5px 0px 5px 5px" />

Data science opens many interesting questions for programming languages. How do we make
data easily accessible? How do we provide safety guarantees for code that is often very 
dynamic and interactive? 

I contributed to F# type providers which address accessing the data and some of my current
work fits in the general "data science" theme.

 * [DDFP'13 paper](@Model.Root/academic/papers/inforich/) that I contributed to
 * Watch my [video-lecture at Channel 9](http://channel9.msdn.com/posts/Tomas-Petricek-How-F-Learned-to-Stop-Worrying-and-Love-the-Data) 
 * Open-source [F# Data](http://fsharp.github.io/FSharp.Data/) &
   [Deedle](http://bluemountaincapital.github.io/Deedle)

</div>
<div class="large-4 columns main-content">

### F# theory & practice

<img src="@Model.Root/academic/img/match.png" title="Concurrent, parallel and reactive programming with joinads" style="float:right;margin:5px 0px 5px 5px" />

I'm interested in bridging the gap between theory and practice in functional programming.
I wrote a book Real-World Functional Programming that explains F# from a perspective of
.NET developer and I [teach F# in the industry](http://www.functional-programming.net/).

I worked on _computation expressions_ in F#, both by developing the theory 
(PADL'14) and by making them more relevant (Joinads).

 * Computation expressions [PADL'14 paper](@Model.Root/academic/papers/computation-zoo/)
 * [Try Joinads](http://www.tryjoinads.org) and [Haskell'11 paper](@Model.Root/academic/papers/docase/).
 * [Real-World Functional Programming](http://manning.com/petricek)

</div></div>
<a name="pubs" style="position:relative;top:-70px">&#160;</a>
<!-- ------------------------------------------------------------------------------------------ -->
<div class="row academic">
<div class="large-6 columns publist main-content">

## Recent publications

#### **[April 2014]** [What can Programming Language Research  Learn from the Philosophy of Science?](@Model.Root/academic/papers/philosophy-pl/)

> Tomas Petricek. In Proceedings of AISB 2014

This essay looks how theories from philosophy of science apply
to programming language research. I argue that it is important to clearly state research 
programme, avoid early over-emphasis on precision and I consider how to produce truly reusable
experiments.

 - [abstract](@Model.Root/academic/papers/philosophy-pl/) | [cite](@Model.Root/academic/papers/philosophy-pl/#cite) | 
   [talk](@Model.Root/academic/papers/philosophy-pl/philosophy-pl-aisb.pdf) | 
   [paper](@Model.Root/academic/papers/philosophy-pl/philosophy-pl.pdf)

#### [The F# Computation Expression Zoo](@Model.Root/academic/papers/computation-zoo/)

> Tomas Petricek and Don Syme. In Proceedings of PADL 2014.

F# computation expressions F# provide a _uniform_ syntax for computations such as
monads, monad transformers and applicative functors. The syntax is _adaptable_ and 
close to built-in language features of Python and C#. This article provides the details
shows that the right syntax can often be determined by considering laws.

 - [abstract](@Model.Root/academic/papers/computation-zoo/) | [cite](@Model.Root/academic/papers/computation-zoo/#cite) | 
   [poster](@Model.Root/academic/papers/computation-zoo/poster-tfp.pdf) | 
   [talk](@Model.Root/academic/papers/computation-zoo/talk-tfp.pdf) | 
   [paper](@Model.Root/academic/papers/computation-zoo/computation-zoo.pdf)

#### [Coeffects: Unified static analysis of context-dependence](@Model.Root/academic/papers/coeffects/)

> Tomas Petricek, Dominic Orchard and Alan Mycroft. In Proceedings of ICALP 2013.

Effects capture how computations _affect_ the environment, coeffects capture the
_requirements_ that computations place on the environment. We present a unified 
coeffect system that can be used for checking liveness and properties of 
data-flow or distributed programs,

 - [abstract](@Model.Root/academic/papers/coeffects/) | [cite](@Model.Root/academic/papers/coeffects/#cite) | 
   [talk](@Model.Root/academic/papers/coeffects/icalp-talk.pdf) | 
   [paper](@Model.Root/academic/papers/coeffects/coeffects-icalp.pdf)

## Papers published previously

#### [Evaluation strategies for monadic computations](@Model.Root/academic/papers/malias/)

> Tomas Petricek. In Proceedings of MSFP 2012.

When translating pure functional code to a monadic version, we need to use different translation depending
on the desired evaluation strategy. In this paper, we present an unified translation that is parameterized by
an operation <code>malias</code>. We also show how to give <em>call-by-need</em> translation for certain
monads.

 - [abstract](@Model.Root/academic/papers/malias/) | [cite](@Model.Root/academic/papers/malias/#cite) | 
   [talk](@Model.Root/academic/papers/malias/talk-msfp.pdf) |
   [paper](@Model.Root/academic/papers/malias/malias.pdf)

#### [Extending Monads with Pattern Matching](@Model.Root/academic/papers/docase/)

> Tomas Petricek, Alan Mycroft and Don Syme. In Haskell Symposium 2011.

The paper introduces a `docase` notation for Haskell that can be used for any monad that 
provides additional operations representing parallel composition, choice and aliasing. We require the 
operations to form a near-semiring, which gurantees that the notation resembles pattern matching.

 - [abstract](@Model.Root/academic/papers/docase/) | [cite](@Model.Root/academic/papers/docase/#cite) |
   [talk](@Model.Root/academic/papers/docase/haskell-symposium.pdf) |
   [paper](@Model.Root/academic/papers/docase/docase.pdf)

#### [Joinads: a retargetable control-flow construct for reactive, parallel and concurrent programming](@Model.Root/academic/papers/joinads/)

> Tomas Petricek and Don Syme. In Proceedings of PADL 2011.

Reactive, parallel and concurrent programming models are often difficult to encode in 
general-purpose programming languages. We present a lightweight language extension based on 
pattern matching that can be used for encoding a wide range of these models.

 - [abstract](@Model.Root/academic/papers/joinads/) | [cite](@Model.Root/academic/papers/joinads/#cite) |
   [talk](@Model.Root/academic/papers/joinads/padl-talk.pdf) |
   [paper](@Model.Root/academic/papers/joinads/joinads.pdf)

#### [The F# Asynchronous Programming Model](@Model.Root/academic/papers/async/)

> Don Syme, Tomas Petricek and Dmitry Lomov. In PADL 2011.

We describe the asynchronous programming model in F#, and its applications. It combines a core 
language with a non-blocking modality to author lightweight asynchronous tasks. This allows smooth 
transitions between synchronous and asynchronous code and eliminates the inversion of control.

 - [abstract](@Model.Root/academic/papers/async/) | [cite](@Model.Root/academic/papers/async/#cite) |
   [paper](@Model.Root/academic/papers/async/async.pdf)

#### [Collecting Hollywood's Garbage: Avoiding Space-Leaks in Composite Events](@Model.Root/academic/papers/hollywood/)

> Tomas Petricek and Don Syme. In Proceedings of ISMM 2010.

The article discusses memory leaks that can occur in a reactive programming model based on events. 
It presents a formal garbage collection algorithm that could be used in this scenario and a 
correct reactive library based on this idea, implemented in F#.

 - [abstract](@Model.Root/academic/papers/hollywood/) | [cite](@Model.Root/academic/papers/hollywood/#cite) |
   [talk](@Model.Root/academic/papers/hollywood/ismm-talk.pdf) | [paper](@Model.Root/academic/papers/hollywood/hollywood.pdf)

#### [Encoding monadic computations in C# using iterators](@Model.Root/academic/papers/iterators/)

> Tomas Petricek. In Proceedings of ITAT 2009

The paper shows how to encode certain monadic computations (such as a continuation monad
for asynchronus programming) using the iterator language feature in C# 2.0. 

 - [abstract](@Model.Root/academic/papers/iterators/) | [cite](@Model.Root/academic/papers/iterators/#cite) |
   [talk](@Model.Root/academic/papers/iterators/iterators-itat.pdf) |
   [paper](@Model.Root/academic/papers/iterators/iterators.pdf) | [code](@Model.Root/academic/papers/iterators/iterators-src.zip) 

## Articles and reports

#### [Fun with Parallel Monad Comprehensions](@Model.Root/academic/articles/comprefun/)

> Tomas Petricek. The Monad.Reader Issue 18.

The article presents several monads that can benefit from the _parallel monad comprehension_
notation that is supported in the re-designed monad comprehension syntax in Haskell. The examples
are inspired by the work on joinads and include parsers, parallel and concurrent computations.

 - [details](@Model.Root/academic/articles/comprefun/) | [article](@Model.Root/academic/articles/comprefun/comprefun.pdf) | [online](http://tomasp.net/blog/comprefun.aspx/)

#### [F# Web Tools: Rich client/server web applications in F#](@Model.Root/academic/articles/fswebtools/)

> Tomas Petricek. Unpublished draft, 2007

This paper presents one of the first "Ajax" programming frameworks that let you develop 
integrated client/server applications in an integrated way using a single language. The 
framework lets you use F# on both sides and provides a smooth integration between client
and server-side code. 

 - [details](@Model.Root/academic/articles/fswebtools/) | [article](@Model.Root/academic/articles/fswebtools/fswebtools-ml.pdf)

#### [Effect and coeffect type systems](@Model.Root/academic/theses/first-year/first-year.pdf)

> Tomas Petricek. First year report, Computer Laboratory.

The research goal discussed in the report is to use types in an ML-style language to track
additional properties of computations including various kinds of effects (communication, memory access)
and coeffects (how a computation depends on a context). The document briefly summarizes the work
done during the first-year (including the work on _joinads_ and _coeffects_) and
it proposes future research projects.

 - [details](@Model.Root/academic/theses/first-year/) | [report](@Model.Root/academic/theses/first-year/first-year.pdf)

## Theses and older projects

#### [Reacitve programming with events](@Model.Root/academic/theses/events)

> Master thesis. Charles University in Prague, 2010

The thesis uses early version of joinad langauge extension for F# and garbage collection
for events. Based on these concepts, it builds a simple reactive library for F# that allows
writing reactive computations in both control-flow and data-flow styles.

 - [abstract](@Model.Root/academic/theses/events/) | [cite](@Model.Root/academic/theses/events/#cite) | [thesis](@Model.Root/academic/theses/events/events.pdf) 

#### [Client-side scripting using meta-programming](@Model.Root/academic/theses/webtools) 

> Bachelor thesis. Charles University in Prague, 2007

The thesis presents a web development framework for F# that automatically splits a single F# 
program with monadic modality annotations into client-side JavaScript and server-side ASP.NET
application.

 - [abstract](@Model.Root/academic/theses/webtools/) | [cite](@Model.Root/academic/theses/webtools/#cite) | [report](@Model.Root/academic/theses/webtools/webtools-report.pdf) |
   [thesis](@Model.Root/academic/theses/webtools/webtools.pdf)

</div>
<!-- ------------------------------------------------------------------------------------------ -->

<div class="large-6 columns main-content">
<div class="publist">

## Work in progress
Start here if you want to know that I'm currently working on and what I recently 
completed. Unpublished drafts are marked as such and I'm always looking for feedback!

#### **[July 2013]** Draft: [Analysing context dependence in programs](@Model.Root/academic/drafts/coeffects-structural/)

> Tomas Petricek, Dominic Orchard, Alan Mycroft. Unpublished draft.

This paper develops _structural coeffect calculus_ which extends our earlier
work on _coeffects_ to make it more useful for tracking contextual information
related to individual variables, such as liveness and provenance.

 - [abstract](@Model.Root/academic/drafts/coeffects-structural/) | [draft](@Model.Root/academic/drafts/coeffects-structural/coeffects-structural.pdf)


#### Draft: [Teaching Functional Programming to Professional .NET Developers](@Model.Root/academic/drafts/fsharp-teaching/)

> Tomas Petricek. In Pre-proceedings of TFPIE 2012.

Functional programming is often taught at universities, but with the recent rise of functional
programming in the industry, it is becoming important to teach functional concepts to experienced
developers. This requires a very different approach.

 - [abstract](@Model.Root/academic/drafts/fsharp-teaching/) | [talk](@Model.Root/academic/drafts/fsharp-teaching/tfpie-talk.pdf)
 | [draft](@Model.Root/academic/drafts/fsharp-teaching/fsharp-teaching.pdf)

</div>
<div class="black-box">

## Talks and recordings

 * **Video**: [How F# Learned to Stop Worrying and Love the Data](http://channel9.msdn.com/posts/Tomas-Petricek-How-F-Learned-to-Stop-Worrying-and-Love-the-Data)  
   (Video lecture, Recorded at Channel 9, 2013)
 * [Coeffects: Types for tracking context-dependence](@Model.Root/academic/talks/coeffects-mit.pdf)  
   (Massachusetts Institute of Technology, 2013)
 * [Information-rich programming in F#](@Model.Root/academic/talks/inforich-ml.pdf)  
   (Invited talk at the ML Workshop, 2012)
 * **Video**: [Coeffects: The essence of context-dependence](http://www.youtube.com/watch?v=gEkXDd46_S8)  
   (Student Research Competition at ICFP 2012)
 * [Tracking context-dependent properties using coeffects](@Model.Root/academic/talks/coeffects-tallinn.pdf)  
   (Institute of Cybernetics, Tallinn University, 2012)
 * **Video**: [Reactive pattern matching for F#](http://langnetsymposium.com/2009/talks/22-TomasPatricek-Reactive.html)  
   (Lang.NET Symposium 2009, Microsoft, Redmond) 

</div>
<div style="position:relative;height:1px;overflow:hidden;top:-80px;"><a name="supervis">&#160;</a></div>

## Supervisions and teaching 

<img src="@Model.Root/academic/img/cam.png" style="float:right;margin:10px 0px 0px 20px" title="Cambridge University"/>

I'm happy to supervise Part II (final year) projects that are related to functional 
programming, F# (or other functional languages), data science and data access, JavaScript 
and web programming or other interesting topics.

 - See a list with [my project ideas](@Model.Root/academic/teaching/projects/)
 - If you want to discuss your idea, [get in touch!](mailto:tomas.petricek@cl.cam.ac.uk)

I had the pleasure of supervising some great Part II students:

 - Eduardo Munoz, working on [Type-safe multilanguage programming](http://edua.rdomunoz.com/diss.pdf)
 - Lewis Brown's [Refactoring tool for F#](https://github.com/Lewix/fsharp-refactor), also at [GSoC 2013](http://monosoc.blogspot.com/2013/10/the-google-summer-of-code-is-over-and.html)
 - David Barker, working on [Functional Reactive Programming for Data Binding in C# (Bitbucket)](https://bitbucket.org/animatinator/c-arrows)

I supervised the following Computer Laboratory courses for various colleges 
and I'm happy to supervise them again:

 - [Semantics of Programming Languages](http://www.cl.cam.ac.uk/teaching/1213/Semantics/) (Lent 2012/13)
 - [Concepts in Programming Language](http://www.cl.cam.ac.uk/teaching/1112/ConceptsPL/) (Easter 2011/12)
 - [Types](http://www.cl.cam.ac.uk/teaching/1112/Types/) (Michaelmas 2011/12)
 - [Optimising Compilers](http://www.cl.cam.ac.uk/teaching/1112/OptComp/) (Michaelmas 2011/12, 2012/13)
 - [Denotational Semantics](http://www.cl.cam.ac.uk/teaching/1112/DenotSem/) (Lent 2011/12)

## Academic community

I was a member of the Program Committee (PC) for 
<abbr title="ML Workshop 2013">ML 2013</abbr>, <abbr title="ML Workshop 2012">ML 2012</abbr>, 
<abbr title="Commercial Users of Functional Programming 2012">CUFP 2012</abbr>
and <abbr title="Programming Semantic Web 2012">PSW 2012</abbr> 
and a member of External Review Committee (XRC) for 
<abbr title="International Symposium on Memory Management 2012">ISMM 2012</abbr> and
<abbr title="International Symposium on Memory Management 2011">ISMM 2011</abbr>.
I also reviewed papers for 
<abbr title="Principles and Practice of Declarative Programming">PPDP 2013</abbr>,
<abbr title="Typed Lambda Calculi and Applications 2013">TLCA 2013</abbr>,
<abbr title="Compiler Construction 2013">CC 2013</abbr> and 
<abbr title="European Conference on Object Oriented Programming 2012">ECOOP 2012</abbr>.

I'm happy to review papers that (broadly) match my interest in programming models, types, 
concurrent & distribtued and reactive programming, data & web and langauge integration 
(and also any controversial, provocative and novel work). 

<div class="publist">

## Teaching in Prague
As an undergraduate and Master's student at the Charles University in Prague, I 
helped to organize and teach non-compulsory courses.

#### [Programming languages F# and OCaml](http://tomasp.net/materials/mff-fsharp-09/) (English)

> Charles University, Winter 2009/2010

The lecture teaches programming in the ML-family of languages and highlights the mathematical 
foundations of ML languages. As a results students should find it easier to understand many 
mathematical concepts. It also explains advanced F# features such as computation expressions.

#### [WinFX Programming](https://github.com/tpetricek/Documents/tree/master/Archive/WinFX%20(2005-2006)) (Czech)

> Charles University, Summer 2005/2006

A practically oriented seminar about Windows programming using the WinFX framework (now called 
WPF, WCF and WF), which was in beta version in 2006. It discussed graphics, working with data 
and communication between applications (Jointly taught with Vojtech Jakl).
    
</div>
</div></div>