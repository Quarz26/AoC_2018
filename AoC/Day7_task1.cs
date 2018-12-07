using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    class Day7_task1
    {
        static void Main(string[] arsg)
        {
            string line;
            List<KeyValuePair<string, string>> steps = new List<KeyValuePair<string, string>>();
            Regex regex = new Regex(@"Step (\w) .+ step (\w)");

            System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\Vid\Desktop\testInput.txt");

            while ((line = input.ReadLine()) != null)
            {
                Match match = regex.Match(line);
                steps.Add(new KeyValuePair<string, string>(match.Groups[1].Value, match.Groups[2].Value));

            }

            List<string> allSetps = steps.Select(x => x.Key).Concat(steps.Select(x => x.Value)).Distinct().OrderBy(x => x).ToList();
            string result = string.Empty;

            while (allSetps.Any())
            {
                string valid = allSetps.Where(s => !steps.Any(d => d.Value == s)).First();
                result += valid;

                allSetps.Remove(valid);
                steps.RemoveAll(d => d.Key == valid);
            }

            Console.WriteLine(result);

        }
    }
}
