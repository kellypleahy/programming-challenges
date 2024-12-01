namespace programming_challenges.Chapter1.Problem1_6_6;

public class Problem(IEnumerable<string> inputLines)
{
    // intersperse values between items.
    private IEnumerable<string> _Intersperse(string separator, IEnumerable<string> lines)
        => lines.SelectMany(x => new[] { separator, x }).Skip(1);

    public IEnumerable<string> Run()
    {
        return _Intersperse(
            "",
            InputParser.GetMachinesToRun(inputLines)
                .Select(machine => machine.Run())
                .Select(x => x.ToString())
        );
    }
}