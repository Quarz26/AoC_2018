using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AoC
{
    class Day10_task1_and_2
    {
        static void Main(string[] args)
        {
            string line;
            int sec = 0;
            Regex r = new Regex(@"position=<\s?(-?\d+), \s?(-?\d+)> velocity=<\s?(-?\d+), \s?(-?\d+)>");

            List<Points> points = new List<Points>();


            using (System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\juric\OneDrive\Desktop\inputDay10.txt"))
            {
                while ((line = input.ReadLine()) != null)
                {
                    Match m = r.Match(line);
                    points.Add(new Points(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), int.Parse(m.Groups[3].Value), int.Parse(m.Groups[4].Value)));
                }
            }

            int minX = points.Min(x => x.X);
            int minY = points.Min(x => x.Y);
            int maxX = points.Max(x => x.X);
            int maxY = points.Max(x => x.Y);

            while (true)
            {
                List<Points> temp = points.Select(x => x).ToList();
                for (int i = 0; i < points.Count; i++)
                {
                    Points p = points[i];
                    points[i] = new Points(p.X + p.VelocityX, p.Y + p.VelocityY, p.VelocityX, p.VelocityY);
                }

                int newMinX = points.Min(x => x.X);
                int newMinY = points.Min(x => x.Y);
                int newMaxX = points.Max(x => x.X);
                int newMaxY = points.Max(x => x.Y);

                if ((newMaxX - newMinX) > (maxX - minY) || (newMaxY - newMinY) > (maxY - minY))
                {
                    Console.WriteLine(sec);
                    for (int i = minY; i <= maxY; i++)
                    {
                        for (int j = minX; j <= maxX; j++)
                        {
                            Console.Write(temp.Any(x => x.Y == i && x.X == j) ? '#' : '.');
                        }

                        Console.WriteLine();
                    }

                    Console.ReadLine();
                }

                
                minX = newMinX;
                minY = newMinY;
                maxX = newMaxX;
                maxY = newMaxY;
                sec++;

            }

        }

        public class Points
        {
            public int X;
            public int Y;
            public int VelocityX;
            public int VelocityY;

            public Points(int X, int Y, int VelocityX, int VelocityY)
            {
                this.X = X;
                this.Y = Y;
                this.VelocityX = VelocityX;
                this.VelocityY = VelocityY;
            }

        }
    }
}

