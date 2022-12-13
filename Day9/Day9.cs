// ReSharper disable NonReadonlyMemberInGetHashCode

using System.ComponentModel;

namespace AdventOfCode2022
{
    public static class Day9
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(
            Path.Combine(Environment.CurrentDirectory, "Day9/input.txt")
        );

        public static int RunPart1()
        {
            var rope = new Rope();
            rope.VisitedPositions.Add(new Coordinates(0, 0));

            foreach (var line in Input)
            {
                var (direction, numberOfSteps) = ParseInstruction(line);

                while (numberOfSteps > 0)
                {
                    rope.HandleMovement(direction);
                    numberOfSteps--;
                }
            }
            
            return rope.VisitedPositions.Count;
        }

        public class Coordinates
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coordinates(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void UpdateCoordinates(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object? obj)
            {
                if (obj == null)
                    return false;
                if (this == obj)
                    return true;

                var other = (Coordinates)obj;
                return X == other.X && Y == other.Y;
            }

            public override int GetHashCode()
            {
                var hash = 17;
                hash = hash * 23 + X;
                hash = hash * 23 + Y;
                return hash;
            }
        }

        private class Rope
        {
            public Coordinates Head { get; private set; }
            public Coordinates Tail { get; private set; }
            public HashSet<Coordinates> VisitedPositions { get; private set; }

            public Rope()
            {
                Head = new Coordinates(0, 0);
                Tail = new Coordinates(0, 0);
                VisitedPositions = new HashSet<Coordinates>();
            }

            public void HandleMovement(char direction)
            {
                switch (direction)
                {
                    case 'U':
                        Head.UpdateCoordinates(Head.X, ++Head.Y);
                        break;
                    case 'D':
                        Head.UpdateCoordinates(Head.X, --Head.Y);
                        break;
                    case 'L':
                        Head.UpdateCoordinates(--Head.X, Head.Y);
                        break;
                    case 'R':
                        Head.UpdateCoordinates(++Head.X, Head.Y);
                        break;
                }

                if (Math.Abs(Head.X - Tail.X) <= 1 && Math.Abs(Head.Y - Tail.Y) <= 1) return;
                
                var stepsToMoveX = Head.X == Tail.X ? 0 : (Head.X - Tail.X) / Math.Abs(Head.X - Tail.X);
                var stepsToMoveY = Head.Y == Tail.Y ? 0 : (Head.Y - Tail.Y) / Math.Abs(Head.Y - Tail.Y);
                
                var newXCoord = Tail.X + stepsToMoveX;
                var newYCoord = Tail.Y + stepsToMoveY;
                    
                Tail.UpdateCoordinates(newXCoord, newYCoord);
                VisitedPositions.Add(new Coordinates(Tail.X, Tail.Y));
            }
        }

        private static Tuple<char, int> ParseInstruction(string instruction)
        {
            var instructionArray = instruction.Split(' ');
            var direction = instructionArray[0].Trim()[0];
            var numberOfSteps = int.Parse(instructionArray[1].Trim());

            switch (direction)
            {
                case 'U':
                    return new Tuple<char, int>(direction, numberOfSteps);
                case 'D':
                    return new Tuple<char, int>(direction, numberOfSteps);
                case 'L':
                    return new Tuple<char, int>(direction, numberOfSteps);
                case 'R':
                    return new Tuple<char, int>(direction, numberOfSteps);
                default:
                    return new Tuple<char, int>(direction, numberOfSteps);
            }
        }
    }
}
