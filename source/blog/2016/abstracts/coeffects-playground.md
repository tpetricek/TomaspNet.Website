In my [PhD thesis](http://tomasp.net/academic/theses/coeffects/), I worked on integrating
_contextual information_ into a type system of functional programming languages. For example,
say your mobile application accesses something from the environment such as GPS sensor or your
Facebook friends. With _coeffects_, this could be a part of the type. Rather than having type
`string -> Person`, the type of a function would also include resources and would be
`string -{ gps, fb }-> Person`. I wrote [longer introduction to coeffects](http://tomasp.net/blog/2014/why-coeffects-matter/) on this
blog before.

As one might expect, the PhD thesis is more theoretical and it looks at other kinds of contextual
information (e.g. past values in stream-based data-flow programming) and it identifies abstract
_coeffect algebra_ that captures the essence of contextual information that can be nicely tracked
in a functional language.

I always thought that the most interesting thing about the thesis is that it gives people a nice way
to think about _context_ in a unified way. Sadly, the very theoretical presentation in the thesis
makes this quite hard for those who are not doing programming language theory.

To make it a bit easier to explore the ideas behind coeffects, I wrote a coeffect playground
that runs in a web browser and lets you learn about coeffects, play with two example context-aware languages,
run a couple of demos and learn more about how the theory works. Go [check it out now](http://tomasp.net/coeffects/)
or continue below to learn more about some interesting internals!

<a href="http://tomasp.net/coeffects/">
<img src="http://tomasp.net/blog/2016/coeffects-playground/screenshot.png" style="width:90%; margin:0px 5% 10px 5%" />
</a>
