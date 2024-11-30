namespace programming_challenges.Chapter1.Problem1_6_4;

public class OutputBuffer(int size, int digits)
{
    private readonly char[][] _buffer = Enumerable.Range(0, 2 * size + 3)
        .Select(_ => Enumerable.Repeat(' ', (size + 2) * digits + (digits - 1)).ToArray())
        .ToArray();

    public void PutDigitRow(int digitPosition, int rowNumber, IEnumerable<char> symbols)
    {
        var start = digitPosition * (size + 2) + digitPosition;
        foreach (var symbol in symbols)
            _buffer[rowNumber][start++] = symbol;
    }

    public IEnumerable<string> Print()
    {
        return _buffer.Select(row => new string(row));
    }
}