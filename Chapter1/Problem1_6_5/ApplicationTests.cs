using FluentAssertions;
// ReSharper disable StringLiteralTypo

namespace programming_challenges.Chapter1.Problem1_6_5;

public class ApplicationTests
{
    [Fact]
    public void Example_from_book()
    {
        var application = new Application();
        var result = application.ProcessInput([
            "I 5 6",
            "L 2 3 A",
            "S one.bmp",
            "G 2 3 J",
            "F 3 3 J",
            "V 2 3 4 W",
            "H 3 4 2 Z",
            "S two.bmp",
            "X",
        ]).ToArray();

        result.Should().Equal([
            "one.bmp",
            "OOOOO",
            "OOOOO",
            "OAOOO",
            "OOOOO",
            "OOOOO",
            "OOOOO",
            "two.bmp",
            "JJJJJ",
            "JJZZJ",
            "JWJJJ",
            "JWJJJ",
            "JJJJJ",
            "JJJJJ",
        ]);
    }
}
