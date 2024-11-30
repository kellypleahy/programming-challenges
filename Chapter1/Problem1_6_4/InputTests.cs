using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_4;

public class InputTests
{
    [Fact]
    public void It_throws_on_completely_empty_input()
    {
        var action = () => Input.ReadInputs([]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Unexpected end of output.");
    }

    [Fact]
    public void It_handles_properly_formatted_empty_input()
    {
        Input.ReadInputs(["0 0"]).ToArray()
            .Should().BeEmpty();
    }

    [Fact]
    public void It_reads_input_lines_properly()
    {
        var result = Input.ReadInputs(["2 12345", "3 67890", "0 0"]).ToArray();
        result.Should().HaveCount(2);
        result[0].Should().Be(new Input(2, "12345"));
        result[1].Should().Be(new Input(3, "67890"));
    }

    [Fact]
    public void It_throws_when_missing_termination()
    {
        var action = () => Input.ReadInputs(["2 12345"]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Unexpected end of output.");
    }

    [Fact]
    public void It_throws_on_parse_errors_in_value()
    {
        var action = () => Input.ReadInputs(["2 abc"]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Input line was not in a correct format.");
    }

    [Fact]
    public void It_throws_on_parse_errors_in_size()
    {
        var action = () => Input.ReadInputs(["abc 12345"]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Input line was not in a correct format.");
    }

    [Fact]
    public void It_throws_on_too_many_inputs()
    {
        var action = () => Input.ReadInputs(["2 12345 789"]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Input line was not in a correct format.");
    }

    [Fact]
    public void It_throws_on_too_few_inputs()
    {
        var action = () => Input.ReadInputs(["2"]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Input line was not in a correct format.");
    }
}
