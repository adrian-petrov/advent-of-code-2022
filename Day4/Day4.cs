using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day4
    {
        private static string[] input = System.IO.File.ReadAllLines(
            Path.Combine(Directory.GetCurrentDirectory(), "Day4/input.txt"));

        public static int RunPart1()
        {
            var total = 0;
            foreach (var item in input)
            {   
                var pairs = item.Split(','); 
                var leftPair = pairs[0];
                var rightPair = pairs[1];

                var (leftPairLowerRange, leftPairUpperRange) = GetSections(leftPair);
                var (rightPairLowerRange, rightPairUpperRange) = GetSections(rightPair);

                if (
                    leftPairLowerRange >= rightPairLowerRange &&
                    leftPairUpperRange <= rightPairUpperRange
                )    
                {
                    total++;
                }
                else if (
                    rightPairLowerRange >= leftPairLowerRange &&
                    rightPairUpperRange <= leftPairUpperRange
                )
                {
                    total++;
                }
            }
            
            return total;
        }

        private static Tuple<int, int> GetSections(string pair)
        {
            var rangesArray = pair.Split('-');
            var lowerRange = rangesArray[0];
            var upperRange = rangesArray[1];
            return new Tuple<int, int>(int.Parse(lowerRange), int.Parse(upperRange));
        }
    }
}