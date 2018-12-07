using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC
{
    class Day7_task2
    {
        static void Main(string[] arsg)
        {
            string line;
            int sec = 0;

            List<int> workingSeconds = new List<int>(5) { 0, 0, 0, 0, 0 };
            List<KeyValuePair<string, string>> steps = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<string, int>> doneSteps = new List<KeyValuePair<string, int>>();

            Regex regex = new Regex(@"Step (\w) .+ step (\w)");

            System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\Vid\Desktop\inputDay7.txt");

            while ((line = input.ReadLine()) != null)
            {
                Match match = regex.Match(line);
                steps.Add(new KeyValuePair<string, string>(match.Groups[1].Value, match.Groups[2].Value));

            }

            List<string> allSetps = steps.Select(x => x.Key).Concat(steps.Select(x => x.Value)).Distinct().OrderBy(x => x).ToList();

            while (steps.Any() || workingSeconds.Any(w => w > sec))
            {
                doneSteps.Where(d => d.Value <= sec).ToList().ForEach(x => steps.RemoveAll(d => d.Key == x.Key));
                doneSteps.RemoveAll(d => d.Value <= sec);

                List<string> valid = allSetps.Where(s => !steps.Any(d => d.Value == s)).ToList();

                for (int i = 0; i < workingSeconds.Count && valid.Any(); i++)
                {
                    if (workingSeconds[i] <= sec)
                    {
                        workingSeconds[i] = GetWorkTime(valid.First()) + sec;
                        allSetps.Remove(valid.First());
                        doneSteps.Add(new KeyValuePair<string, int>((valid.First()), workingSeconds[i]));
                        valid.RemoveAt(0);
                    }
                }

                sec++;
            }

            Console.WriteLine("Potrebno je " + sec + " [s] za sastavljanje saonica.");
        }

        private static int GetWorkTime(string v)
        {
            return (v[0] - 'A') + 61;
        }
    }
}
