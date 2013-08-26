(**
One of the less frequently advertised new features in F# 3.0 is the _query syntax_.
It is an extension that makes it possible to add custom operations in an F#
computation expression. The standard `query { .. }` computation uses this to define
operations such as sorting (`sortBy` and `sortByDescending`) or operations for taking
and skipping elements (`take`, `takeWhile`, ...). For example, you can write:
*)

query { for x in 1 .. 10 do
        take 3
        sortByDescending x }

(**
In this article I'll use the same notation for processing trees using the _zipper_
pattern. I'll show how to define a computation that allows you to traverse a tree
and perform transformations on (parts) of the tree. For example, we'll be able to 
say "Go to the left sub-tree, multiply all values by 2. Then go back and to the
right sub-tree and divide all values by 2" as follows:
*)

(*** include:final-example ***)

(**
This example behaves quite differently to the usual `query` computation. It mostly
relies on custom operations like `left`, `right` and `up` that allow us to navigate
through a tree (descend along the left or right sub-tree, go back to the parent node). 
The only operation that _does something_ is the `map` operation which transforms the
current sub-tree.

This was just a brief introduction to what is possible, so let's take a detailed look
at how this works...
*)

(*** hide ***)
type Tree<'T> = 
  | Node of Tree<'T> * Tree<'T>
  | Leaf of 'T
  override x.ToString() = (*[omit:(...)]*)
    match x with
    | Node(l, r) -> sprintf "(%O, %O)" l r
    | Leaf v -> sprintf "%O" v(*[/omit]*)

type Path<'T> = 
  | Top 
  | Left of Path<'T> * Tree<'T>
  | Right of Path<'T> * Tree<'T>
  override x.ToString() = (*[omit:(...)]*)
    match x with
    | Top -> "T"
    | Left(p, t) -> sprintf "L(%O, %O)" p t
    | Right(p, t) -> sprintf "R(%O, %O)" p t(*[/omit]*)

type TreeZipper<'T> = 
  | TZ of Tree<'T> * Path<'T>
  override x.ToString() = (*[omit:(...)]*)
    let (TZ(t, p)) = x in sprintf "%O [%O]" t p(*[/omit]*)

/// Navigates to the left sub-tree
let left = function
  | TZ(Leaf _, _) -> failwith "cannot go left"
  | TZ(Node(l, r), p) -> TZ(l, Left(p, r))

/// Navigates to the right sub-tree
let right = function
  | TZ(Leaf _, _) -> failwith "cannot go right"
  | TZ(Node(l, r), p) -> TZ(r, Right(p, l))

/// Gets the value at the current position
let current = function
  | TZ(Leaf x, _) -> x
  | _ -> failwith "cannot get current"

// Navigate to the parent node
let up = function
  | TZ(l, Left(p, r))
  | TZ(r, Right(p, l)) -> TZ(Node(l, r), p)
  | TZ(_, Top) -> failwith "cannot go up"

// Navigate to the root of the tree
let rec top = function
  | TZ(_, Top) as t -> t
  | tz -> top (up tz)

/// Build tree zipper with singleton tree
let unit v = TZ(Leaf v, Top)

/// Transform leaves in the current sub-tree of 'treeZip'
/// into other trees using the provided function 'f'
let bindSub f treeZip = 
  let rec bindT = function
    | Leaf x -> let (TZ(t, _)) = top (f x) in t
    | Node(l, r) -> Node(bindT l, bindT r)
  let (TZ(current, path)) = treeZip
  TZ(bindT current, path)

type TreeZipperBuilder() = 
  /// Enables the 'for x in xs do ..' syntax
  member x.For(tz:TreeZipper<'T>, f) : TreeZipper<'T> = bindSub f tz
  /// Enables the 'yield x' syntax
  member x.Yield(v) = unit v

/// Global instance of the computation builder
let tree = TreeZipperBuilder()

type TreeZipperBuilder with
  // Operations for navigation through the tree
  [<CustomOperation("left", MaintainsVariableSpace=true)>]
  member x.Left(tz) = left tz
  [<CustomOperation("right", MaintainsVariableSpace=true)>]
  member x.Right(tz) = right tz
  [<CustomOperation("up", MaintainsVariableSpace=true)>]
  member x.Up(tz) = up tz
  [<CustomOperation("top", MaintainsVariableSpace=true)>]
  member x.Top(tz) = top tz

  /// Extracts the current value and returns it
  [<CustomOperation("current", MaintainsVariableSpace=false)>]
  member x.Current(tz) = current tz

  /// Transform the current sub-tree using 'f'
  [<CustomOperation("map", MaintainsVariableSpace=true)>]
  member x.Select(tz, [<ProjectionParameter>] f) = bindSub (f >> unit) tz


(*** define:final-example ***)
tree { for x in sample do
       left 
       map (x * 2) 
       up
       right
       map (x / 2) 
       top }