using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.DetectivePikaptchaEp2
{
    class PikaptchaMain
    {
        static List<string> lines = new List<string>()
        {
            "#00###000",
            "0000<0000",
            "000##0000"
        };
        static void Start()
        {
            int width = 9;
            int height = 3;
            Map map = new Map(width, height);
            int i = 0;
            foreach (string line in lines)
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
