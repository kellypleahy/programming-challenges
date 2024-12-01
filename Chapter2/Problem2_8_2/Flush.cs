namespace programming_challenges.Chapter2.Problem2_8_2;

public record Flush(Card[] Cards) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.Flush;

    public override IEnumerable<int> HighCardValues => Cards.Select(x => x.Rank).OrderByDescending(x => x);
}