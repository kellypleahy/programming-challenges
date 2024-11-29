# Minesweeper

This problem can be found [here](https://onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=29&page=show_problem&problem=1130)

# Discussion

The problem statement is pretty simple, we need to convert the minesweeper input fields
into an output that is the locations of the mines and the number of mines "near" each
cell that doesn't have a mine (adjacent cells in any direction, including diagonal).

The implementation starts with parsing the input of the fields, and processes the fields
one by one into outputs using enumerables to understand the cells that need to be checked
in the region (environment) of the cell in question.  See the _RawEnvironment and 
_UsableEnvironment functions for details of how we decide which row/column combinations
to check.  The environments are then checked for bombs and those bombs are counted for
each cell.

If performance were a major concern, another approach would be to set up an initial grid 
of counts and walk the field, incrementing the count of each adjacent cell when we encounter
a bomb.  This would be unlikely to produce a substantial difference in performance unless
working with an enormous grid, and would make the code a bit harder to understand, but 
is a path that could be taken if needed.  The expected difference would be that instead
of searching 9 cells for bombs for each row and column (i.e. 9 x R x C ops), we could just
do 9 adds for each (r,c) with a bomb, which would be a search of R x C plus B x 9 operations.
