TomaspNet Web site
==================

This repository contains the source code (and output in the `gh-pages` branch) for
the http://tomasp.net web site. The web site is powered by a Jekyll-like system written
in F#. The content is written in a mix of `html` files (migrated from the old version),
`fsx` and `md` files (using F# script files for source-code heavy literate blog posts
and Markdown for the rest).

The web site is using the following tools (or parts of them):

 * [F# Formatting](https://github.com/tpetricek/FSharp.Formatting) deals with Markdown and F# colorization
 * [RazorEngine](https://github.com/Antaris/RazorEngine) is used for templating and simle embedded C# code 
 * Some code that calls Razor engine from F# is based on [Tilde](https://github.com/aktowns/tilde) 
 
Remarks
-------

The source code for the processor (which generates the `gh-pages` content) can be found in [the `build.fsx` 
file](https://github.com/tpetricek/TomaspNet.Website/blob/master/tools/build.fsx) in `tools`. At the moment,
this is not very reusable tool (though it is well structured and should be easy to modify). If you're 
interested in using the system for your own blog, feel free to copy & edit! If you want to help me turn this
into a reusable tool, please get in touch!

License
-------

 * The source code (of all blog examples and the web site tool generator) is licensed under [**Apache 2.0**](http://www.apache.org/licenses/LICENSE-2.0.html)
 * The content (blog articles) are licensed under [**Creative Commons Attribution Share Alike**](http://creativecommons.org/licenses/by-sa/3.0/)
