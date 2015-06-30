@{
  Layout = "post";
  Title = "Miscomputation: Learning to live with errors [DRAFT]";
  Tags = "philosophy, research";
  Date = "2015-06-29T15:46:36.6659544+01:00";
  Description = "What is the definition of type? Having a clear and precise answer to this question would " +
    "avoid many misunderstandings but it would hurt science, 'hamper the growth of knowledge' and " +
    "'deflect the course of investigation into narrow channels of things already understood'.";
  Image = "http://tomasp.net/blog/2015/against-types/paper-square.png";
}

Miscomputation: Learning to live with errors
============================================

> <p style="margin-bottom:5px">If trials of three or four simple cases have been made, and are found
> to agree with the results given by the engine, it is scarcely possible that there can be any error 
> (...).</p>
> <p style="text-align:right">Charles Babbage, On the mathematical powers of the calculating engine (1837)</p>

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
our programs, but eliminating errors is not so easy. In retrospect, it is quite interesting to
see how long it took early computer engineers to realise that coding (i.e. translating 
mathematical algorithm to program code) errors are a problem:

> <p style="margin-bottom:5px">Errors in coding were only gradually recognized to be a signiﬁcant 
> problem: a typical early comment was that of Miller [circa 1949], who wrote that such errors, 
> along with hardware faults, could be "expected, in time, to become infrequent".</p>
> <p style="text-align:right">Mark Priestley, Science of Operations (2011)</p>

Since coding errors were recoginzed as a significant problem, programmers spent over 50 years 
of living with errors and finding different practical strategies for dealing with them. In this 
blog post, I want to look at four of the strategies. Quite curiously, there is a very wide range.

Introducing the heroes
----------------------

 - _"Errors are a curse and must be avoided at all costs!"_ says our first hero. _"If it contains
   an error, you cannot even call it a program!"_ This sounds a bit idealistic, but our hero hopes
   that dependently typed languages will make this reality.   

 - _"But how do you know it works?"_ comes a reply from our second doubtful hero. _"You need to
   write a specification, or tests!"_ And our second hero becomes even more extreme _"In fact,
   I will only write new code to fix errors revealed by tests!"_

 - As our first two heroes start arguing, a third (a bit weird) hero comes in saying _"You both 
   really believe you can eliminate all errors?"_ Our two heroes start looking puzzled and the
   newcomer adds _"Just let it crash!"_ Our first two heroes burst into laughter but start feeling
   uneasy as the third hero continues looking like she _knows something_.

 - As if the situation was not bad enough already, a new hero appears (wearing cool sunglasses)
   _"I like errors. Errors are fun!"_ Everyone else steps back a bit as our four hero 
   continues _"How do you even tell what is an error? Just watch what's going on and you might 
   learn something new!"_

Error as a curse: Avoiding errors at all costs
----------------------------------------------

Many software developers share some of the thoughts with our first hero. Wouldn't it be nice
if we could _never_ made errors and avoid miscomputations altogether and all software we created
was fully correct? As we saw in an earlier quote, people only realized that coding errors is
a significant problem in 1950s. In 1960s, the _Alogl research programme_ first advocated using
formal logic to avoid errors:

> <p style="margin-bottom:5px">
> One of the goals of the Algol research programme was to utilize the resources of logic to 
> increase the conﬁdence (...) in the correctness of a program. As McCarthy had put it, "[i]nstead 
> of debugging a program, one should prove that it meets its specifications (...)".</p>
> <p style="text-align:right">Mark Priestley, Science of Operations (2011)</p>

Modern statically-typed programming languages follow the same basic approach. In their case,
the "resources of logic" are concretely instantiated in type systems that rule out some of
the errors. This is captured by the slogan _"well-typed programs do not go wrong"_ that was 
stated by Robin Milner in 1978 (as the _Semantic Soundness Theorem_).

Followers of Algol research programme (and statically typed languages) aim to create correct
programs that never miscompute. When there is an error, the compiler will reject the program.
However, types used today can only specify some of the program properties that we need to check,
and so the Algol camp is finding ways for checking stronger properties.

, people are finding ways to express more

Followers of this approach aim to create correct programs that never miscompute. This is assisted 
by tools that rule out increa-sing number of errors during the compilation of the program.

