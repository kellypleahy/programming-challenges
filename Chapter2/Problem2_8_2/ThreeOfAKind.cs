namespace programming_challenges.Chapter2.Problem2_8_2;

public record ThreeOfAKind(Card[] ThreeCards, Card[] OtherCards) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.ThreeOfAKind;

    public override IEnumerable<int> HighCardValues => [ThreeCards[0].Rank];
}