using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_1;

public class CalcTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(22, 16)]
    public void When_calculating_cycle_length_then_calculated_correctly(uint value, int expectedCycleLength)
    {
        var calc = new SingleCalculation(value);
        var actualCycleLength = calc.CalcCycleLength();
        actualCycleLength.Should().Be(expectedCycleLength);
    }

    [Theory]
    [InlineData(1, 10, 20)]
    [InlineData(100, 200, 125)]
    [InlineData(201, 210, 89)]
    [InlineData(900, 1000, 174)]
    public void When_calculating_a_problem_row(uint firstValue, uint lastValue, int expectedMaxLength)
    {
        var calc = new ProblemCalc(new Input(firstValue, lastValue));
        var output = calc.Calculate();
        output.FirstValue.Should().Be(firstValue);
        output.LastValue.Should().Be(lastValue);
        output.MaxCycleLength.Should().Be(expectedMaxLength);
    }

    [Fact]
    public void When_calculating_the_whole_example_problem()
    {
        var problem = new Problem([
            "1 10",
            "100 200",
            "201 210",
            "900 1000",
        ]);
        var output = problem.Run();
        output.Should().Equal(
            "1 10 20",
            "100 200 125",
            "201 210 89",
            "900 1000 174"
        );
    }
}