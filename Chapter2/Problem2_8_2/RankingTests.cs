using FluentAssertions;

namespace programming_challenges.Chapter2.Problem2_8_2;

public class RankingTests
{
    [Fact]
    public void StraightFlushTies()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("AS 2S 3S 5S 4S").ToArray());
        var hand2 = HandRanker.RankHand(Card.ParseHand("AC 2C 3C 5C 4C").ToArray());
        hand1.Rank(hand2).Should().Be(0);
    }

    [Fact]
    public void StraightFlushWinsOverAnother()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("6S 2S 3S 5S 4S").ToArray());
        var hand2 = HandRanker.RankHand(Card.ParseHand("AC 2C 3C 5C 4C").ToArray());
        hand1.Rank(hand2).Should().BeGreaterThan(0);
    }

    [Fact]
    public void StraightFlushLosesToAnother()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("6S 2S 3S 5S 4S").ToArray());
        var hand2 = HandRanker.RankHand(Card.ParseHand("7C 6C 3C 5C 4C").ToArray());
        hand1.Rank(hand2).Should().BeLessThan(0);
    }

    [Fact]
    public void StraightFlushBeatsBestFourOfAKind()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("6S 2S 3S 5S 4S").ToArray());
        var hand2 = HandRanker.RankHand(Card.ParseHand("AC AS AD AH KC").ToArray());
        hand1.Rank(hand2).Should().BeGreaterThan(0);
    }

    [Fact]
    public void FourOfAKindBeatsLowerFour()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("AS AD AH AC KS").ToArray());
        var hand2 = HandRanker.RankHand(Card.ParseHand("KC KS KD AH KH").ToArray());
        hand1.Rank(hand2).Should().BeGreaterThan(0);
    }

    [Fact]
    public void FourOfAKindBeatsFullHouse()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("AS AD AH AC KS").ToArray());
        var hand2 = HandRanker.RankHand(Card.ParseHand("KC KS KD AH AS").ToArray());
        hand1.Rank(hand2).Should().BeGreaterThan(0);
    }

    [Fact]
    public void FullHouseBeatsLowerThree()
    {
        var hand1 = HandRanker.RankHand(Card.ParseHand("KS KD KH JC JS").ToArray()); // kings over jacks
        var hand2 = HandRanker.RankHand(Card.ParseHand("QC QS QD AH AS").ToArray()); // queens over aces
        hand1.Rank(hand2).Should().BeGreaterThan(0);
    }
}
