using FluentAssertions;

namespace programming_challenges.Chapter2.Problem2_8_2;

public class ProblemTests
{
    [Fact]
    public void Example_from_book()
    {
        var prob = new Problem([
            "2H 3D 5S 9C KD 2C 3H 4S 8C AH",
            "2H 4S 4C 2D 4H 2S 8S AS QS 3S",
            "2H 3D 5S 9C KD 2C 3H 4S 8C KH",
            "2H 3D 5S 9C KD 2H 3H 5C 9S KH",
        ]);
        prob.Run().ToArray().Should().Equal([
            "White wins.",
            "Black wins.",
            "Black wins.",
            "Tie.",
        ]);
    }
}