using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day_11_task1
    {
        static void Main(string[] args)
        {
            int serial = int.Parse(System.IO.File.ReadAllText(@"C:\Users\juric\OneDrive\Desktop\inputDay11.txt"));

            int maxPower = 0;
            int topX = 0;
            int topY = 0;

            for(int y = 1; y < 300; y++)
            {
                for(int x = 1; x < 300; x++)
                {
                    int currentMaxPower = 0;
                    for(int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            FuelCell cell = new FuelCell(x + k, y + j);
                            currentMaxPower += (((((cell.X + 10) * cell.Y) + serial) * (cell.X + 10)) / 100) % 10 - 5;
                        }
                    }
                    if(currentMaxPower > maxPower)
                    {
                        maxPower = currentMaxPower;
                        topX = x;
                        topY = y;
                    }
                }
            }

            Console.WriteLine("Gornje (X,Y) koordinate 3x3 kvadrata s najvećom ukupnom snagom: " + topX + "," + topY);
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
