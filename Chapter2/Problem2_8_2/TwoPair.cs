namespace programming_challenges.Chapter2.Problem2_8_2;

public record TwoPair(Card[] HighPair, Card[] LowPair, Card OtherCard) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.TwoPair;

    public override IEnumerable<int> HighCardValues => [HighPair[0].Rank, LowPair[0].Rank, OtherCard.Rank];
}