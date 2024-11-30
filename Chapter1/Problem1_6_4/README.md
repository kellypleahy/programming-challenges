# LC-Display

This problem can be found [here](https://onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=29&page=show_problem&problem=647)

# Discussion

Hmm... where to begin.  This one has a lot of code, but mostly because I didn't want to be too obtuse with the design.
It could have been done in a single small program, but doing so would make it very hard to understand.

The key points are:
1. `Digit` handles rendering a single digit with a specific `size` and `value` to a set of 'lines'.
2. `OutputBuffer` handles initializing a buffer for use when printing multiple-digit numbers, including inter-digit 
   spacing and initialization to blanks.
3. `Printer` handles turning a string of digit characters (`'0' .. '9'`) into lines that can be printed to the output.
4. `Problem` puts the whole thing together to print multiple `Input` tuples to a set of output lines with inter-`Input` 
   spacing.

A few things to note...  The digits themselves are really made up of a few things:
1. a pattern for the top, middle, and bottom rows that are fixed size.  The 'ends' of these lines are always spaces.
2. a pattern for the 'top section' and 'bottom section' of the number.  The 'ends' of these are the only things that 
   aren't spaces, so I only need to keep track of the 'left' and 'right' parts of these lines.

Another alternative could have been to store each number pattern in a 3 x 5 grid and just repeat the 2nd and 4th lines
and the 2nd column of the pattern as appropriate.  This is probably more efficient from a memory perspective and is 
likely what would be done if I were designing a font to represent these digits.  However, this would make the code
even more obscure and hard to read, so I opted for the pattern mechanism above.
