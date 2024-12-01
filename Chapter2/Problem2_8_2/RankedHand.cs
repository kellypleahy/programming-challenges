namespace programming_challenges.Chapter2.Problem2_8_2;

public abstract record RankedHand
{
    public abstract MajorRank MajorRank { get; }

    public int Rank(RankedHand other)
    {
        var rankDiff = MajorRank - other.MajorRank;
        return rankDiff != 0
            ? rankDiff
            : CompareCardValues();

        int CompareCardValues() =>
            HighCardValues
                .Zip(other.HighCardValues, (u, t) => u - t)
                .SkipWhile(x => x == 0)
                .FirstOrDefault();
    }

    public abstract IEnumerable<int> HighCardValues { get; }
}
