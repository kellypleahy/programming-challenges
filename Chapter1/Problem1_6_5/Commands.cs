namespace programming_challenges.Chapter1.Problem1_6_5;

public abstract record InputCommand;

public record CreateImage(int M, int N): InputCommand;
public record ClearImage: InputCommand;
public record ColorPixel(int X, int Y, char C): InputCommand;
public record VerticalSegment(int X, int Y1, int Y2, char C): InputCommand;
public record HorizontalSegment(int X1, int X2, int Y, char C): InputCommand;
public record Rectangle(int X1, int Y1, int X2, int Y2, char C): InputCommand;
public record Fill(int X, int Y, char C): InputCommand;
public record Save(string FileName): InputCommand;
public record Terminate: InputCommand;
public record InvalidCommand(string Line): InputCommand;
