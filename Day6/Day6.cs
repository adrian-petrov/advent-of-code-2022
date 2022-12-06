using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day6
    {
        private static string input = System.IO.File.ReadAllText(
            Path.Combine(Directory.GetCurrentDirectory(), "Day6/input.txt"));

        public static int RunPart1()
        {
            var seen = new HashSet<char>();
            int i, indexOfFirstNonRepeatedChar = 0;
            for (i = 0; i < input.Length && seen.Count < 4; i++)
            {
                if (!seen.Add(input[i]))
                {
                    seen.Clear();
                    i = indexOfFirstNonRepeatedChar;
                }
                else
                {
                    indexOfFirstNonRepeatedChar = i;
                }
            }

            return i;
        }

        public static int RunPart2()
        {
            var seen = new HashSet<char>();
            var j = 0;
            for (var i = 0; i < input.Length && seen.Count < 14; i++)
            {
                for (j = i; j < i + 14; j++)
                {
                    if (!seen.Add(input[j]))
                    {
                        seen.Clear();
                        break;
                    }
                }
            }

            return j;
        }
    }
}