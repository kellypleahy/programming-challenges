namespace programming_challenges.Chapter1.Problem1_6_4;

public class Problem(IEnumerable<string> inputLines)
{
    public IEnumerable<string> Solve()
    {
        var inputs = Input.ReadInputs(inputLines);
        var inputLine = 0;
        foreach (var input in inputs)
        {
            if (inputLine > 0)
                yield return "";

            var outputBuffer = new OutputBuffer(input.S, input.Number.Length);
            var printer = new Printer(input, outputBuffer);
            printer.PrintDigits();
            foreach (var line in outputBuffer.Print())
                yield return line;

            inputLine++;
        }
    }
}