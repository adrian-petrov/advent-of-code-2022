using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day2
    {
        private static string[] input = System.IO.File.ReadAllLines(
                Path.Combine(Directory.GetCurrentDirectory(), "Day2/input.txt"));

        public static int RunPart1()
        {
            // A/X => rock
            // B/Y => paper
            // C/Z => scissors
            var choicesPointsMap = new Dictionary<string, int>
            {
                {"A X", 3 + 1},
                {"A Y", 6 + 2},
                {"A Z", 0 + 3},
                {"B X", 0 + 1},
                {"B Y", 3 + 2},
                {"B Z", 6 + 3},
                {"C X", 6 + 1},
                {"C Y", 0 + 2},
                {"C Z", 3 + 3},
            };

            var total = 0;
            foreach (var item in input)
            {
                total += choicesPointsMap[item];                
            }
            return total;
        }
    }
}