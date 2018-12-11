using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day_11_task2
    {
        static void Main(string[] args)
        {
            int serial = int.Parse(System.IO.File.ReadAllText(@"C:\Users\juric\OneDrive\Desktop\inputDay11.txt"));

            Console.CursorVisible = false;

            int maxPower = 0;
            int topX = 0;
            int topY = 0;
            int maxSize = 0;

            for(int s = 0; s < 300; s++) { 
                for (int y = 1; y < 300 - s; y++)
                {
                    for (int x = 1; x < 300 - s; x++)
                    {
                        int currentMaxPower = 0;
                        for (int j = 0; j < s; j++)
                        {
                            for (int k = 0; k < s; k++)
                            {
                                FuelCell cell = new FuelCell(x + k, y + j);
                                currentMaxPower += (((((cell.X + 10) * cell.Y) + serial) * (cell.X + 10)) / 100) % 10 - 5;
                            }
                        }
                        Console.SetCursorPosition(0, 0);
                        if (currentMaxPower > maxPower)
                        {
                            maxPower = currentMaxPower;
                            topX = x;
                            topY = y;
                            maxSize = s;
                            Console.WriteLine("Gornje (X,Y) koordinate kvadrata s najvećom ukupnom snagom i velićina kvadrata: " + topX + "," + topY + "," + maxSize);
                        }
                    }
                }
            }

            Console.WriteLine("Gornje (X,Y) koordinate kvadrata s najvećom ukupnom snagom i velićina kvadrata: " + topX + "," + topY + "," + maxSize);
        }
    }

    public class FuelCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public FuelCell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

