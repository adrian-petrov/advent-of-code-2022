using System.ComponentModel;
using System.Text;

namespace AdventOfCode2022;

public static class Day10
{
    private static readonly string[] Input = System.IO.File.ReadAllLines(
        Path.Combine(Environment.CurrentDirectory, "Day10/input.txt")
    );

    public static int RunPart1()
    {
        var valueTracker = 1;
        var cycleTracker = 0;
        var signalStrengths = new List<int>();

        foreach (var line in Input)
        {
            cycleTracker++;

            switch (cycleTracker)
            {
                case 20:
                    signalStrengths.Add(20 * valueTracker);
                    break;
                case 60:
                    signalStrengths.Add(60 * valueTracker);
                    break;
                case 100:
                    signalStrengths.Add(100 * valueTracker);
                    break;
                case 140:
                    signalStrengths.Add(140 * valueTracker);
                    break;
                case 180:
                    signalStrengths.Add(180 * valueTracker);
                    break;
                case 220:
                    signalStrengths.Add(220 * valueTracker);
                    break;
            }

            var (instruction, currValue) = ParseInstruction(line);

            if (instruction == "noop")
            {
                continue;
            }

            valueTracker += currValue;
            cycleTracker++;

            switch (cycleTracker)
            {
                case 20:
                    signalStrengths.Add(20 * (valueTracker - currValue));
                    break;
                case 60:
                    signalStrengths.Add(60 * (valueTracker - currValue));
                    break;
                case 100:
                    signalStrengths.Add(100 * (valueTracker - currValue));
                    break;
                case 140:
                    signalStrengths.Add(140 * (valueTracker - currValue));
                    break;
                case 180:
                    signalStrengths.Add(180 * (valueTracker - currValue));
                    break;
                case 220:
                    signalStrengths.Add(220 * (valueTracker - currValue));
                    break;
            }
        }

        return signalStrengths.Sum();
    }

    private static Tuple<string, int> ParseInstruction(string line)
    {
        var splitLine = line.Split(" ");

        if (splitLine.Length == 1)
            return new Tuple<string, int>("noop", 0);

        return new Tuple<string, int>("addx", int.Parse(splitLine[1]));
    }
}