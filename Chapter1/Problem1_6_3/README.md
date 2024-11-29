# The Trip

This problem can be found [here](https://onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=29&page=show_problem&problem=1078)

# Discussion

Again, the problem statement is pretty simple.  There are a number of ways to approach this problem.  After some thought
I recognized that the minimum amount to transfer is the maximum amount required to move all people with "too much" money
to be down to the ceiling of the average, and to move all people with "too little" money up to the floor of the average.
This will cause all people to be within $0.01 of each other, and will move the minimum amount of money.

Take for example, the case where there are N people below the floor and M above the ceiling.  It might take less money 
to move some of the people above to the ceiling than some of the people below the floor, so we want to make sure we 
choose the amount which is greater between those two options.  If, for instance, we choose the lesser of the two amounts,
this means the other group will have at least one person that is "too far away" so we will have the wrong answer.

The solution to this problem can be mostly found in [`Trip.GetMinimumToTransfer()`](Trip.cs#L37).  The edge case for
trips with cost count == 0 should not be possible, but was included to protect against developer error.  Alternatively,
a debug assert could have been used.
