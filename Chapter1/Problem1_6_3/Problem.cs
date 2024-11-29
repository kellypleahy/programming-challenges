namespace programming_challenges.Chapter1.Problem1_6_3;

public class Problem(IEnumerable<string> input)
{
    public IEnumerable<string> CalculateResults()
    {
        return Trip.ReadFromInput(input)
            .Select(trip => $"${trip.GetMinimumToTransfer():F2}");
    }
}
