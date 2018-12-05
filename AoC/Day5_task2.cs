using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day5_task2
    {
        static void Main (string[] args)
        {
            string lines = File.ReadAllText(@"C:\Users\juric\OneDrive\Desktop\testInput.txt");

            int min = int.MaxValue; ;

            for(char i = 'a'; i <= 'z'; i++)
            {
                string tempLines = lines.Replace(i.ToString(), "").Replace(char.ToUpper(i).ToString(), "");

                Stack<char> stack = new Stack<char>();
                foreach (char c in tempLines)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(c);
                    }
                    else
                    {
                        if ((c ^ stack.Peek()) == 32)
                            stack.Pop();
                        else
                            stack.Push(c);
                    }
                }

                if(stack.Count < min)
                {
                    min = stack.Count;
                }
            }

            Console.WriteLine("Najkraći polimer je veličine: " + min);

        }
    }
}
