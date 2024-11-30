using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_4;

public class FormattingTests
{
    [Fact]
    public void It_formats_1_correctly_size_1()
    {
        var digit = new Digit(1, 1);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            "   ",
            "  |",
            "   ",
            "  |",
            "   ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_1_correctly_size_3()
    {
        var digit = new Digit(3, 1);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            "     ",
            "    |",
            "    |",
            "    |",
            "     ",
            "    |",
            "    |",
            "    |",
            "     ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_2_correctly_size_1()
    {
        var digit = new Digit(1, 2);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "  |",
            " - ",
            "|  ",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_2_correctly_size_3()
    {
        var digit = new Digit(3, 2);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "    |",
            "    |",
            "    |",
            " --- ",
            "|    ",
            "|    ",
            "|    ",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_3_correctly_size_1()
    {
        var digit = new Digit(1, 3);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "  |",
            " - ",
            "  |",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_3_correctly_size_3()
    {
        var digit = new Digit(3, 3);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "    |",
            "    |",
            "    |",
            " --- ",
            "    |",
            "    |",
            "    |",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_4_correctly_size_1()
    {
        var digit = new Digit(1, 4);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            "   ",
            "| |",
            " - ",
            "  |",
            "   ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_4_correctly_size_3()
    {
        var digit = new Digit(3, 4);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            "     ",
            "|   |",
            "|   |",
            "|   |",
            " --- ",
            "    |",
            "    |",
            "    |",
            "     ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_5_correctly_size_1()
    {
        var digit = new Digit(1, 5);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "|  ",
            " - ",
            "  |",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_5_correctly_size_3()
    {
        var digit = new Digit(3, 5);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "|    ",
            "|    ",
            "|    ",
            " --- ",
            "    |",
            "    |",
            "    |",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_6_correctly_size_1()
    {
        var digit = new Digit(1, 6);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "|  ",
            " - ",
            "| |",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_6_correctly_size_3()
    {
        var digit = new Digit(3, 6);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "|    ",
            "|    ",
            "|    ",
            " --- ",
            "|   |",
            "|   |",
            "|   |",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_7_correctly_size_1()
    {
        var digit = new Digit(1, 7);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "  |",
            "   ",
            "  |",
            "   ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_7_correctly_size_3()
    {
        var digit = new Digit(3, 7);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "    |",
            "    |",
            "    |",
            "     ",
            "    |",
            "    |",
            "    |",
            "     ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_8_correctly_size_1()
    {
        var digit = new Digit(1, 8);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "| |",
            " - ",
            "| |",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_8_correctly_size_3()
    {
        var digit = new Digit(3, 8);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "|   |",
            "|   |",
            "|   |",
            " --- ",
            "|   |",
            "|   |",
            "|   |",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_9_correctly_size_1()
    {
        var digit = new Digit(1, 9);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "| |",
            " - ",
            "  |",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_9_correctly_size_3()
    {
        var digit = new Digit(3, 9);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "|   |",
            "|   |",
            "|   |",
            " --- ",
            "    |",
            "    |",
            "    |",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_0_correctly_size_1()
    {
        var digit = new Digit(1, 0);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " - ",
            "| |",
            "   ",
            "| |",
            " - ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void It_formats_0_correctly_size_3()
    {
        var digit = new Digit(3, 0);
        var rows = digit.FormatRows()
            .Select(x => x.ToArray())
            .ToArray();

        string[] pattern =
        [
            " --- ",
            "|   |",
            "|   |",
            "|   |",
            "     ",
            "|   |",
            "|   |",
            "|   |",
            " --- ",
        ];
        var expected = pattern.Select(x => x.ToCharArray()).ToArray();

        rows.Should().BeEquivalentTo(expected);
    }
}
