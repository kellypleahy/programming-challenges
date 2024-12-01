using FluentAssertions;

namespace programming_challenges.Chapter2.Problem2_8_1;

public class ProblemTests
{
    [Fact]
    public void Example_from_book()
    {
        new Problem([
            "4 1 4 2 3",
            "5 1 4 2 -1 6",
        ]).Run().ToArray().Should().Equal([
            "Jolly",
            "Not jolly",
        ]);
    }
}