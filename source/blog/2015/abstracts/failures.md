> <img src="http://tomasp.net/blog/2015/failures/babbage.png" style="float:right;width:110px;margin:5px 0px 10px 20px" />
>
> <p style="margin-bottom:5px">If trials of three or four simple cases have been made, and are found
> to agree with the results given by the engine, it is scarcely possible that there can be any error
> (...).</p>
> <p style="text-align:right">Charles Babbage, On the mathematical<br /> powers of the calculating engine (1837)</p>

Anybody who has something to do with modern computers will agree that the above statement made by
Charles Babbage about the analytical engine is understatement, to say the least.

Computer programs do not always work as expected. There is a complex taxonomy of errors or
[_miscomputations_](http://link.springer.com/article/10.1007/s13347-013-0112-0). The taxonomy of
possible errors is itself interesting. Syntax errors like missing semicolons are quite obvious
and are easy to catch. Logical errors are harder to find, but at least we know that something
went wrong. For example, our algorithm does not correctly sort some lists. There are also issues that
may or may not be actual errors. For example an algorithm in online store might suggest slightly
suspicious products. Finally, we also have concurrency errors that happen very rarely in some
very specific scenario.

If Babbage was right, we would just try three or four simple cases and eradicate all errors from
our programs, but eliminating errors is not so easy. In retrospect, it is quite interesting to
see how long it took early computer engineers to realise that coding (i.e. translating
mathematical algorithm to program code) errors are a problem:

> <p style="margin-bottom:5px">Errors in coding were only gradually recognized to be a signiﬁcant
> problem: a typical early comment was that of Miller [circa 1949], who wrote that such errors,
> along with hardware faults, could be "expected, in time, to become infrequent".</p>
> <p style="text-align:right">Mark Priestley, Science of Operations (2011)</p>

We _mostly_ got rid of hardware faults, but coding errors are still here. Programmers spent
over 50 years finding different practical strategies for dealing with them. In this
blog post, I want to look at four of the strategies. Quite curiously, there is a very wide range.
