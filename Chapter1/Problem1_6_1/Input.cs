using System.Diagnostics.CodeAnalysis;

namespace programming_challenges.Chapter1.Problem1_6_1;

public record Input(uint FirstNumber, uint LastNumber)
{
    public static IEnumerable<Input> ParseMultiple(params IEnumerable<string> inputLines)
    {
        return inputLines.Select(Parse);
    }

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static Input Parse(string line)
    {
        var values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        return values switch
        {
            [var first, var second]
                when uint.TryParse(first, out var firstNumber) &&
                     uint.TryParse(second, out var lastNumber)
                => new Input(firstNumber, lastNumber),
            _ => throw new InvalidDataException("Input values should be two valid non-negative integers.")
        };
    }
}