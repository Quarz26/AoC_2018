using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    class Day3_task1
    {
        static void Main(string[] args)
        {
            string line;
            int overlap = 0;
            int[,] fabric = new int[1000, 1000];

            System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\juric\OneDrive\Desktop\inputDay3.txt");

            while ((line = input.ReadLine()) != null)
            {
                string[] numbers = Regex.Split(line, @"\D+");
                int inchLeft = Int32.Parse(numbers[2]);
                int inchTop = Int32.Parse(numbers[3]);
                int inchWide = Int32.Parse(numbers[4]);
                int inchTall = Int32.Parse(numbers[5]);

                for (int i = inchTop; i < inchTop + inchTall; i++)
                {
                    for (int j = inchLeft; j < inchLeft + inchWide; j++)
                    {
                        if (fabric[i, j] == 1)
                        {
                            fabric[i, j]++;
                            overlap++;
                        }
                        else
                        {
                            fabric[i, j]++;
                        }


                    }
                }

            }

            Console.WriteLine("Broj preklapanja: " + overlap);
        }
    }
}