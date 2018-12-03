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
            string[] lines = System.IO.File.ReadAllLines(@"E:\Vid\AoC\AoC\AoC\inputDay2.txt");

            bool exit = true;

            for (int i = 0; i < lines.Length; i++)
            {
                string first = lines[i];

                for (int j = i + 1; j < lines.Length; j++)
                {
                    string second = lines[j];
                    int diff = compare(first, second);

                    if(diff == 25)
                    {
                        exit = false;
                        for(int k = 0; k < 26; k++)
                        {
                            if (first[k] == second[k])
                                Console.Write(first[k]);
                        }
                        Console.Write("\n");
                        break;
                    }

                }

                if (!exit) break;
            }

        }

        public static int compare(string word1, string word2)
        {
            int count = 0;
            for (int i = 0; i < word1.Length; i++)
            {
                if (word1[i] == word2[i])
                    count++;
            }

            return count;
        }
    }
}
