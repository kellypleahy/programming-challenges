using System.Collections;

namespace programming_challenges.Chapter2.Problem2_8_1;

public class Problem(IEnumerable<string> inputLines)
{
    public IEnumerable<string> Run()
    {
        foreach (var inputLine in inputLines)
        {
            if (inputLine.Split(' ') is [var first, .. var rest])
            {
                var set = new BitArray(int.Parse(first) - 1);
                var deltas = rest.Skip(1).Zip(rest)
                    .Select(p => Math.Abs(int.Parse(p.First) - int.Parse(p.Second)));
                var notJolly = false;
                foreach (var delta in deltas)
                {
                    if (delta > set.Count)
                    {
                        notJolly = true;
                        break;
                    }

                    set[delta - 1] = true;
                }

                if (!notJolly)
                    notJolly = !set.HasAllSet();

                if (notJolly)
                    yield return "Not jolly";
                else
                    yield return "Jolly";
            }
            else
            {
                throw new InvalidDataException("Bad input line format");
            }
        }
    }
}
