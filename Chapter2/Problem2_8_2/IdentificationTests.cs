using FluentAssertions;

namespace programming_challenges.Chapter2.Problem2_8_2;

public class IdentificationTests
{
    [Fact]
    public void StraightFlushAceHigh()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("JH QH TH KH AH").ToArray());
        var straightFlush = hand.Should().BeOfType<StraightFlush>().Subject;
        straightFlush.MajorRank.Should().Be(MajorRank.StraightFlush);
        straightFlush.HighCardValues.Should().Equal([14]);
    }

    [Fact]
    public void StraightFlushAceLow()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("3H 2H AH 4H 5H").ToArray());
        var straightFlush = hand.Should().BeOfType<StraightFlush>().Subject;
        straightFlush.MajorRank.Should().Be(MajorRank.StraightFlush);
        straightFlush.HighCardValues.Should().Equal([5]);
    }

    [Fact]
    public void StraightFlushNoAce()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("3H 2H 6H 4H 5H").ToArray());
        var straightFlush = hand.Should().BeOfType<StraightFlush>().Subject;
        straightFlush.MajorRank.Should().Be(MajorRank.StraightFlush);
        straightFlush.HighCardValues.Should().Equal([6]);
    }

    [Fact]
    public void FourOfAKind()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("AS AD TH AH AC").ToArray());
        var fourOfAKind = hand.Should().BeOfType<FourOfAKind>().Subject;
        fourOfAKind.MajorRank.Should().Be(MajorRank.FourOfAKind);
        fourOfAKind.HighCardValues.Should().Equal([14]);
    }

    [Fact]
    public void FullHouse()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("3H 3D 3S 2D 2S").ToArray());
        var fullHouse = hand.Should().BeOfType<FullHouse>().Subject;
        fullHouse.MajorRank.Should().Be(MajorRank.FullHouse);
        fullHouse.HighCardValues.Should().Equal([3]);
    }

    [Fact]
    public void Flush()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("3H 5H 6H 9H AH").ToArray());
        var flush = hand.Should().BeOfType<Flush>().Subject;
        flush.MajorRank.Should().Be(MajorRank.Flush);
        flush.HighCardValues.Should().Equal([14,9,6,5,3]);
    }

    [Fact]
    public void StraightAceLow()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("AH 2C 3H 4H 5S").ToArray());
        var straight = hand.Should().BeOfType<Straight>().Subject;
        straight.MajorRank.Should().Be(MajorRank.Straight);
        straight.HighCardValues.Should().Equal([5]);
    }

    [Fact]
    public void StraightAceHigh()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("AH QC JH TH KS").ToArray());
        var straight = hand.Should().BeOfType<Straight>().Subject;
        straight.MajorRank.Should().Be(MajorRank.Straight);
        straight.HighCardValues.Should().Equal([14]);
    }

    [Fact]
    public void StraightNoAce()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("9H QC JH TH KS").ToArray());
        var straight = hand.Should().BeOfType<Straight>().Subject;
        straight.MajorRank.Should().Be(MajorRank.Straight);
        straight.HighCardValues.Should().Equal([13]);
    }

    [Fact]
    public void ThreeOfAKind()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("5H 5S 2C 3H 5C").ToArray());
        var threeOfAKind = hand.Should().BeOfType<ThreeOfAKind>().Subject;
        threeOfAKind.MajorRank.Should().Be(MajorRank.ThreeOfAKind);
        threeOfAKind.HighCardValues.Should().Equal([5]);
    }

    [Fact]
    public void TwoPair()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("JH QC JC TH TS").ToArray());
        var twoPair = hand.Should().BeOfType<TwoPair>().Subject;
        twoPair.MajorRank.Should().Be(MajorRank.TwoPair);
        twoPair.HighCardValues.Should().Equal([11, 10, 12]);
    }

    [Fact]
    public void Pair()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("JH QC JC TH 8S").ToArray());
        var pair = hand.Should().BeOfType<Pair>().Subject;
        pair.MajorRank.Should().Be(MajorRank.Pair);
        pair.HighCardValues.Should().Equal([11, 12, 10, 8]);
    }

    [Fact]
    public void HighCard()
    {
        var hand = HandRanker.RankHand(Card.ParseHand("JH QC 7C TH 8S").ToArray());
        var highCard = hand.Should().BeOfType<HighCard>().Subject;
        highCard.MajorRank.Should().Be(MajorRank.HighCard);
        highCard.HighCardValues.Should().Equal([12, 11, 10, 8, 7]);
    }
}