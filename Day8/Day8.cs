using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class Day8
    {
        private static string[] input = System.IO.File.ReadAllLines(
            Path.Combine(Directory.GetCurrentDirectory(), "Day8/input.txt"));

        public static int RunPart1()
        {
            var total = 0;
            var prevRowArray = new Tree[input.Length, input.Length];
            int i, j;

            for (i = 0; i < input.Length; i++)
            {
                for (j = 0; j < input.Length; j++)
                {
                    prevRowArray[i, j] = new Tree{ Height = int.Parse(input[i][j].ToString()), Seen = false };
                    if (i == 0)
                    {
                        prevRowArray[i, j].HighestColumn = prevRowArray[i, j].Height;
                    } 
                    else
                    {
                        prevRowArray[i, j].HighestColumn = 
                            Math.Max(prevRowArray[i - 1, j].HighestColumn, prevRowArray[i, j].Height);
                    }
                }
            }

            var biggestTreeRow = int.Parse(input[0][0].ToString());

            for (i = 0; i < input.Length; i++)
            {
                var row = input[i]; 
                biggestTreeRow = int.Parse(input[i][0].ToString());
                
                for (j = 0; j < row.Length; j++)
                {
                    if (i == 0 || j == 0 || i == input.Length - 1 || j == row.Length - 1)
                    {
                        prevRowArray[i, j].Seen = true;
                        total++;
                        biggestTreeRow = Math.Max(int.Parse(row[j].ToString()), biggestTreeRow);
                        continue;
                    }
                    
                    if (
                        int.Parse(row[j].ToString()) > prevRowArray[i, j].HighestColumn ||
                        int.Parse(row[j].ToString()) > biggestTreeRow)
                    {
                        prevRowArray[i, j].Seen = true;
                        total++;
                    }
                    biggestTreeRow = Math.Max(int.Parse(row[j].ToString()), biggestTreeRow);
                }

            }

            for (i = input.Length - 1; i >= 0; i--)
            {
                for (j = input.Length - 1; j >= 0; j--)
                {
                    if (i == input.Length - 1)
                    {
                        prevRowArray[i, j].HighestColumn = prevRowArray[i, j].Height;
                    } 
                    else 
                    {
                        prevRowArray[i, j].HighestColumn = 
                            Math.Max(prevRowArray[i + 1, j].HighestColumn, prevRowArray[i, j].Height);
                    }
                }
            }
            
            biggestTreeRow = int.Parse(input[input.Length - 1][input.Length - 1].ToString());

            for (i = input.Length - 1; i >= 0; i--)
            {
                var reversedRow = input[i];
                biggestTreeRow = int.Parse(input[i][input.Length - 1].ToString());

                for (j = reversedRow.Length - 1; j >= 0; j--)
                {
                    if (prevRowArray[i, j].Seen)
                    {
                        biggestTreeRow = Math.Max(int.Parse(reversedRow[j].ToString()), biggestTreeRow);
                        continue;
                    }
                    
                    if (int.Parse(reversedRow[j].ToString()) > prevRowArray[i, j].HighestColumn ||
                        int.Parse(reversedRow[j].ToString()) > biggestTreeRow)
                    {
                        total++;
                    }
                    biggestTreeRow = Math.Max(int.Parse(reversedRow[j].ToString()), biggestTreeRow);
                }
            }

            return total;
        }

        public class Tree
        {
            public int Height { get; set; }
            public int HighestColumn { get; set; }
            public bool Seen { get; set; }
        }
    }
}