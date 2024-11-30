using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_5;

public class InputParsingTests
{
    [Fact]
    public void Terminate()
    {
        var command = InputParser.ParseInput(["X"]).ToArray().First();
        command.Should().BeOfType<Terminate>();
    }

    [Fact]
    public void Save()
    {
        var command = InputParser.ParseInput(["S foo.bmp"]).ToArray().First();
        var save = command.Should().BeOfType<Save>().Subject;
        save.FileName.Should().Be("foo.bmp");
    }

    [Fact]
    public void Fill()
    {
        var command = InputParser.ParseInput(["F 12 15 W"]).ToArray().First();
        var fill = command.Should().BeOfType<Fill>().Subject;
        fill.X.Should().Be(12);
        fill.Y.Should().Be(15);
        fill.C.Should().Be('W');
    }

    [Fact]
    public void Rectangle()
    {
        var command = InputParser.ParseInput(["K 1 2 3 4 G"]).ToArray().First();
        var rectangle = command.Should().BeOfType<Rectangle>().Subject;
        rectangle.X1.Should().Be(1);
        rectangle.Y1.Should().Be(2);
        rectangle.X2.Should().Be(3);
        rectangle.Y2.Should().Be(4);
        rectangle.C.Should().Be('G');
    }

    [Fact]
    public void HorizontalSegment()
    {
        var command = InputParser.ParseInput(["H 1 3 4 Y"]).ToArray().First();
        var horizontalSegment = command.Should().BeOfType<HorizontalSegment>().Subject;
        horizontalSegment.X1.Should().Be(1);
        horizontalSegment.X2.Should().Be(3);
        horizontalSegment.Y.Should().Be(4);
        horizontalSegment.C.Should().Be('Y');
    }

    [Fact]
    public void VerticalSegment()
    {
        var command = InputParser.ParseInput(["V 1 2 3 U"]).ToArray().First();
        var verticalSegment = command.Should().BeOfType<VerticalSegment>().Subject;
        verticalSegment.X.Should().Be(1);
        verticalSegment.Y1.Should().Be(2);
        verticalSegment.Y2.Should().Be(3);
        verticalSegment.C.Should().Be('U');
    }

    [Fact]
    public void ColorPixel()
    {
        var command = InputParser.ParseInput(["L 3 4 B"]).ToArray().First();
        var colorPixel = command.Should().BeOfType<ColorPixel>().Subject;
        colorPixel.X.Should().Be(3);
        colorPixel.Y.Should().Be(4);
        colorPixel.C.Should().Be('B');
    }

    [Fact]
    public void Clear()
    {
        var command = InputParser.ParseInput(["C"]).ToArray().First();
        command.Should().BeOfType<ClearImage>();
    }

    [Fact]
    public void CreateImage()
    {
        var command = InputParser.ParseInput(["I 22 33"]).ToArray().First();
        var createImage = command.Should().BeOfType<CreateImage>().Subject;
        createImage.M.Should().Be(22);
        createImage.N.Should().Be(33);
    }

    [Theory]
    [InlineData("I")]
    [InlineData("I abc 33")]
    [InlineData("I 22 def")]
    [InlineData("I 22 33 extra")]
    [InlineData("C extra")]
    [InlineData("L")]
    [InlineData("L 3")]
    [InlineData("L 3 4")]
    [InlineData("L abc 4 B")]
    [InlineData("L 3 def B")]
    [InlineData("L 3 4 B extra")]
    [InlineData("V")]
    [InlineData("V 1")]
    [InlineData("V 1 2")]
    [InlineData("V 1 2 3")]
    [InlineData("V abc 2 3 W")]
    [InlineData("V 1 def 3 W")]
    [InlineData("V 1 2 ghi W")]
    [InlineData("V 1 2 3 W extra")]
    [InlineData("H")]
    [InlineData("H 1")]
    [InlineData("H 1 2")]
    [InlineData("H 1 2 3")]
    [InlineData("H abc 2 3 W")]
    [InlineData("H 1 def 3 W")]
    [InlineData("H 1 2 ghi W")]
    [InlineData("H 1 2 3 W extra")]
    [InlineData("K")]
    [InlineData("K 1")]
    [InlineData("K 1 2")]
    [InlineData("K 1 2 3")]
    [InlineData("K 1 2 3 4")]
    [InlineData("K abc 2 3 4 W")]
    [InlineData("K 1 def 3 4 W")]
    [InlineData("K 1 2 ghi 4 W")]
    [InlineData("K 1 2 3 uuu W")]
    [InlineData("K 1 2 3 4 W extra")]
    [InlineData("F")]
    [InlineData("F 3")]
    [InlineData("F 3 4")]
    [InlineData("F abc 4 B")]
    [InlineData("F 3 def B")]
    [InlineData("F 3 4 B extra")]
    [InlineData("S")]
    [InlineData("S foo.bmp extra")]
    [InlineData("X extra")]
    [InlineData("Unknown")]
    public void Invalid(string line)
    {
        InputParser.ParseInput([line]).ToArray().First()
            .Should().BeOfType<InvalidCommand>()
            .Subject.Line.Should().Be(line);
    }
}