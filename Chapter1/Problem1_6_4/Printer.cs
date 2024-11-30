namespace programming_challenges.Chapter1.Problem1_6_4;

public class Printer(Input input, OutputBuffer buffer)
{
    public void PrintDigits()
    {
        var digitPosition = 0;
        foreach (var digit in input.Number)
        {
            var row = 0;
            foreach (var rowChars in Digit.For(input.S, digit).FormatRows())
                buffer.PutDigitRow(digitPosition, row++, rowChars);
            digitPosition++;
        }
    }
}