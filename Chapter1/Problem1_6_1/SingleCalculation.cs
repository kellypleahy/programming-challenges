namespace programming_challenges.Chapter1.Problem1_6_1;

public class SingleCalculation(uint startingValue)
{
    public int CalcCycleLength()
    {
        var value = startingValue;
        var cycleLength = 1;
        for (;;)
        {
            if (value == 1)
                return cycleLength;
            value = (value % 2) switch
            {
                0 => value >> 1,
                _ => value * 3 + 1,
            };
            cycleLength++;
        }
    }
}