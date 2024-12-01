namespace programming_challenges.Chapter2.Problem2_8_2;

public record Card(char Suit, int Rank)
{
    public static Card Parse(string s)
    {
        if (s.Length != 2)
            throw new ArgumentException("Invalid card name.");
        var suit = s[1];
        var rank = s[0] switch
        {
            >= '2' and <= '9' => s[0] - '0',
            'T' => 10,
            'J' => 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => throw new ArgumentException("Invalid card name.")
        };
        return new Card(suit, rank);
    }

    public static IEnumerable<Card> ParseHand(string s)
    {
        var hand = s.Split(' ');
        if (hand.Length != 5)
            throw new ArgumentException("Invalid hand string, should be 5 cards separated by spaces.", nameof(s));
        foreach (var card in hand)
            yield return Parse(card);
    }
}
