namespace programming_challenges.Chapter1.Problem1_6_2;

public record Output(int FieldNumber, int Rows, int Cols, char[][] Grid)
{
    public void PrintTo(List<string> output)
    {
        output.Add($"Field #{FieldNumber}:");
        for (var row = 0; row < Rows; row++)
            output.Add(string.Join("", Grid[row]));
    }
}