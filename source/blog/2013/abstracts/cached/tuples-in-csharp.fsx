<p>In a <a href="http://stackoverflow.com/questions/18718232/when-should-i-write-my-functions-in-curried-form/18721711">recent StackOverflow question</a>
the poster asked about the difference between <em>tupled</em> and <em>curried</em> form of a function in F#. 
In F#, you can use pattern matching to easily define a function that takes a tuple as an argument.
For example, the poster's function was a simple calculation that multiplies the number 
of units sold <em>n</em> by the price <em>p</em>:</p>
<pre class="fssnip">
<span class="l">1: </span><span class="k">let</span> <span onmouseout="hideTip(event, 'abs159_1', 1)" onmouseover="showTip(event, 'abs159_1', 1)" class="i">salesTuple</span> (<span onmouseout="hideTip(event, 'abs159_2', 2)" onmouseover="showTip(event, 'abs159_2', 2)" class="i">price</span>, <span onmouseout="hideTip(event, 'abs159_3', 3)" onmouseover="showTip(event, 'abs159_3', 3)" class="i">count</span>) <span class="o">=</span> <span onmouseout="hideTip(event, 'abs159_2', 4)" onmouseover="showTip(event, 'abs159_2', 4)" class="i">price</span> <span class="o">*</span> (<span onmouseout="hideTip(event, 'abs159_4', 5)" onmouseover="showTip(event, 'abs159_4', 5)" class="i">float</span> <span onmouseout="hideTip(event, 'abs159_3', 6)" onmouseover="showTip(event, 'abs159_3', 6)" class="i">count</span>)</pre>
<p>The function takes a single argument of type <code>Tuple&lt;float, int&gt;</code> (or, using the nicer F# notation
<code>float * int</code>) and immediately decomposes it into two variables, <code>price</code> and <code>count</code>. The other
alternative is to write a function in the <em>curried</em> form:</p>
<pre class="fssnip">
<span class="l">1: </span><span class="k">let</span> <span onmouseout="hideTip(event, 'abs159_5', 7)" onmouseover="showTip(event, 'abs159_5', 7)" class="i">salesCurried</span> <span onmouseout="hideTip(event, 'abs159_2', 8)" onmouseover="showTip(event, 'abs159_2', 8)" class="i">price</span> <span onmouseout="hideTip(event, 'abs159_3', 9)" onmouseover="showTip(event, 'abs159_3', 9)" class="i">count</span> <span class="o">=</span> <span onmouseout="hideTip(event, 'abs159_2', 10)" onmouseover="showTip(event, 'abs159_2', 10)" class="i">price</span> <span class="o">*</span> (<span onmouseout="hideTip(event, 'abs159_4', 11)" onmouseover="showTip(event, 'abs159_4', 11)" class="i">float</span> <span onmouseout="hideTip(event, 'abs159_3', 12)" onmouseover="showTip(event, 'abs159_3', 12)" class="i">count</span>)</pre>
<p>Here, we get a function of type <code>float -&gt; int -&gt; float</code>. Usually, you can read this just as a 
function that takes <code>float</code> and <code>int</code> and returns <code>float</code>. However, you can also use <em>partial
function application</em> and call the function with just a single argument - if the price of
an apple is $1.20, we can write <code>salesCurried 1.20</code> to get a <em>new</em> function that takes just
<code>int</code> and gives us the price of specified number of apples. The poster's question was:</p>

<blockquote>
  <p>So when I want to implement a function that would have taken <em>n > 1</em> arguments, 
should I for example always use a curried function in F# (...)? Or should I take 
the simple route and use regular function with an n-tuple and curry later on 
if necessary?</p>
</blockquote>

<p>You can see <a href="http://stackoverflow.com/questions/18718232/when-should-i-write-my-functions-in-curried-form/18721711#18721711">my answer on StackOverflow</a>.
The point of this short introduction was that the question inspired me to think about how
the world looks from the C# perspective...</p>

<div class="tip" id="abs159_1">val salesTuple : price:float * count:int -&gt; float<br /><br />Full name: Tuples-in-csharp_.salesTuple</div>
<div class="tip" id="abs159_2">val price : float</div>
<div class="tip" id="abs159_3">val count : int</div>
<div class="tip" id="abs159_4">Multiple items<br />val float : value:&#39;T -&gt; float (requires member op_Explicit)<br /><br />Full name: Microsoft.FSharp.Core.Operators.float<br /><br />--------------------<br />type float = System.Double<br /><br />Full name: Microsoft.FSharp.Core.float<br /><br />--------------------<br />type float&lt;&#39;Measure&gt; = float<br /><br />Full name: Microsoft.FSharp.Core.float&lt;_&gt;</div>
<div class="tip" id="abs159_5">val salesCurried : price:float -&gt; count:int -&gt; float<br /><br />Full name: Tuples-in-csharp_.salesCurried</div>
