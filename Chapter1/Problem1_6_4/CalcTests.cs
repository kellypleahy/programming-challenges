using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_4;

public class CalcTests
{
    [Fact]
    public void Example_problem_from_book()
    {
        var prob = new Problem([
            "2 12345",
            "3 67890",
            "0 0",
        ]);
        var output = prob.Solve().ToArray();
        output.Should().Equal([
            "      --   --        -- ",
            "   |    |    | |  | |   ",
            "   |    |    | |  | |   ",
            "      --   --   --   -- ",
            "   | |       |    |    |",
            "   | |       |    |    |",
            "      --   --        -- ",
            "",
            " ---   ---   ---   ---   --- ",
            "|         | |   | |   | |   |",
            "|         | |   | |   | |   |",
            "|         | |   | |   | |   |",
            " ---         ---   ---       ",
            "|   |     | |   |     | |   |",
            "|   |     | |   |     | |   |",
            "|   |     | |   |     | |   |",
            " ---         ---   ---   --- ",
        ]);
    }
}