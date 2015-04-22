(**
I was recently working on some code for handling date ranges in 
[Deedle](http://github.com/blueMountainCapital/Deedle). Although Deedle is written in F#, 
I also wrote some internal integration code in C#. After doing that, I realized that the 
code I wrote is actually reusable and should be a part of Deedle itself and so I went through
the process of rewriting a simple function from (fairly functional) C# to F#. This is a small
(and by no means representative!) example, but I think it nicely shows some of the reasons why
I like F#, so I thought I'd share it.

One thing that we are adding to Deedle is a "BigDeedle" implementation of internal data 
structures. The idea is that you can load very big frames and series without actually loading
all data into memory.

When you perform slicing on a large series and then merge some of the parts of the series
(say, years 2010, 2012 and 2014), you end up with a series that combines a
couple of chunks. If you then restrict the series (say, from June 2012 to June 2014), you
need to restrict the ranges of the chunks:

<img src="http://tomasp.net/blog/2015/restricting-ranges/drawing.png" alt="Demonstration" style="margin:15px; width:370px" />

As the diagram shows, this is just a matter of iterating over the chunks, keeping those 
in the range, dropping those outside of the range and restrictingthe boundaries of the other
chunks. So, let's start with the C# version I wrote.
*)