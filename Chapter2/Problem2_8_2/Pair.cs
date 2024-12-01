namespace programming_challenges.Chapter2.Problem2_8_2;

public record Pair(Card[] PairCards, Card[] OtherCards) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.Pair;

    public override IEnumerable<int> HighCardValues
        => [PairCards[0].Rank, ..OtherCards.Select(x => x.Rank).OrderByDescending(x => x)];
}