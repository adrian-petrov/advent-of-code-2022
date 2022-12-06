using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day5
    {
        private static string[] input = System.IO.File.ReadAllLines(
            Path.Combine(Directory.GetCurrentDirectory(), "Day5/input.txt"));

        public static string RunPart1()
        {
            var result = "";
            var stackOfCrates = GetStackOfCrates(input);
            var instructions = GetInstructions(input);

            foreach (var instruction in instructions)
            {
                var move = instruction[0];
                var from = stackOfCrates[instruction[1] - 1];
                var to = stackOfCrates[instruction[2] - 1];

                for (var i = 0; i < move; i++)
                {
                    var top = from.Pop();
                    to.Push(top);
                }
            }
            
            foreach (var crate in stackOfCrates)
            {
                var top = crate.Pop();
                result += top.Substring(1, 1);
            }

            return result;
        }

        private static Stack<string>[] GetStackOfCrates(string[] input) 
        {   
            var arrayOfStacks = new Stack<string>[9];
            for (var i = 0; i < arrayOfStacks.Length; i++)
            {
                arrayOfStacks[i] = new Stack<string>();
            }

            for (var i = 7; i >= 0; i--)
            {
                var subtrahend = 0;
                for (var j = 0; j < input[i].Length; j += 4)
                {
                    var crate = $"{input[i][j]}{input[i][j+1]}{input[i][j+2]}";
                    if (!String.IsNullOrWhiteSpace(crate))
                    {
                        if (j == 0)
                        {
                            arrayOfStacks[0].Push(crate);
                        }
                        else 
                        {
                            arrayOfStacks[j / 2 - subtrahend].Push(crate);
                        }
                    }
                    subtrahend++;
                }
            }

            return arrayOfStacks;
        }

        private static List<int[]> GetInstructions(string[] input)
        {
            var result = new List<int[]>();
            for (var i = 10; i < input.Length; i++)
            {
                var move = int.Parse(input[i].Substring(5, 2).Trim());
                var from = int.Parse(input[i].Substring(input[i].IndexOf("from") + 5, 1));
                var to = int.Parse(input[i].Substring(input[i].Length - 1, 1));
                var instruction = new int[3]{ move, from, to };
                result.Add(instruction);
            }

            return result;
        }
    }
}