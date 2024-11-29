using FluentAssertions;

namespace programming_challenges.Chapter1.Problem1_6_2;

public class CalcTests 
{
    [Fact]
    public void Calculating_a_single_field_works()
    {
        var field = new Field(1, 4, 4, [
            ['*', '.', '.', '.'],
            ['.', '.', '.', '.'],
            ['.', '*', '.', '.'],
            ['.', '.', '.', '.']
        ]);
        var sweep = new Sweep(field);
        var output = sweep.Run();
        output.FieldNumber.Should().Be(1);
        output.Rows.Should().Be(4);
        output.Cols.Should().Be(4);
        var list = new List<string>();
        output.PrintTo(list);
        list.Should().Equal([
            "Field #1:",
            "*100",
            "2210",
            "1*10",
            "1110",
        ]);
    }
    
    [Fact]
    public void FullExampleProblem()
    {
        var problem = new Problem([
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
        ]);
        var result = problem.Run().ToList();
        result.Should().Equal([
            "Field #1:",
            "*100",
            "2210",
            "1*10",
            "1110",
            "",
            "Field #2:",
            "**100",
            "33200",
            "1*100",
        ]);
    }
}