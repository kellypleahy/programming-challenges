# Graphical Editor

This problem can be found [here](https://onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=29&page=show_problem&problem=1208)

# Discussion

Woo, this was a fun one!  The code should be pretty straightforward to understand.  I parsed the input commands
into records that could be used to represent the commands more accurately (with correct types & such) 
(see [`Commands.cs`](Commands.cs)).

For the command parsing and dispatching, I heavily used C#'s pattern matching capabilities.  This makes the code
much easier to understand and write if you know the pattern matching support or come from a functional languages
background (see OCaml for instance).

For handling the image manipulation, I wrote an `Image` class with user-friendly arguments for each of the operations
that are consistent with the 1-based values provided by the API.  Internally, I convert to (i,j) which are positions
in the row-oriented data structure used internally (structured as such to make the `Save` operation easier to 
implement).  Most of the simple operations use `SetPixel` internally so they can *talk* in terms of (X, Y) rather than
(j = Y-1, i = X-1) coordinates.

Of course, the **hard** part of this code was the Fill operation.  For that I opted to use a tracking queue to keep
track of cells that I need to check, and a Set to keep track of the places I need to change color in the image.  I
implemented a record type called `Position` to handle the I/J stuff and the "find neighboring cells" behavior.
