namespace AdventOfCode2022;

public static class Day11
{
    private static readonly string Input = File.ReadAllText(
        Path.Combine(Environment.CurrentDirectory, "Day11/input.txt")
    );

    public static int RunPart1()
    {
        var monkeys = ParseMonkeys(Input);

        for (var i = 0; i < 20; i++)
        {
            foreach (var currMonkey in monkeys)
            {
                while (currMonkey.StartingItems.Count > 0)
                {
                    currMonkey.Inspections++;
                    
                    var currItem = currMonkey.StartingItems.Dequeue();
                    var operation = currMonkey.Operation[0];
                    var operand = currMonkey.Operation.Substring(2);

                    if (operation == '*')
                    {
                        if (int.TryParse(operand, out var number))
                        {
                            currItem = (int)Math.Floor((currItem * number) / 3.0);
                        }
                        else
                        {
                            currItem = (int)Math.Floor((currItem * currItem) / 3.0);
                        }
                    } 
                    else
                    {
                        if (int.TryParse(operand, out var number))
                        {
                            currItem = (int)Math.Floor((currItem + number) / 3.0);
                        }
                        else
                        {
                            currItem = (int)Math.Floor((currItem + currItem) / 3.0);
                        }
                    }

                    if (currItem % currMonkey.TestDivisor == 0)
                    {
                        monkeys[currMonkey.MonkeyIfTrue].StartingItems.Enqueue(currItem);
                    }
                    else
                    {
                        monkeys[currMonkey.MonkeyIfFalse].StartingItems.Enqueue(currItem);
                    }
                }
            }
        }

        var inspections = new List<int>();
        monkeys.ToList().ForEach(m => inspections.Add(m.Inspections));
        inspections.Sort();

        return inspections[6] * inspections[7];
    }


    private static Monkey[] ParseMonkeys(string input)
    {
        var result = new Monkey[8];
        var monkeysString = input.Split(new[] { Environment.NewLine + Environment.NewLine },
            StringSplitOptions.RemoveEmptyEntries);

        int i;
        int j;
        for (i = 0; i < monkeysString.Length; i++)
        {
            var currMonkey = monkeysString[i];
            var currMonkeyStrings = currMonkey.Split("\n");
            var newMonkey = new Monkey();

            for (j = 0; j < currMonkeyStrings.Length; j++)
            {
                var row = currMonkeyStrings[j];
            
                switch (j)
                {
                    case 1:
                    {
                        var numbers = row.Substring(row.IndexOf(":", StringComparison.InvariantCulture) + 2);
                        var arrayOfNumbers = numbers.Split(",");
                        foreach (var n in arrayOfNumbers)
                        {
                            newMonkey.StartingItems.Enqueue(int.Parse(n.Trim()));
                        }

                        break;
                    }
                    
                    case 2:
                    {
                        var operation = row.Substring(row.IndexOf("old", StringComparison.InvariantCulture) + 4);
                        newMonkey.Operation = operation;
                        break;
                    }
                    
                    case 3:
                    {
                        var divisibleBy = row.Substring(row.IndexOf("by", StringComparison.InvariantCulture) + 3);
                        newMonkey.TestDivisor = int.Parse(divisibleBy);
                        break;
                    }
                    
                    case 4:
                    {
                        var ifFalse = row.Substring(row.IndexOf("monkey", StringComparison.InvariantCulture) + 7);
                        newMonkey.MonkeyIfTrue = int.Parse(ifFalse);
                        break;
                    }
                    
                    case 5:
                    {
                        var ifTrue = row.Substring(row.IndexOf("monkey", StringComparison.InvariantCulture) + 7);
                        newMonkey.MonkeyIfFalse = int.Parse(ifTrue);
                        break;
                    }
                }
            }
            
            result[i] = newMonkey;
        }

        return result;
    }

    private class Monkey
    {
        public Queue<int> StartingItems { get; set; } = new();
        public string Operation { get; set; } = string.Empty;
        public int TestDivisor { get; set; }
        public int MonkeyIfFalse { get; set; }
        public int MonkeyIfTrue { get; set; }
        public int Inspections { get; set; }
    }
}