namespace programming_challenges.Chapter1.Problem1_6_6;

public class Interpreter(ushort[] program)
{
    private readonly ushort[] _memory = program
        .Concat(Enumerable.Repeat<ushort>(0, 1000))
        .Take(1000)
        .ToArray();

    private readonly ushort[] _register = new ushort[10];

    public int Run()
    {
        var steps = 0;
        var pc = 0;
        while (true)
        {
            var instruction = _memory[pc];
            steps++;

            if (instruction == 100)
                return steps;

            var decode = (
                i: (ushort)(instruction / 100),
                v1: (ushort)(instruction / 10 % 10),
                v2: (ushort)(instruction % 10)
            );

            switch (decode)
            {
                case (i: 2, var d, var n):
                    _register[d] = n;
                    break;
                case (i: 3, var d, var n):
                    _register[d] += n;
                    _register[d] %= 1000;
                    break;
                case (i: 4, var d, var n):
                    _register[d] *= n;
                    _register[d] %= 1000;
                    break;
                case (i: 5, var d, var s):
                    _register[d] = _register[s];
                    break;
                case (i: 6, var d, var s):
                    _register[d] += _register[s];
                    _register[d] %= 1000;
                    break;
                case (i: 7, var d, var s):
                    _register[d] = (ushort)(_register[d] * (uint)_register[s] % 1000);
                    break;
                case (i: 8, var d, var a):
                    _register[d] = _memory[_register[a]];
                    break;
                case (i: 9, var s, var a):
                    _memory[_register[a]] = _register[s];
                    break;
                case (i: 0, var d, var s):
                    if (_register[s] != 0)
                    {
                        pc = _register[d];
                        continue;
                    }
                    break;
            }

            pc++;
        }
    }
}
