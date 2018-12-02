using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day1_task1
    {
        static void Main(String[] args)
        {
            int freq = 0;
            string line;

            System.IO.StreamReader input = new System.IO.StreamReader(@"E:\Vid\AoC\AoC\AoC\inputDay1.txt");

            while((line = input.ReadLine()) != null)
            {
                freq += Int32.Parse(line);
            }

            Console.WriteLine("Konačna frekvencija: " + freq);        
            input.Close();

        }
    }
}
