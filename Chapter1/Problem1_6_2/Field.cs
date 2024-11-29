namespace programming_challenges.Chapter1.Problem1_6_2;

public record Field(int FieldNumber, int Rows, int Cols, char[][] Grid)
{
    public static IEnumerable<Field> ParseFields(IEnumerable<string> inputLines)
    {
        var fieldNumber = 1;
        var row = 0;
        int rows = 0, cols = 0;
        char[][]? grid = null;
        foreach (var line in inputLines)
        {
            if (row == 0)
            {
                if (line.Split(' ') is [var xString, var yString] 
                    && int.TryParse(xString, out rows)
                    && int.TryParse(yString, out cols))
                {
                    if (rows == 0 && cols == 0)
                        yield break;
                    grid = Enumerable.Range(0, rows).Select(x => new char[cols]).ToArray();
                }
                else 
                    throw new InvalidDataException("Invalid first line of field.");

                row++;
                continue;
            }

            var cells = line.ToCharArray();
            if (cells.Length != cols)
                throw new InvalidDataException($"Invalid number of cells in row ({line}) ({rows}, {cols}).");

            for (var col = 0; col < cols; col++)
                grid![row - 1][col] = cells[col];

            if (row == rows)
            {
                yield return new Field(fieldNumber++, rows, cols, grid!);
                row = 0;
                continue;
            }

            row++;
        }
        
        throw new InvalidDataException("End of input reached early.");
    }

    public bool IsBomb(int row, int col) => Grid[row][col] == '*';
}