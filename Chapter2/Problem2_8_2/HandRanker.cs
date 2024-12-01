namespace programming_challenges.Chapter2.Problem2_8_2;

public static class HandRanker
{
    public static RankedHand RankHand(Card[] cards)
    {
        if (cards.Length != 5)
            throw new ArgumentException("wrong number of cards in hand.", nameof(cards));

        var isFlush = cards.Select(x => x.Suit).Distinct().Count() == 1;
        var groups = cards
            .GroupBy(x => x.Rank)
            .OrderByDescending(x => (x.Count(), x.First().Rank))
            .ToArray();
        var cardCounts = groups.Select(x => x.Count()).ToArray();
        var cardRanks = groups.Select(x => x.First().Rank).ToArray();

        return (cardCounts, cardRanks) switch
        {
            // straights and flushes without A low.
            ([1, 1, 1, 1, 1], [var h, .., var l]) when h == l + 4
                => isFlush ? new StraightFlush(cards) : new Straight(cards),
            // straights and flushes with A low.
            ([1, 1, 1, 1, 1], [14, 5, 4, 3, 2])
                => isFlush ? new StraightFlush(cards) : new Straight(cards),
            // four of a kind
            ([4, 1], _)
                => new FourOfAKind(groups[0].ToArray(), groups[1].First()),
            // full house
            ([3, 2], _)
                => new FullHouse(groups[0].ToArray(), groups[1].ToArray()),
            // three of a kind
            ([3, 1, 1], _)
                => new ThreeOfAKind(
                    groups[0].ToArray(),
                    groups.Skip(1).SelectMany(x => x).ToArray()),
            ([1, 1, 1, 1, 1], _) when isFlush
                => new Flush(cards),
            // two pairs
            ([2, 2, 1], _)
                => new TwoPair(
                    groups[0].ToArray(),
                    groups[1].ToArray(),
                    groups[2].First()),
            ([2, 1, 1, 1], _)
                => new Pair(
                    groups[0].ToArray(),
                    groups.Skip(1).SelectMany(x => x).ToArray()),
            (_, _) => new HighCard(cards),
        };
    }
}
