using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day6_task1_and_2
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\juric\OneDrive\Desktop\inputDay6.txt");
            Dictionary<int, Point> points = new Dictionary<int, Point>();

            int maxX = 0;
            int maxY = 0;
            int count = 0;

            foreach (string s in lines)
            {
                string[] temp = s.Trim().Split(',');
                int x = int.Parse(temp[0]);
                int y = int.Parse(temp[1]);
                points.Add(count, new Point(x, y));
                count++;

                if (x > maxX)
                    maxX = x;

                if (y > maxY)
                    maxY = y;
            }

            int[,] matrix = new int[maxX + 1, maxY + 1];
            Dictionary<int, int> area = new Dictionary<int, int>();

            for (int x = 0; x <= maxX; x++)
            {
                for (int y = 0; y <= maxY; y++)
                {
                    int best = maxX + maxY;
                    int bestnum = -1;


                    //closest point distance
                    for (int i = 0; i < count; i++)
                    {

                        Point p = points[i];
                        int dist = Math.Abs(x - p.X) + Math.Abs(y - p.Y);

                        if (dist < best)
                        {
                            best = dist;
                            bestnum = i;
                        }
                        else if (dist == best)
                        {
                            bestnum = -1;
                        }
                    }
                    matrix[x, y] = bestnum;
                    int total = area.ContainsKey(bestnum) ? area[bestnum] : 0;

                    if (total == 0)
                    {
                        total = 1;
                    }
                    else
                    {
                        total++;
                    }

                    area[bestnum] = total;

                }
            }

            //remove infinity
            for (int x = 0; x <= maxX; x++)
            {
                int bad = matrix[x, 0];
                area.Remove(bad);

                bad = matrix[x, maxY];
                area.Remove(bad);
            }

            for (int y = 0; y <= maxX; y++)
            {
                int bad = matrix[0, y];
                area.Remove(bad);

                bad = matrix[maxX, y];
                area.Remove(bad);
            }

            //find the largest area, part1

            int biggest = 0;

            foreach (int x in area.Values)
            {
                if (x > biggest)
                    biggest = x;
            }

            Console.WriteLine("Najveća površina: " + biggest);


            //part2

            int inarea = 0;
            
            for(int x = 0; x <= maxX; x++)
            {
                for(int y = 0; y <= maxY; y++)
                {
                    int size = 0;
                    for(int i = 0; i < count; i++)
                    {
                        Point p = points[i];
                        int dist = Math.Abs(x - p.X) + Math.Abs(y - p.Y);
                        size += dist;
                    }

                    if(size < 10000)
                    {
                        inarea++;
                    }
                }
            }

            Console.WriteLine("Veličina polja koje ima udaljenost manju od 10000: " + inarea);
        }
    }

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
