> <p style="margin-bottom:5px">If trials of three or four simple cases have been made, and are found
> to agree with the results given by the engine, it is scarcely possible that there can be any error 
> (...).</p>
> <p style="margin-left:40px;text-align:right">Charles Babbage, On the mathematical powers of the calculating engine (1837)</p>

Anybody who has to do something with modern computers will agree that the above statement made by 
Charles Babbage about the analytical engine is understatement, to say the least. 

Computer programs do not always work as expected. There is a complex taxonomy of errors or 
[_miscomputations_](http://link.springer.com/article/10.1007/s13347-013-0112-0). The taxonomy of
possible errors is itself interesting. Syntax errors are quite obvious and are easy to catch,
say, missing semicolon. Logical errors are harder to find, but at least we know that something
went wrong. Say, our algorithm does not correctly sort some lists. There are also issues that
may or may not be actual errors. For example an algorithm in online store might suggest slightly 
suspicious products. Finally, we also have concurrency errors that happen very rarely in some 
very specific scenario.

If Babbage was right, we would just try three or four simple cases and eradicate all errors from
our programs, but eliminating errors is not so easy...