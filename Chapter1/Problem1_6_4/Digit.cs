namespace programming_challenges.Chapter1.Problem1_6_4;

public class Digit(int size, int value)
{
    private readonly char _topMid = value switch
    {
        1 or 4 => ' ',
        >= 0 and <= 9 => '-',
        _ => throw new InvalidOperationException("Invalid digit value")
    };

    private readonly char _midMid = value switch
    {
        0 or 1 or 7 => ' ',
        >= 2 and <= 9 => '-',
        _ => throw new InvalidOperationException("Invalid digit value")
    };

    private readonly char _botMid = value switch
    {
        1 or 4 or 7 => ' ',
        >= 0 and <= 9 => '-',
        _ => throw new InvalidOperationException("Invalid digit value")
    };

    private readonly (char left, char right) _topSection = value switch
    {
        1 or 2 or 3 or 7 => (' ', '|'),
        5 or 6 => ('|', ' '),
        >= 0 and <= 9 => ('|', '|'),
        _ => throw new InvalidOperationException("Invalid digit value")
    };

    private readonly (char left, char right) _botSection = value switch
    {
        1 or >= 3 and <= 5 or 7 or 9 => (' ', '|'),
        2 => ('|', ' '),
        >= 0 and <= 9 => ('|', '|'),
        _ => throw new InvalidOperationException("Invalid digit value")
    };

    private IEnumerable<char> _Line(char midChar, (char left, char right) bookEnds)
    {
        return Enumerable.Repeat(midChar, size)
            .Prepend(bookEnds.left)
            .Append(bookEnds.right);
    }

    public IEnumerable<IEnumerable<char>> FormatRows()
    {
        var spaces = (' ', ' ');
        yield return _Line(_topMid, spaces);
        for (var s = 0; s < size; s++)
            yield return _Line(' ', _topSection);
        yield return _Line(_midMid, spaces);
        for (var s = 0; s < size; s++)
            yield return _Line(' ', _botSection);
        yield return _Line(_botMid, spaces);
    }

    public static Digit For(int size, char charValue)
    {
        if (charValue is >= '0' and <= '9')
            return new Digit(size, charValue - '0');
        throw new ArgumentException("Invalid charValue");
    }
}