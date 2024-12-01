namespace programming_challenges.Chapter2.Problem2_8_2;

public record FullHouse(Card[] ThreeCards, Card[] TwoCards) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.FullHouse;

    public override IEnumerable<int> HighCardValues => [ThreeCards[0].Rank];
}