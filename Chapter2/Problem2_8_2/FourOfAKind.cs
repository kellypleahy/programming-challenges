namespace programming_challenges.Chapter2.Problem2_8_2;

public record FourOfAKind(Card[] MatchingCards, Card UnmatchedCard) : RankedHand
{
    public override MajorRank MajorRank => MajorRank.FourOfAKind;

    public override IEnumerable<int> HighCardValues => [MatchingCards[0].Rank];
}