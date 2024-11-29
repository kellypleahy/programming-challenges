# The 3n + 1 problem

This problem can be found [here](https://onlinejudge.org/index.php?option=com_onlinejudge&Itemid=8&category=3&page=show_problem&problem=36)

# Discussion

[`Problem`](Problem.cs#L3) is the main entry point to the algorithm.  It's just a thin wrapper around the 
input/output processing for the algorithm and calls the [`Input`](Input.cs#L5), [`Output`](Output.cs#L3), 
and [`ProblemCalc`](ProblemCalc.cs#L3) classes to do its work.

Each `Input` represents an input line from the caller (presumed to be something like stdin, 
though we pretend an array of `string` for convenience), and is parsed using static constructor
pattern.

We purposely illustrate how to solve this problem with a minimal memory footprint using 
`IEnumerable<T>` and enumerables throughout the solution, such that theoretically this 
algorithm could run on any size input.  Similarly, the 
[`SingleCalculation`](SingleCalculation.cs#L3) class has a minimal memory footprint 
doing all its work in a loop.  This could alternatively have been done (perhaps in an 
even more readable way) by using an enumerable (iterator) as well and then just using 
`Enumerable<T>.Count()` to get the chain lengths, but I felt this would be a bit opaque
and harder to read.

The **interesting** tests can be found in `CalcTests.cs`, especially the 
[`When_calculating_the_whole_example_problem`](CalcTests.cs#L33) test.
