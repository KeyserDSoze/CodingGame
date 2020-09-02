using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CodinGame.Hard.Super_Computer
{
    class Solution : ICodinGame
    {
        private List<string> Inputs = new List<string>()
        {
           "3 5",
            "9 2",
            "24 5",
            "16 9",
            "11 6",
        };
        public void Run()
        {
            int N = Inputs.Count;
            Dictionary<int, Day> daysAsDictionary = new Dictionary<int, Day>();
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                int J = int.Parse(inputs[0]);
                int D = int.Parse(inputs[1]);
                Day d = new Day(J, D);
                if (daysAsDictionary.ContainsKey(J))
                {
                    if (d.Distance < daysAsDictionary[J].Distance)
                        daysAsDictionary[J] = d;
                }
                else
                    daysAsDictionary.Add(J, d);
            }
            List<Day> days = daysAsDictionary.Select(x => x.Value).OrderBy(x => x.Distance).ToList();
            int count = 0;
            int[] all = new int[int.MaxValue/2];
            foreach (Day day in days)
            {
                bool isAdmitted = true;
                for (int i = day.From; i <= day.To; i++)
                {
                    if (all[i] == 1)
                    {
                        isAdmitted = false;
                        break;
                    }
                }
                if (isAdmitted)
                {
                    count++;
                    for (int i = day.From; i <= day.To; i++)
                        all[i] = 1;
                }
            }
            Console.WriteLine(count);
        }
    }
}