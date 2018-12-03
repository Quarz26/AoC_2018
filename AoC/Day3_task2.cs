using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    class Day3_task2
    {
        static void Main(string[] args)
        {
            string line;
            int overlap = 0;
            int noOverlapID = 0;
            int[,] fabric = new int[1000, 1000];

            System.IO.StreamReader input1 = new System.IO.StreamReader(@"C:\Users\juric\OneDrive\Desktop\inputDay3.txt");

            // popuniti matricu fabric
            while ((line = input1.ReadLine()) != null)
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
                        fabric[i, j]++;
                    }
                }
            }

            input1.Close();
            //provjera gdje nema overlapa po ID-u

            System.IO.StreamReader input2 = new System.IO.StreamReader(@"C:\Users\juric\OneDrive\Desktop\inputDay3.txt");

            while ((line = input2.ReadLine()) != null)
            {
                string[] numbers = Regex.Split(line, @"\D+");

                noOverlapID = 0;
                overlap = 0;

                int ID = Int32.Parse(numbers[1]);
                int inchLeft = Int32.Parse(numbers[2]);
                int inchTop = Int32.Parse(numbers[3]);
                int inchWide = Int32.Parse(numbers[4]);
                int inchTall = Int32.Parse(numbers[5]);

                for (int i = inchTop; i < inchTop + inchTall; i++)
                {
                    for (int j = inchLeft; j < inchLeft + inchWide; j++)
                    {
                        if (fabric[i, j] != 1)
                            overlap++;
                    }
                }

                if (overlap == 0)
                {
                    noOverlapID = ID;
                    break;
                }
            }

            input2.Close();

            Console.WriteLine("ID bez preklapanja: " + noOverlapID);
        }
    }
}
