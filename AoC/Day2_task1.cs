using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day2_task1
    {
        static void Main(string[] args)
        {
            string line;
            int twiceCount = 0;
            int threeCount = 0;
            int[] counter;


            System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\Vid\Desktop\inputDay2.txt");

            while ((line = input.ReadLine()) != null)
            {
                counter = new int[26];
                bool notTwo = true;
                bool notThree = true;

                for (int i = 0; i < line.Length; i++)
                {
                    char letter = line[i];
                    counter[(int)letter % 97]++;
                }

                for (int i = 0; i < 26; i++)
                {
                    if (counter[i] == 2 && notTwo)
                    {
                        notTwo = false;
                        twiceCount++;
                    }

                    if (counter[i] == 3 && notThree)
                    {
                        notThree = false;
                        threeCount++;
                    }
                }
            }

            Console.WriteLine("Broj: " + threeCount * twiceCount);
        }
    }
}
