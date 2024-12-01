using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_6;

public class ProblemTests
{
    [Fact]
    public void Simple_halt_case()
    {
        new Problem(["1", "", "100"]).Run().ToArray().Should().Equal(["1"]);
    }

    [Fact]
    public void Simple_few_cases_case()
    {
        new Problem(["3", "", "100", "", "323", "100", "", "555", "323", "100"]).Run().ToArray()
            .Should().Equal(["1", "", "2", "", "3"]);
    }

    [Fact]
    public void Book_example()
    {
        var problem = new Problem([
            "1",
            "",
            "299",
            "492",
            "495",
            "399",
            "492",
            "495",
            "399",
            "283",
            "279",
            "689",
            "078",
            "100",
            "000",
            "000",
            "000",
        ]);
        problem.Run().ToArray().Should().Equal(["16"]);
    }
}