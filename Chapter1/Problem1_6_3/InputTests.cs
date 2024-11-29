using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_3;

public class InputTests
{
    [Fact]
    public void When_reading_empty_input()
    {
        var trips = Trip.ReadFromInput(["0"]).ToArray();
        Assert.Empty(trips);
    }

    [Fact]
    public void When_reading_single_trip()
    {
        var trips = Trip.ReadFromInput([
            "2",
            "0.00",
            "10.00",
            "0"
        ]).ToArray();
        trips.Length.Should().Be(1);
        trips[0].Should().BeEquivalentTo(new Trip([0, 10]));
    }

    [Fact]
    public void When_reading_fails_due_do_missing_zero_at_end()
    {
        var action = () => Trip.ReadFromInput([
            "2",
            "0.00",
            "10.00",
        ]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("End of input reached unexpectedly.");
    }

    [Fact]
    public void When_reading_fails_due_to_not_enough_values()
    {
        var action = () => Trip.ReadFromInput([
            "2",
            "0.00",
        ]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("End of input reached unexpectedly.");
    }

    [Fact]
    public void When_reading_fails_for_bad_length_row()
    {
        var action = () => Trip.ReadFromInput([
            "abc",
        ]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Invalid cost count input line.");
    }

    [Fact]
    public void When_reading_fails_for_bad_value_row()
    {
        var action = () => Trip.ReadFromInput([
            "1",
            "abc",
            "0"
        ]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Invalid cost value input line.");
    }
}
