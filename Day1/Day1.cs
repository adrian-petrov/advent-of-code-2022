using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day1
    {
        public static int Run() 
        {
            var input = System.IO.File.ReadAllLines(
                Path.Combine(Directory.GetCurrentDirectory(), "Day1/input.txt"));

            int max = 0;
            int prevTotal = 0;
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
    }
}