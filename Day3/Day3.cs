using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day3
    {
        private static string[] input = System.IO.File.ReadAllLines(
            Path.Combine(Directory.GetCurrentDirectory(), "Day3/input.txt"));

        public static int RunPart1() 
        {
            var total = 0;
            foreach (var item in input)
            {
                // A - Z => ASCII - 38
                // a - z => ASCII - 96 
                var commonType = GetCommonType(item);
                if ((int)commonType >= 97)
                {
                    total += (int)commonType - 96;
                }
                else
                {
                    total += (int)commonType - 38;
                }
            }
            return total;
        }   

        public static char GetCommonType(string rucksacks)
        {
            var seen = new HashSet<char>();
            var middleIndex = rucksacks.Length / 2 - 1;
            var leftIndex = 0;
            var rightIndex = rucksacks.Length - 1;

            while (leftIndex <= middleIndex)
            {
                seen.Add(rucksacks[leftIndex]);   
                leftIndex++;
            }

            while (rightIndex > middleIndex)
            {
                if (seen.Contains(rucksacks[rightIndex]))
                    return rucksacks[rightIndex];
                rightIndex--;
            }

            return '\0';
        }
    }
}