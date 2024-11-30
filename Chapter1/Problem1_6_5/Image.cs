namespace programming_challenges.Chapter1.Problem1_6_5;

public record Image(int Width, int Height)
{
    private readonly char[][] _pixels = Enumerable.Range(0, Height)
        .Select(_ => Enumerable.Repeat('O', Width).ToArray())
        .ToArray();

    public void Clear()
    {
        for (var i = 0; i < Height; i++)
        for (var j = 0; j < Width; j++)
            _pixels[i][j] = 'O';
    }

    public void SetPixel(int x, int y, char color)
    {
        _pixels[y - 1][x - 1] = color;
    }

    public void VerticalSegment(int x, int y1, int y2, char color)
    {
        for (var y = y1; y <= y2; y++)
            SetPixel(x, y, color);
    }

    public void HorizontalSegment(int x1, int x2, int y, char color)
    {
        for (var x = x1; x <= x2; x++)
            SetPixel(x, y, color);
    }

    public void Rectangle(int x1, int y1, int x2, int y2, char color)
    {
        for (var x = x1; x <= x2; x++)
        for (var y = y1; y <= y2; y++)
            SetPixel(x, y, color);
    }

    public void Fill(int x, int y, char color)
    {
        var i = y - 1;
        var j = x - 1;
        var currentColor = _pixels[i][j];
        if (currentColor == color)
            return;

        var cellsToChange = new HashSet<Position>();
        var cellsToCheck = new Queue<Position>();
        var initialPosition = new Position(i, j);

        cellsToCheck.Enqueue(initialPosition);
        cellsToChange.Add(initialPosition);
        while (cellsToCheck.Count > 0)
        {
            var next = cellsToCheck.Dequeue();
            foreach (var position in next.Neighbors(Width, Height))
            {
                if (cellsToChange.Contains(position))
                    continue;

                var posColor = _pixels[position.I][position.J];
                if (posColor != currentColor)
                    continue;

                cellsToChange.Add(position);
                cellsToCheck.Enqueue(position);
            }
        }

        foreach (var cell in cellsToChange)
            _pixels[cell.I][cell.J] = color;
    }

    public IEnumerable<string> Save(string fileName)
    {
        yield return fileName;
        foreach (var row in _pixels)
            yield return new string(row);
    }
}
