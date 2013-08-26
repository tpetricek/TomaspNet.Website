(**

Back in February, I attended the annual MVP summit - an [event organized by Microsoft
for MVPs](http://www.2013mvpsummit.com/about). I used that opportunity to also visit
Boston and New York and do two F# talks and to record a [Channel9 lecutre about type
providers][love-data].
Despite all the _other activities_ (often involving pubs, other F# people and long 
sleeping in the mornings), I also managed to come to some talks!

<div style="margin-left:auto;margin-right:auto;width:379px;margin-top:10px;margin-bottom:20px;">
<img src="http://tomasp.net/articles/csharp-async-gotchas/async-clinic.png" style="width:379px;" />
</div>

One (non-NDA) talk was the [Async Clinic][async-clinic] talk about the new `async` and `await` keywords 
in C# 5.0. Lucian and Stephen talked about common problems that C# developers face when 
writing asynchronous programs. In this blog post, I'll look at some of the problems from 
the F# perspective. The talk was quite lively, and someone recorded the reaction of the 
F# part of the audience as follows...

  [love-data]: http://channel9.msdn.com/posts/Tomas-Petricek-How-F-Learned-to-Stop-Worrying-and-Love-the-Data "Tomas Petricek (Channel 9): How F# Learned to Stop Worrying and Love the Data"
  [async-clinic]: http://blogs.msdn.com/b/pfxteam/archive/2013/02/20/mvp-summit-presentation-on-async.aspx "Lucian Wischik, Stephen Toub: Async Clinic"

*)