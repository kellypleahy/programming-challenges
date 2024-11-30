using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_5;

public class PositionTests
{
    [Fact]
    public void Position_TopLeft_Neighbors()
    {
        new Position(0, 0).Neighbors(10, 10).ToArray()
            .Should().BeEquivalentTo([
                new Position(1, 0),
                new Position(0, 1),
            ]);
    }

    [Fact]
    public void Position_BottomRight_Neighbors()
    {
        new Position(9, 9).Neighbors(10, 10).ToArray()
            .Should().BeEquivalentTo([
                new Position(8, 9),
                new Position(9, 8),
            ]);
    }

    [Fact]
    public void Position_Middle_Neighbors()
    {
        new Position(4, 6).Neighbors(10, 10).ToArray()
            .Should().BeEquivalentTo([
                new Position(3, 6),
                new Position(5, 6),
                new Position(4, 7),
                new Position(4, 5),
            ]);
    }
}