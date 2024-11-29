using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_2;

public class FieldTests
{
    [Fact]
    public void CanParseEmptyField()
    {
        var fields = Field.ParseFields(["0 0"]);
        fields.Should().BeEmpty();
    }

    [Fact]
    public void ParsingFailsOnCompletelyEmpty()
    {
        var action = () => Field.ParseFields([]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("End of input reached early.");
    }

    [Fact]
    public void CanParseMultipleFields()
    {
        var fields = Field.ParseFields([
            "4 4",
            "*...",
            "....",
            ".*..",
            "....",
            "3 5",
            "**...",
            ".....",
            ".*...",
            "0 0",
        ]).ToArray();

        fields.Should().HaveCount(2);
        fields.First().Should().BeEquivalentTo(new Field(1, 4, 4, [
            ['*', '.', '.', '.'],
            ['.', '.', '.', '.'],
            ['.', '*', '.', '.'],
            ['.', '.', '.', '.']
        ]));
        fields[1].FieldNumber.Should().Be(2);
    }

    [Fact]
    public void Parsing_fails_on_input_too_short()
    {
        var action = () => Field.ParseFields(["1 1"]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("End of input reached early.");
    }

    [Fact]
    public void Parsing_fails_on_bad_row_length()
    {
        var action = () => Field.ParseFields(["1 1", ".."]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Invalid number of cells in row*");
    }

    [Fact]
    public void Parsing_fails_on_field_size_rows()
    {
        var action = () => Field.ParseFields(["abc 1", ".."]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Invalid first line of field.");
    }

    [Fact]
    public void Parsing_fails_on_field_size_cols()
    {
        var action = () => Field.ParseFields(["1 abc", ".."]).ToArray();
        action.Should().Throw<InvalidDataException>().WithMessage("Invalid first line of field.");
    }
}
