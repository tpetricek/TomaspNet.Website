(**

At [NDC Oslo 2016](http://ndcoslo.com/), I did a talk about some of the recent new F# projects
that are making data science with F# even nicer than it used to be. The talk covered a wider range
of topics, but one of the nice new thing I showed was the improved F# Interactive in the [Ionide
plugin for Atom](http://www.ionide.io/) and the integration with FsLab libraries that it provides.

In particular, with the latest version of [Ionide](http://ionide.io) for [Atom](http://atom.io)
and the latest version of [FsLab package](http://www.fslab.org), you can run code in F# Interactive
and you'll see resulting time series, data frames, matrices, vectors and charts as nicely pretty
printed HTML objects, right in the editor. The following shows some of the features (click on it
for a bigger version):

<a href="http://tomasp.net/blog/2016/fslab-ionide/prices.png">
<img src="http://tomasp.net/blog/2016/fslab-ionide/prices.png" style="margin:0px 2% 15px 2%;width:96%" />
</a>

In this post, I'll write about how the new Ionide and FsLab integration works, how you can use
it with your own libraries and also about some of the future plans. You can also learn more by
getting the FsLab package, or watching the NDC talk:

*)
