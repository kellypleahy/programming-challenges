namespace programming_challenges.Chapter1.Problem1_6_1;

public class Problem(IEnumerable<string> inputLines)
{
    public IEnumerable<string> Run()
    {
        return Input.ParseMultiple(inputLines)
            .Select(input => new ProblemCalc(input))
            .Select(x => x.Calculate())
            .Select(x => x.ToString());
    }
}