using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day5_task1
    {
        static void Main(string[] args)
        {
            string lines = System.IO.File.ReadAllText(@"C:\Users\juric\OneDrive\Desktop\inputDay5.txt");

            Stack<char> stack = new Stack<char>();
            foreach (char c in lines)
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

            Console.WriteLine("Nakon reakcija u polimeru ostaje: " + stack.Count + " jedinica");
        }
    }
}
