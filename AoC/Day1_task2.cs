using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day1_task2
    {
        static void Main(String[] args)
        {
            int resFreq = 0;

            string[] lines = System.IO.File.ReadAllLines(@"E:\Vid\AoC\AoC\AoC\inputDay1.txt");

            List<int> dict = new List<int>();
            bool br = false;

            dict.Add(0);

            while (!br)
            {
                foreach (string s in lines)
                {
                    resFreq += Int32.Parse(s);

                    if (dict.Contains(resFreq))
                    {
                        Console.WriteLine("Frekvencija koja se prva ponavlja: " + resFreq);
                        br = true;
                        break;
                    }

                    dict.Add(resFreq);
                }
            }
        }
    }
}
