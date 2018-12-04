using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    class Day4_task1_and_2
    {
        static void Main(string[] args)
        {

            List<RawEvent> events = new List<RawEvent>();
            List<Guard> guards = new List<Guard>();
            Guard guard = null;
            string line;
            int currentGuardID = -1;

            using (System.IO.StreamReader input = new System.IO.StreamReader(@"C:\Users\juric\OneDrive\Desktop\inputDay4.txt"))
            {
                while ((line = input.ReadLine()) != null)
                {
                    DateTime date = DateTime.ParseExact("1518" + line.Substring(5, 12), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                    events.Add(new RawEvent()
                    {
                        Data = line.Substring(19),
                        Time = date
                    });
                }
            }

            List<RawEvent> sorted = events.OrderBy(x => x.Time).ToList();

            for (int i = 0; i < events.Count; i++)
            {
                RawEvent tempRE = sorted[i];

                if (tempRE.Data.EndsWith(" begins shift"))
                {
                    currentGuardID = int.Parse(tempRE.Data.Replace("Guard #", "").Replace(" begins shift", ""));
                    guard = guards.FirstOrDefault(x => x.ID == currentGuardID);

                    if (guard == null)
                    {
                        guard = new Guard()
                        {
                            ID = currentGuardID,
                            Month = tempRE.Time.Month,
                            Date = tempRE.Time.Day
                        };

                        guards.Add(guard);
                    }
                }
                else if (tempRE.Data == "falls asleep")
                {
                    if (i + 1 < sorted.Count && sorted[i + 1].Data == "wakes up")
                    {
                        for (int j = tempRE.Time.Minute; j < sorted[i + 1].Time.Minute; j++)
                        {
                            guard.Status[j]++;
                        }
                    }
                }
            }

            List<Guard> sortedGuards = guards.OrderBy(x => x.FormatedDate).ToList();
            List<Guard> sortedMinGuards = guards.OrderBy(x => x.MinAsleep).ToList();

            int max = -1;
            int maxID = -1;
            int maxMinute = 1;

            //task 1
            Guard firstGuard = sortedMinGuards[sortedMinGuards.Count - 1];
            for (int min = 0; min < 60; min++)
            {
                int minutes = firstGuard.Status[min];
                if (minutes > max)
                {
                    maxID = firstGuard.ID;
                    max = minutes;
                    maxMinute = min;
                }
            }

            Console.WriteLine("Prvi odgovor: " + maxID * maxMinute);

            //task 2
            foreach (Guard g in sortedGuards)
            {
                for (int mi = 0; mi < 60; mi++)
                {
                    int minutes = g.Status[mi];
                    if (minutes > max)
                    {
                        maxID = g.ID;
                        max = minutes;
                        maxMinute = mi;
                    }
                }
            }

            Console.WriteLine("Drugi odgovor: " + maxID * maxMinute);
        }

        public class Guard
        {
            public int ID { get; set; }
            public int[] Status { get; set; } = new int[60];
            public int Month { get; set; }
            public int Date { get; set; }

            public int MinAsleep
            {
                get { return Status.Sum(); }
            }

            public string FormatedDate
            {
                get { return Month + "-" + (Date < 10 ? "0" + Date : "" + Date); }
            }
        }

        public class RawEvent
        {
            public DateTime Time { get; set; }
            public string Data { get; set; }
        }
    }
}
