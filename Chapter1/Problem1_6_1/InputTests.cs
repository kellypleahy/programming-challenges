using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_1;

public class InputTests
{
    [Fact]
    public void When_parsing_input_valid_input_is_matched()
    {
        string[] input = ["1 2", "1 9", "3 7", "4 1000000", "1 999999"];
        var inputs = Input.ParseMultiple(input).ToArray();
        inputs.Should().Equal(
            new Input(1, 2),
            new Input(1, 9),
            new Input(3, 7),
            new Input(4, 1000000),
            new Input(1, 999999)
        );
    }

    [Theory]
    [InlineData("1 2", "3")]
    [InlineData("1 2", "3 a")]
    [InlineData("1 2", "3 -4")]
    [InlineData("1 2", "u")]
    [InlineData("1 2", "")]
    public void When_parsing_invalid_input_missing_items(params string[] input)
    {
        var action = () => Input.ParseMultiple(input).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("* two valid non-negative integers.");
    }
}