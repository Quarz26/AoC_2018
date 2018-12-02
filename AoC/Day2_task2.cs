using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day2_task2
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Vid\Desktop\inputDay2.txt");
            Array.Sort(lines);

            //List<string> dict = new List<string>();
            //foreach (string s in lines)
            //{

            //    string intersection = String.Concat(s.Intersect(lines));
            //}
            bool exit = true;

            for(int i = 0; i < lines.Length; i++)
            {
                string first = lines[i];

                for(int j = 0; j < lines.Length; j++)
                {
                    string second = lines[j];
                    string intersection = String.Concat(first.Intersect(second));

                    if(intersection.Length == 25)
                    {
                        string result = String.Concat(first.Where(c => intersection.Contains(c)));
                        Console.WriteLine(result);
                        exit = false;
                        break;
                    }
                }

                if (!exit) break;
            }

            //dict.Sort();

            //foreach(string s in dict)
            //{

            //}
        }
    }
}
