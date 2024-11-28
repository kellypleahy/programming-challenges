namespace programming_challenges.Chapter1.Problem1_6_1;

public class ProblemCalc(Input input)
{
    public Output Calculate()
    {
        var maxValue = 0;
        for (var i = input.FirstNumber; i <= input.LastNumber; i++)
        {
            var singleCalculation = new SingleCalculation(i);
            maxValue = Math.Max(maxValue, singleCalculation.CalcCycleLength());
        }

        return new Output(input.FirstNumber, input.LastNumber, maxValue);
    }
}