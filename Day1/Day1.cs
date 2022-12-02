using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day1
    {
        private static string[] input = System.IO.File.ReadAllLines(
                Path.Combine(Directory.GetCurrentDirectory(), "Day1/input.txt"));
        
        public static int RunPart1() 
        {
            var max = 0;
            var prevTotal = 0;
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (String.IsNullOrEmpty(input[i]))
                {
                    max = Math.Max(prevTotal, max);
                    prevTotal = 0;
                    continue;
                }
                prevTotal += int.Parse(input[i]);
            }
            return max;
        } 

        public static int RunPart2() 
        {
            List<int> maxes = new List<int>();
            var prevTotal = 0;
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (String.IsNullOrEmpty(input[i]))
                {
                    maxes.Add(prevTotal);
                    prevTotal = 0;
                    continue;
                }
                prevTotal += int.Parse(input[i]);
            }

            maxes.Sort();
            var result = 0;
            foreach (var item in maxes.ToArray()[^3..^0])
            {
                result += item;
            }
            return result;
        }
    }
}