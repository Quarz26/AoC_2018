using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    class Day8_task1
    {
        static void Main(string[] args)
        {
            string inputText = System.IO.File.ReadAllText(@"C:\Users\juric\OneDrive\Desktop\testInput.txt");
            List<int> input = inputText.Split(' ').Select(int.Parse).ToList();
            int i = 0;

            //part 1
            Node root = ReadNode(input, ref i);
            Console.WriteLine("Broj meta podataka: " + root.Sum());

            //part2
            Console.WriteLine("Vrijednost root-a: " + root.Value());

        }

        public class Node
        {
            public List<int> Metadata { get; set; } = new List<int>();
            public List<Node> Nodes { get; set; } = new List<Node>();

            public int Sum()
            {
                return Metadata.Sum() + Nodes.Sum(x => x.Sum());
            }

            public int Value()
            {
                //Node nema djece i njegova vrijednost je suma metadata-e
                if (!Nodes.Any())
                {
                    return Metadata.Sum();
                }

                //Ako ima djece, njegovi metadata podatci su indeksi djece i suma je zbroj svih njihovih vrijednosti
                int value = 0;
                foreach(int m in Metadata)
                {
                    if(m <= Nodes.Count())
                    {
                        value += Nodes[m - 1].Value();
                    }
                }

                return value;
            }
        }

        public static Node ReadNode(List<int> numbers, ref int i)
        {
            Node node = new Node();
            int children = numbers[i++];
            int metadata = numbers[i++];

            for (int j = 0; j < children; j++)
            {
                node.Nodes.Add(ReadNode(numbers, ref i));
            }

            for (int j = 0; j < metadata; j++)
            {
                node.Metadata.Add(numbers[i++]);
            }

            return node;
        }
    }
}
