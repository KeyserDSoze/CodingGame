using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Hard.Connect_four
{
    class Solution : ICodinGame
    {
        List<string> Inputs = new List<string>()
        {
            ".......",
            ".......",
            "..121..",
            "..122.2",
            "11211.1",
            "2211222",
        };
        public void Run()
        {
            List<string> inputs = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                inputs.Add(Inputs[i]);
            }
            Map map = new Map(inputs);
            List<int> firstPlayerColumns = new List<int>();
            List<int> secondPlayerColumns = new List<int>();
            Console.Error.WriteLine(string.Join(",", map.Points.Where(x => x.Value == Value.None && x.IsAPlayableZone())));
            foreach (var t in map.Points.Where(x => x.Value == Value.None && x.IsAPlayableZone()))
            {
                if (t.HasWon(Value.FirstPlayer))
                    if (!firstPlayerColumns.Contains(t.Y))
                        firstPlayerColumns.Add(t.Y);
                if (t.HasWon(Value.SecondPlayer))
                    if (!secondPlayerColumns.Contains(t.Y))
                        secondPlayerColumns.Add(t.Y);
            }
            Console.WriteLine(firstPlayerColumns.Count > 0 ? string.Join(" ", firstPlayerColumns.OrderBy(x => x)) : "NONE");
            Console.WriteLine(secondPlayerColumns.Count > 0 ? string.Join(" ", secondPlayerColumns.OrderBy(x => x)) : "NONE");
        }
    }
}
