namespace programming_challenges.Chapter1.Problem1_6_3;

public record Trip(decimal[] Costs)
{
    public static IEnumerable<Trip> ReadFromInput(IEnumerable<string> inputLines)
    {
        var row = 0;
        decimal[] costs = null!;
        foreach (var line in inputLines)
        {
            if (row != 0 && row > costs.Length)
            {
                yield return new Trip(costs);
                row = 0;
            }

            if (row == 0)
            {
                if (!uint.TryParse(line, out var costCount))
                    throw new InvalidDataException("Invalid cost count input line.");
                if (costCount == 0)
                    yield break;

                costs = new decimal[costCount];
                row++;
                continue;
            }

            if (!decimal.TryParse(line, out var cost))
                throw new InvalidDataException("Invalid cost value input line.");
            costs[row - 1] = cost;
            row++;
        }
        throw new InvalidDataException("End of input reached unexpectedly.");
    }

    public decimal GetMinimumToTransfer()
    {
        if (Costs.Length == 0)
            return 0;

        var sum = Costs.Sum();
        var avg = sum / Costs.Length;
        var floor = Math.Floor(avg * 100) / 100;
        var ceil = Math.Ceiling(avg * 100) / 100;

        var above = Costs.Where(x => x > ceil).Sum(x => x - ceil);
        var below = Costs.Where(x => x < floor).Sum(x => floor - x);

        return Math.Max(above, below);
    }
}
