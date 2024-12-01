namespace programming_challenges.Chapter2.Problem2_8_2;

public record Straight(Card[] Cards) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.Straight;

    public override IEnumerable<int> HighCardValues
    {
        get
        {
            // special case for 'A' low.
            if (Cards.Any(x => x.Rank == 2))
                return [Cards.Where(x => x.Rank != 14).Max(x => x.Rank)];
            return [Cards.Max(x => x.Rank)];
        }
    }
}