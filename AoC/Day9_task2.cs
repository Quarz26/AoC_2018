using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    class Day9_task2
    {
        static void Main(string[] args)
        {
            Regex r = new Regex(@"(\d+)");
            string input = System.IO.File.ReadAllText(@"C:\Users\juric\OneDrive\Desktop\inputDay9.txt");

            Match m = r.Match(input);
            int players = int.Parse(m.Value);
            m = m.NextMatch();
            int points = int.Parse(m.Value) * 100;

            long[] score = new long[players];
            LinkedList<int> circle = new LinkedList<int>();
            LinkedListNode<int> current = circle.AddFirst(0);

            for (int i = 1; i < points; i++)
            {
                if (i % 23 == 0)
                {
                    score[i % players] += i;
                    //23. marbel se dodaje u score i još dodajemo marbel 7 mjesta lijevo od trenutnog
                    for (int j = 0; j < 7; j++)
                    {
                        current = current.Previous ?? circle.Last;
                    }

                    score[i % players] += current.Value;
                    LinkedListNode<int> remove = current;
                    current = remove.Next;
                    circle.Remove(remove);

                }
                else
                {
                    current = circle.AddAfter(current.Next ?? circle.First, i);
                }
            }

            Console.WriteLine("Broj bodova pobjednika: " + score.Max());

        }
    }
}
