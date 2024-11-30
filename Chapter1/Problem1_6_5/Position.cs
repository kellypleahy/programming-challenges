namespace programming_challenges.Chapter1.Problem1_6_5;

public record Position(int I, int J)
{
    public IEnumerable<Position> Neighbors(int width, int height)
    {
        if (I > 0)
            yield return this with { I = I - 1 };
        if (I < height - 1)
            yield return this with { I = I + 1 };
        if (J > 0)
            yield return this with { J = J - 1 };
        if (J < width - 1)
            yield return this with { J = J + 1 };
    }
}
