using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] grid =
                        {
                { 5, 3, 4, 1, 4, 1, 4, 2, 7, 3, 6, 1 },
                { 2, 2, 7, 7, 4, 5, 6, 8, 3, 4, 3, 2 },
                { 8, 2, 5, 3, 7, 2, 6, 4, 1, 3, 7, 5 },
                { 6, 6, 7, 2, 4, 2, 1, 5, 4, 3, 5, 7 },
                { 1, 5, 5, 2, 5, 3, 2, 8, 7, 5, 4, 1 },
                { 2, 8, 3, 3, 1, 1, 5, 6, 8, 6, 5, 8 },
                { 7, 1, 1, 2, 2, 1, 2, 3, 2, 3, 7, 7 },
                { 2, 3, 2, 4, 7, 1, 4, 6, 3, 4, 7, 2 },
                { 6, 8, 2, 3, 1, 6, 3, 7, 7, 8, 2, 7 },
                { 7, 8, 1, 8, 1, 1, 2, 1, 7, 2, 6, 1 }
            };

            Grid(grid);
        }
        static void Grid(int[,] grid)
        {
            var pos = new Position(0, 0);
            var result = new List<Position>();
            if (Grid(grid, pos, result))
            {
                // print the result
                Console.WriteLine("Yes, it's possible to reach the end:\n");
                foreach (Position position in result)
                {
                    Console.WriteLine($"({position.X},{position.Y}) Digit: {position.Digit(grid)}");
                }
                Console.WriteLine($"\nPath Length: {result.Count}");
            }
            else
            {
                // print not possible
                Console.WriteLine("No, it is not possible to reach the end.");
            }
        }

        static bool Grid(int[,] grid, Position pos, List<Position> result)
        {
            if (pos.IsHereBefore(result) || !pos.IsWithinBound(grid)) return false;            
            int d = grid[pos.Y, pos.X];
            result.Add(pos);
            if (pos.IsAtDestination(grid)) return true;
            List<Position> possiblePos = new List<Position> { 
                new Position(pos.X + d, pos.Y),
                new Position(pos.X, pos.Y + d),
                //new Position(pos.X - d, pos.Y),
                //new Position(pos.X, pos.Y - d)
            };
            var filtered = possiblePos.Where(pos => pos.IsWithinBound(grid)).ToList();
            var sortedByDigit = filtered.OrderByDescending(pos => pos.Digit(grid)).ToList();            
            foreach (Position position in sortedByDigit)
            {
                if (Grid(grid, position, result)) return true;                
            }
            result.RemoveAt(result.Count - 1);
            return false;
        }
    }

    public class Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsWithinBound(int[,] grid)
        {
            return (X >= 0 && X <= grid.GetUpperBound(1) && Y >= 0 && Y <= grid.GetUpperBound(0));
        }

        public bool IsAtDestination(int[,] grid)
        {
            return (X == grid.GetUpperBound(1) && Y == grid.GetUpperBound(0));
        }

        public bool IsHereBefore(List<Position> positions)
        {
            foreach (Position p in positions)
            {
                if (X == p.X && Y == p.Y) return true; 
            }
            return false;
        }

        public int Digit(int[,] grid)
        {
            return grid[Y, X];
        }
    }

}
