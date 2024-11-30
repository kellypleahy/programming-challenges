namespace programming_challenges.Chapter1.Problem1_6_5;

public static class InputParser
{
    public static IEnumerable<InputCommand> ParseInput(IEnumerable<string> inputLines)
    {
        return inputLines.Select(ParseLine);

        InputCommand ParseLine(string line)
        {
            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries) switch
            {
                ["I", var m, var n]
                    when int.TryParse(m, out var mValue) && int.TryParse(n, out var nValue)
                    => new CreateImage(mValue, nValue),
                ["C"] => new ClearImage(),
                ["L", var x, var y, var c]
                    when int.TryParse(x, out var xValue) && int.TryParse(y, out var yValue) && c.Length == 1
                    => new ColorPixel(xValue, yValue, c[0]),
                ["V", var x, var y1, var y2, var c]
                    when int.TryParse(x, out var xValue)
                         && int.TryParse(y1, out var y1Value)
                         && int.TryParse(y2, out var y2Value)
                         && c.Length == 1
                    => new VerticalSegment(xValue, y1Value, y2Value, c[0]),
                ["H", var x1, var x2, var y, var c]
                    when int.TryParse(x1, out var x1Value)
                         && int.TryParse(x2, out var x2Value)
                         && int.TryParse(y, out var yValue)
                         && c.Length == 1
                    => new HorizontalSegment(x1Value, x2Value, yValue, c[0]),
                ["K", var x1, var y1, var x2, var y2, var c]
                    when int.TryParse(x1, out var x1Value)
                         && int.TryParse(x2, out var x2Value)
                         && int.TryParse(y1, out var y1Value)
                         && int.TryParse(y2, out var y2Value)
                         && c.Length == 1
                    => new Rectangle(x1Value, y1Value, x2Value, y2Value, c[0]),
                ["F", var x, var y, var c]
                    when int.TryParse(x, out var xValue)
                         && int.TryParse(y, out var yValue)
                         && c.Length == 1
                    => new Fill(xValue, yValue, c[0]),
                ["S", var name] => new Save(name),
                ["X"] => new Terminate(),
                _ => new InvalidCommand(line),
            };
        }
    }
}
