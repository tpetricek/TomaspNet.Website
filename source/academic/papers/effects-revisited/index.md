@{
  Layout = "paper";
  Title = "Effect systems revisited - control-flow algebra and semantics";
  Description = "";
}

# Effect systems revisited - control-flow algebra and semantics

> Alan Mycroft, Dominic Orchard, Tomas Petricek
>
> Semantics, Logics, and Calculi, 2016

 Effect systems were originally conceived as an inference-based program analysis to
 capture program behaviour - as a set of (representations of) effects. Two orthogonal developments
 have since happened. First, motivated by static analysis, effects were generalised to values in an
 algebra, to better model control flow (e.g. for may/must analyses and concurrency). Second,
 motivated by semantic questions, the syntactic notion of set- (or semilattice-) based effect system
 was linked to the semantic notion of monads and more recently to graded monads which give a more
 precise semantic account of effects.

 We give a lightweight tutorial explanation of the concepts
 involved in these two threads and then unify them via the notion of an effect-directed semantics
 for a control-flow algebra of effects. For the case of effectful programming with sequencing,
 alternation and parallelism - illustrated with music - we identify a form of graded joinads as the
 appropriate structure for unifying effect analysis and semantics.

## Paper and more information

 - Download [the paper (PDF)](effects-revisited.pdf)

## <a id="cite">Bibtex</a>
If you want to cite the paper, you can use the following BibTeX information, or
get full details from the paper page on ACM (TBA).

    [lang=tex]
    @@incollection{effects-revisited,
      title={Effect Systems Revisited—Control-Flow Algebra and Semantics},
      author={Mycroft, Alan and Orchard, Dominic and Petricek, Tomas},
      booktitle={Semantics, Logics, and Calculi},
      pages={1--32},
      year={2016},
      publisher={Springer}
    }    

If you have any comments, suggestions or related ideas, I'll be happy to
hear from you! Send me an email at [tomas@tomasp.net](mailto:tomas@tomasp.net)
or get in touch via Twitter at [@@tomaspetricek](http://twitter.com/tomaspetricek).
