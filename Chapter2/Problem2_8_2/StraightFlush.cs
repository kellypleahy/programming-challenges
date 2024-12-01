namespace programming_challenges.Chapter2.Problem2_8_2;

public record StraightFlush(Card[] Cards): Straight(Cards)
{
    public override MajorRank MajorRank => MajorRank.StraightFlush;
}