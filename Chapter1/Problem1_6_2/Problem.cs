namespace programming_challenges.Chapter1.Problem1_6_2;

public class Problem(IEnumerable<string> inputLines)
{
    public IEnumerable<string> Run()
    {
        var outputLines = new List<string>();
        var input = Field.ParseFields(inputLines);
        foreach (var field in input)
        {
            if (field.FieldNumber > 1)
                outputLines.Add("");
            new Sweep(field).Run().PrintTo(outputLines);
        }
        return outputLines;
    }
}