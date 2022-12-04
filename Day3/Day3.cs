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

        public static int RunPart2()
        {
            var total = 0;

            for (var i = 0; i < input.Length; i += 3)
            {
                var first = input[i];
                var second = input[i + 1];
                var third = input[i + 2];
                var commonType = GetCommonTypePart2(first, second, third);

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

        public static char GetCommonTypePart2(
            string firstString, 
            string secondString, 
            string thirdString)
        {
            var MAX_CHAR = 52;
            var result = '\0';
            
            var allCharsFirstArray = new Boolean[MAX_CHAR];
            Array.Fill(allCharsFirstArray, false);
            
            foreach (var c in firstString.ToCharArray())
            {
                if (c >= 97)
                {
                    allCharsFirstArray[c - 'a' + 25] = true; 
                }
                else 
                {
                    allCharsFirstArray[c - 'A'] = true;
                }
            }

            var allCharsSecondArray = new Boolean[MAX_CHAR];
            Array.Fill(allCharsSecondArray, false);

            foreach (var c in secondString.ToCharArray())
            {
                if (c >= 97)
                {
                    if (allCharsFirstArray[c - 'a' + 25])
                        allCharsSecondArray[c - 'a' + 25] = true; 
                }
                else 
                {
                    if (allCharsFirstArray[c - 'A'])
                        allCharsSecondArray[c - 'A'] = true;
                }
            }

            foreach (var c in thirdString.ToCharArray())
            {
                if (c >= 97)
                {
                    if (allCharsSecondArray[c - 'a' + 25])
                    {
                        result = c;
                        break;
                    }
                }
                else 
                {
                    if (allCharsSecondArray[c - 'A'])
                    {
                        result = c;
                        break;
                    }
                }
            }

            return result;
        }
    }
}