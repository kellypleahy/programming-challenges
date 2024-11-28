namespace programming_challenges.Chapter1.Problem1_6_1;

public record Output(uint FirstValue, uint LastValue, int MaxCycleLength)
{
    public override string ToString() => $"{FirstValue} {LastValue} {MaxCycleLength}";
}