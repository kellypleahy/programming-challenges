namespace programming_challenges.Chapter1.Problem1_6_5;

public class Application
{
    private Image? _currentImage;

    public IEnumerable<string> ProcessInput(IEnumerable<string> inputLines)
    {
        var commands = InputParser.ParseInput(inputLines);
        foreach (var command in commands)
        {
            switch (command)
            {
                case CreateImage c:
                    _currentImage = new Image(c.M, c.N);
                    break;
                case ClearImage:
                    _currentImage?.Clear();
                    break;
                case ColorPixel c:
                    _currentImage?.SetPixel(c.X, c.Y, c.C);
                    break;
                case VerticalSegment vs:
                    _currentImage?.VerticalSegment(vs.X, vs.Y1, vs.Y2, vs.C);
                    break;
                case HorizontalSegment hs:
                    _currentImage?.HorizontalSegment(hs.X1, hs.X2, hs.Y, hs.C);
                    break;
                case Rectangle r:
                    _currentImage?.Rectangle(r.X1, r.Y1, r.X2, r.Y2, r.C);
                    break;
                case Fill f:
                    _currentImage?.Fill(f.X, f.Y, f.C);
                    break;
                case Save s:
                    foreach(var line in _currentImage?.Save(s.FileName) ?? [])
                        yield return line;
                    break;
                case Terminate:
                    yield break;
                case InvalidCommand:
                    // do nothing
                    break;
            }
        }
    }
}
