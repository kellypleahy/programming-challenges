using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_4;

public class DigitCreationTests
{
    [Theory]
    [InlineData('0')]
    [InlineData('1')]
    [InlineData('2')]
    [InlineData('3')]
    [InlineData('4')]
    [InlineData('5')]
    [InlineData('6')]
    [InlineData('7')]
    [InlineData('8')]
    [InlineData('9')]
    public void It_creates_digits_for_numbers(char charValue)
    {
        var action = () => Digit.For(3, charValue);
        action.Should().NotThrow();
    }

    [Theory]
    [InlineData('a')]
    [InlineData('#')]
    [InlineData('_')]
    [InlineData('A')]
    public void It_throws_for_invalid_digit_values(char charValue)
    {
        var action = () => Digit.For(3, charValue);
        action.Should().Throw<ArgumentException>().WithMessage("Invalid charValue");
    }
}