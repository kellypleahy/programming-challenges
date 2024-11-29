using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_3;

public class CalcTests
{
    [Fact]
    public void Minimum_for_empty_list_is_zero()
    {
        new Trip([]).GetMinimumToTransfer()
            .Should().Be(0);
    }

    [Fact]
    public void Minimum_for_list_of_one_is_zero()
    {
        new Trip([13]).GetMinimumToTransfer()
            .Should().Be(0);
    }

    [Fact]
    public void Trivial_two_items()
    {
        new Trip([13, 10]).GetMinimumToTransfer()
            .Should().Be(1.5m);
    }

    [Fact]
    public void Less_trivial_two_items()
    {
        new Trip([12.99m, 10]).GetMinimumToTransfer()
            .Should().Be(1.49m);
    }

    [Fact]
    public void Example1_from_book()
    {
        new Trip([10, 20, 30]).GetMinimumToTransfer()
            .Should().Be(10);
    }

    [Fact]
    public void Example2_from_book()
    {
        new Trip([15, 15.01m, 3, 3.01m]).GetMinimumToTransfer()
            .Should().Be(11.99m);
    }

    [Fact]
    public void Full_example_from_book()
    {
        var result = new Problem([
            "3",
            "10.00",
            "20.00",
            "30.00",
            "4",
            "15.00",
            "15.01",
            "3.00",
            "3.01",
            "0",
        ]).CalculateResults().ToArray();
        result.Should().Equal([
            "$10.00",
            "$11.99"
        ]);
    }
}
