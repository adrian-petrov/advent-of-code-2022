using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 

namespace AdventOfCode2022
{
    public static class Day7
    {
        private static string[] input = System.IO.File.ReadAllLines(
            Path.Combine(Directory.GetCurrentDirectory(), "Day7/input.txt"));
        private const int MAX_SIZE = 100000; // 100,000

        public static int RunPart1()
        {
            Regex fileRegex = new Regex(@"^\d+"),
                    changeDirectoryRegex = new Regex(@"^\$\s+cd\s+\w+"),
                    goUpRegex = new Regex(@"^\$\s+cd\s+\.\.");
                    
            var dirsStack = new Stack<Node>();
            var totals = new List<int>();

            for (var i = 0; i < input.Length; i++)
            {
                if (goUpRegex.IsMatch(input[i]))
                {
                    var lastDir = dirsStack.Pop();
                    totals.Add(lastDir.Total);
                }
                
                if (changeDirectoryRegex.IsMatch(input[i]))
                {
                    var dirName = ParseDirectoryName(input[i]);
                    var newNode = new Node(dirName);

                    if (dirsStack.Count > 0)
                    {
                        var prevNode = dirsStack.Peek();
                        newNode.Prev = prevNode;
                    }

                    dirsStack.Push(newNode);
                }
                
                if (fileRegex.IsMatch(input[i]))
                {
                    var fileSize = ParseFileSize(input[i]);
                    if (dirsStack.Count > 0)
                    {
                        var currDir = dirsStack.Peek();
                        currDir.Total += fileSize;
                        
                        var prev = currDir.Prev; 
                        while (prev != null)
                        {
                            prev.Total += fileSize;
                            prev = prev.Prev;
                        }
                    }
                }
            }
            
            return totals.Where(t => t < MAX_SIZE).Sum();
        }

        private static string ParseDirectoryName(string input)
        {
            return input.Substring(5);
        }

        private static int ParseFileSize(string input)
        {
            var regex = new Regex(@"\d+");
            return int.Parse(regex.Match(input).ToString());
        }

        private class Node
        {
            public Node(string value)
            {
                Value = value;
            }

            public string Value { get; }
            public Node? Prev { get; set; }
            public int Total { get; set; }
        }
    }
}