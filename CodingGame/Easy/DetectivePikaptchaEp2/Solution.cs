using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.DetectivePikaptchaEp2
{
    internal class Solution : ICodinGame
    {
        private static List<string> Lines = new List<string>()
        {
            "#00###000",
            "0000<0000",
            "000##0000"
        };
        public void Run()
        {
            int width = 9;
            int height = 3;
            Map map = new Map(width, height);
            int i = 0;
            foreach (string line in Lines)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '#')
                        map.Zero(j, i);
                    else if (line[j] != '0')
                        map.SetPikaptcha(j, i, line[j]);
                }
                i++;
            }
            map.SetWallOn("R");
            map.Play();
        }
    }
}
