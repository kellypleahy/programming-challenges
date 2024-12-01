namespace programming_challenges.Chapter1.Problem1_6_6;

public static class InputParser
{
    public static IEnumerable<Interpreter> GetMachinesToRun(IEnumerable<string> inputLines)
    {
        var first = true;
        var machineCount = 0;
        var machinesFound = 0;
        var machineMemory = new List<ushort>();
        var skipNext = false;
        foreach (var line in inputLines)
        {
            if (skipNext)
            {
                skipNext = false;
                continue;
            }

            if (first)
            {
                machineCount = int.Parse(line);
                first = false;
                skipNext = true;
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                machinesFound++;
                yield return new Interpreter(machineMemory.ToArray());
                machineMemory.Clear();
                if (machinesFound == machineCount)
                    yield break;

                continue;
            }

            machineMemory.Add(ushort.Parse(line));
        }

        if (machinesFound < machineCount)
            yield return new Interpreter(machineMemory.ToArray());
    }
}