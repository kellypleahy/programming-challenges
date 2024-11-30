namespace programming_challenges.Chapter1.Problem1_6_4;

public record Input(int S, string Number)
{
    public static IEnumerable<Input> ReadInputs(IEnumerable<string> inputLines)
    {
        foreach (var inputLine in inputLines)
        {
            if (inputLine.Split(' ') is not [var size, var n]
                || !int.TryParse(size, out var s)
                || !int.TryParse(n, out var number))
            {
                throw new InvalidDataException("Input line was not in a correct format.");
            }

            if (s == 0 && number == 0)
                yield break;

            yield return new Input(s, n);
        }
        throw new InvalidDataException("Unexpected end of output.");
    }
}
