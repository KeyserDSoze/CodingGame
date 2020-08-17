using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy.Robot_show
{
    class Solution : ICodinGame
    {
        static int L = 103;
        static int N = 20;
        static List<string> Inputs = new List<string>
        {
            "87",
            "19",
            "72",
            "59",
            "22",
            "74",
            "89",
            "30",
            "33",
            "3",
            "66",
            "77",
            "15",
            "23",
            "58",
            "82",
            "56",
            "98",
            "1",
            "84",
        };
        public void Run()
        {
            string[] inputs = Inputs.ToArray();
            List<int> positions = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int b = int.Parse(inputs[i]);
                positions.Add(b);
                Console.Error.WriteLine($"\"{b}\",");
            }
            int max = 0;
            for (int i = 0; i < 2; i++)
            {
                Duct duct = new Duct(L, positions, i == 0);
                Console.Error.WriteLine(duct.ToString());
                int times = 0;
                while (duct.HasRobots)
                {
                    duct.Run();
                    duct.Remove();
                    Console.Error.WriteLine(duct.ToString());
                    times++;
                }
                times--;
                if (times > max)
                    max = times;
            }
            Console.WriteLine(max);
        }
    }
}
