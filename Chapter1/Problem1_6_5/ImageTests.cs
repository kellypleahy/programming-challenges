using FluentAssertions;
// ReSharper disable StringLiteralTypo

namespace programming_challenges.Chapter1.Problem1_6_5;

public class ImageTests
{
    [Fact]
    public void New_image_is_all_white()
    {
        var image = new Image(4, 6);
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "OOOO",
                "OOOO",
                "OOOO",
                "OOOO",
                "OOOO",
                "OOOO",
            ]);
    }

    [Fact]
    public void Fill_complete_image_when_white()
    {
        var image = new Image(4, 6);
        image.Fill(2, 2, 'X');
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "XXXX",
                "XXXX",
                "XXXX",
                "XXXX",
                "XXXX",
                "XXXX",
            ]);
    }

    [Fact]
    public void Fill_partial_image_when_mostly_white()
    {
        var image = new Image(4, 6);
        image.HorizontalSegment(1, 4, 3, 'U');
        image.Fill(3, 4, 'X');
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "OOOO",
                "OOOO",
                "UUUU",
                "XXXX",
                "XXXX",
                "XXXX",
            ]);
    }

    [Fact]
    public void Fill_middle_of_image_after_rectangle()
    {
        var image = new Image(4, 6);
        image.Rectangle(2, 1, 3, 4, 'U');
        image.Fill(2, 1, 'X');
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "OXXO",
                "OXXO",
                "OXXO",
                "OXXO",
                "OOOO",
                "OOOO",
            ]);
    }

    [Fact]
    public void VerticalSegment()
    {
        var image = new Image(4, 6);
        image.VerticalSegment(1, 3, 5, 'U');
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "OOOO",
                "OOOO",
                "UOOO",
                "UOOO",
                "UOOO",
                "OOOO",
            ]);
    }

    [Fact]
    public void Clear()
    {
        var image = new Image(4, 6);
        image.Fill(1, 1, 'X');
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "XXXX",
                "XXXX",
                "XXXX",
                "XXXX",
                "XXXX",
                "XXXX",
            ]);
        image.Clear();
        image.Save("image.bmp")
            .ToArray()
            .Should().Equal([
                "image.bmp",
                "OOOO",
                "OOOO",
                "OOOO",
                "OOOO",
                "OOOO",
                "OOOO",
            ]);
    }
}
