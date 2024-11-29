using System.Diagnostics;

namespace programming_challenges.Chapter1.Problem1_6_2;

public class Sweep(Field input)
{
    private static IEnumerable<(int r, int c)> _RawEnvironment(int row, int col)
    {
        for(var r = row-1; r <= row+1; r++)
        for (var c = col - 1; c <= col + 1; c++)
            yield return (r, c);
    }

    private IEnumerable<(int r, int c)> _UsableEnvironment(int row, int col)
    {
        return _RawEnvironment(row, col)
            .Where(p => p is { r: >= 0, c: >= 0 })
            .Where(p => p.r < input.Rows && p.c < input.Cols);
    }

    private int _BombCount(int row, int col)
    {
        return _UsableEnvironment(row, col)
            .Count(x => input.IsBomb(x.r, x.c));
    }

    private static char _CountChar(int value)
    {
        Debug.Assert(value is >= 0 and <= 9, "value must be between 0 and 9");
        return (char)(value + '0');
    }

    public Output Run()
    {
        var grid = input.Grid
            .Select(_ => new char[input.Cols])
            .ToArray();
        for (var r = 0; r < input.Rows; r++)
        for (var c = 0; c < input.Cols; c++)
            grid[r][c] = input.IsBomb(r, c)
                ? '*'
                : _CountChar(_BombCount(r, c));
        return new Output(input.FieldNumber, input.Rows, input.Cols, grid);
    }
}