And we should go even further [POPLMark challenge]:

> How close are we to a world in which mechanically veriﬁed software is commonplace? A world in which theorem proving technology is used routinely by both software developers and programming language researchers alike? 

And the same thing in the industry;

> We would all like to have programs check that our programs are correct. Due in no small part to some bold but unfulfilled promises in the history of computer science, today most people who write software, practitioners and academics alike, assume that the costs of formal program verification outweigh the benefits. The purpose of this book is to convince you that the technology of program verification is mature enough today that it makes sense to use it in a support role in many kinds of research projects in computer science. 

Error as a progress: Test-driven development
--------------------------------------------

A different approach to eliminating errors has been developed in dynamically-typed languages (which have no compile-time checking). The idea of test-driven development (TDD) is to write automated tests that detect certain errors. 

However, tests do not serve only as a mechanism for avoiding errors. TDD uses them (and miscomputation) as the driving force behind development:

> In TDD, we 1) Write new code only if an automated test has failed 2) Eliminate duplication. 

According to the first point, we should first produce an isolated miscomputation and then write code to remove it. This leads to the Red-Green-Refactor mantra of TDD:

> 1.	Red – write a little test that doesn't work (...).
> 2.	Green – Make the test work quickly, committing whatever sins necessary in the process.
> 3.	Refactor – Eliminate all of the duplication (...). 

In TDD we start by deliberately producing a miscomputation. We write a failing test for a behaviour that is not yet supported and then implement the functionality. In this way, TDD incor-porates miscomputation as a part of the development cycle.

Error as the unavoidable: Let it crash
--------------------------------------

Although different, both approaches discussed so far aim to eliminate miscomputation from completed running programs. The concurrent language Erlang takes a different attitude characterised by the slogan “let it crash”. In the Erlang mind-set, an error refers to a situation where we do not have enough information to proceed:

There are two kinds of things:

> For programming purpose we can say that: 
> - exceptions occur when the run-time system does not know what to do. 
> - errors occur when the programmer doesn’t know what to do. 

TODO

> Errors occur when the programmer does not know what to do. Programmers are supposed to follow speciﬁcations, but often the speciﬁcation does not say what to do and therefore the programmer does not know what to do. 

In Erlang, errors are expected and programmers have a strategy for dealing with them:

> What kind of code must the programmer write when they ﬁnd an error? The philosophy is let some other process ﬁx the error, but what does this mean for their code? The answer is let it crash.

Erlang has a sophisticated supervision model – a supervisor process typically restarts the worker process (and logs the details of the miscomputation), so that the worker can continue performing other valid operations. 

Error as an inspiration: Live coding
------------------------------------

Very different than the first approach:

> Smalltalk appears to represent an approach to the design of programming languages that is quite different from what was familiar in the Algol research programme 

It is more about interaction (with the environment):

> Programming was not thought of as the task of constructing a linguistic entity, but rather as a process of working interactively with the semantic representation of the program, using text simply as one possible interface 

TODO

Miscomputation takes yet another form when we treat compu-tation as an interaction. The first programming environment that used this style was Smalltalk in 1970s. More recent work includes live coding environments for performing music. Our metaphors for miscomputation change accordingly: 

> An error in the performance of classical music occurs when the performer plays a note that is not written on the page. In musical genres that are not notated so closely (...), there are no wrong notes – only notes that are more or less appropriate to the performance. 

Live coding brings the same ideas to programming:

> [Live coders] may well prefer to accept the results of an imperfect execution. [They] might perhaps compensate for an unexpected result by manual intervention (like a guitarist lifting his finger from a discordant note), or even accept the result as a serendipitous alternative to the original note. 

It is easy to understand this approach in music, but that is just one of the domains. In Smalltalk, live coding can be used to interactively change a running system in response to errors. The interesting point is that making miscomputation apparent (we hear a dissonant note) enables live coder to quickly react and correct the behaviour.

Conclusions
-----------

Perhaps the most interesting message from the talk is that miscomputation does not always have to be fully avoided. Avoiding miscomputation at all cost (through formal proofs or thorough testing) is the most common technique, but there are interesting alternatives that embrace miscomputation and accept it as an ordinary part of software development, software execution or even observable software behaviour.
