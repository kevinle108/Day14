using System;
using System.Collections.Generic;

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
                Console.WriteLine("yes, it's possible");
                foreach (Position position in result)
                {
                    Console.WriteLine($"({position.X}, {position.Y})");
                }
            }
            else
            {
                // print not possible
                Console.WriteLine("no, not possible");
            }
        }

        static bool Grid(int[,] grid, Position pos, List<Position> result)
        {
            if (pos.IsHereBefore(result) || !pos.IsWithinBound(grid)) return false;            
            int d = grid[pos.Y, pos.X];
            result.Add(pos);
            if (pos.IsAtDestination(grid)) return true;
            if (result.Count >= 1000) return false;
            if (Grid(grid, new Position(pos.X + d, pos.Y), result)) return true; // go right
            if (Grid(grid, new Position(pos.X, pos.Y + d), result)) return true; // go down            
            if (Grid(grid, new Position(pos.X - d, pos.Y), result)) return true; // go left
            if (Grid(grid, new Position(pos.X, pos.Y - d), result)) return true; // go up
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
    }

}
