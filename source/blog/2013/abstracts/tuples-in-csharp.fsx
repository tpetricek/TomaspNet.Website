(**
In a [recent StackOverflow question](http://stackoverflow.com/questions/18718232/when-should-i-write-my-functions-in-curried-form/18721711)
the poster asked about the difference between _tupled_ and _curried_ form of a function in F#. 
In F#, you can use pattern matching to easily define a function that takes a tuple as an argument.
For example, the poster's function was a simple calculation that multiplies the number 
of units sold _n_ by the price _p_:
*)

let salesTuple (price, count) = price * (float count)

(**
The function takes a single argument of type `Tuple<float, int>` (or, using the nicer F# notation
`float * int`) and immediately decomposes it into two variables, `price` and `count`. The other
alternative is to write a function in the _curried_ form:
*)

let salesCurried price count = price * (float count)

(**
Here, we get a function of type `float -> int -> float`. Usually, you can read this just as a 
function that takes `float` and `int` and returns `float`. However, you can also use _partial
function application_ and call the function with just a single argument - if the price of
an apple is $1.20, we can write `salesCurried 1.20` to get a _new_ function that takes just
`int` and gives us the price of specified number of apples. The poster's question was:

> So when I want to implement a function that would have taken _n > 1_ arguments, 
> should I for example always use a curried function in F# (...)? Or should I take 
> the simple route and use regular function with an n-tuple and curry later on 
> if necessary?

You can see [my answer on StackOverflow](http://stackoverflow.com/questions/18718232/when-should-i-write-my-functions-in-curried-form/18721711#18721711).
The point of this short introduction was that the question inspired me to think about how
the world looks from the C# perspective...

*)