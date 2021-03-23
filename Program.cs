using System;
using System.Collections.Generic;
using System.Linq;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] coords = {
                { 11, 10 },
                { 16, 16 },
                { 3, 15 },
                { 6, 17 },
                { 10, 5 },
                { 14, 11 },
                { 5, 19 },
                { 15, 18 },
                { 17, 20 },
                { 18, 22}
             };
            double d = 6.0;

            //double[] arr = { 11, 10 };
            //var pos = new Position(arr);
            //pos.Print();

            List<Position> towers = ConvertToList(coords);
            for (int i = 0; i < towers.Count; i++)
            {
                PrintDistances(i, towers, d);
            }
            //towers.ForEach(pos => pos.Print());

            


            //Radio(coords, d);
        }

        static bool Radio(double[,] coords, double d)
        {

            return false;
        }

        static void PrintDistances(int index, List<Position> positions, double d)
        {
            Console.WriteLine($"For Tower {positions[index].AsText()}");
            List<Position> outOfRange = new List<Position>();
            List<Position> withinRange = new List<Position>();
            for (int i = 0; i < positions.Count; i++)
            {
                
                if (i == index) continue;
                if (Distance(positions[index], positions[i]) > d)
                {
                    outOfRange.Add(positions[i]);
                }
                if (Distance(positions[index], positions[i]) <= d)
                {
                    withinRange.Add(positions[i]);
                }
                Console.WriteLine($"  {positions[i].AsText()}: {Distance(positions[index], positions[i])}"); 
            }
            Console.WriteLine($"Towers within range: {withinRange.Count}");
            Console.WriteLine($"Towers out of range: {outOfRange.Count}");
            Console.WriteLine();
            //if (i == index) Console.WriteLine($"[{i}]: Self!");
            //Console.WriteLine($"[{i}]: " + Distance(positions[index], positions[i]));
        }

        static List<Position> ConvertToList(double[,] coords)
        {
            List<Position> list = new List<Position>();
            for (int i = 0; i < coords.GetLength(0); i++)
            {
                list.Add(new Position(coords[i, 0], coords[i, 1]));
            }
            return list;
        }

        static double Distance(Position pos1, Position pos2)
        {
            return Math.Sqrt(Math.Pow((pos2.X - pos1.X), 2) + Math.Pow((pos2.Y - pos1.Y), 2));
        }
        
    }

    class Position
    {
        public double X, Y;
        public Position(double x, double y)
        {
            X = x;
            Y = y;          
        }
        public string AsText()
        {
            return $"({X}, {Y})";
        }
    }
}
