using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Easy.A_mountain_of_a_mole_hill
{
    class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>
        {
            "+--------------+",
            "|   o      oo  |",
            "| +----------+o|",
            "| |..........| |",
            "| |.+------+o|o|",
            "| |.|      |.| |",
            "| |o| +--+o|.| |",
            "| |.| |oo|o|.| |",
            "| |.| +--+ |.| |",
            "| |.|  oo  |.| |",
            "| |.|oooooo|.| |",
            "| |.+------+o|o|",
            "|o|..........| |",
            "|o+----------+ |",
            "|      o   o   |",
            "+--------------+",
        };

        public void Run()
        {
            List<string> inputs = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                string line = Inputs[i];
                Console.Error.WriteLine($"\"{line}\",");
                inputs.Add(line);
            }
            Map map = new Map(inputs);
            for (int i = 0; i < 16; i++) 
            {
                string halo = "";
                for (int j = 0; j < inputs[i].Length; j++) 
                {
                    var point = map.Points.FirstOrDefault(x => x.X == i && x.Y == j);
                    if (point == null || point.IsClosed)
                        halo += inputs[i][j];
                    else 
                        halo += 'X';
                }
                Console.WriteLine(halo);
            }
            Console.WriteLine(map.Points.Where(x => x.IsClosed).Count());
        }
    }
}