namespace programming_challenges.Chapter2.Problem2_8_2;

public class Problem(IEnumerable<string> inputLines)
{
    public IEnumerable<string> Run()
    {
        return from inputLine in inputLines
            let black = Card.ParseHand(inputLine.Remove(14))
            let white = Card.ParseHand(inputLine.Remove(0, 15))
            let blackHand = HandRanker.RankHand(black.ToArray())
            let whiteHand = HandRanker.RankHand(white.ToArray())
            select blackHand.Rank(whiteHand) switch
            {
                0 => "Tie.",
                > 0 => "Black wins.",
                < 0 => "White wins.",
            };
    }
}
