using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Folding_Paper
{
    class Solution : ICodinGame
    {
        static string order = "UL";
        static string side = "D";
        public void Run()
        {
            Fold fold = new Fold();
            foreach(char c in order)
            {
                switch (c)
                {
                    case 'U':
                        fold.UpBlending();
                        break;
                    case 'D':
                        fold.DownBlending();
                        break;
                    case 'L':
                        fold.LeftBlending();
                        break;
                    case 'R':
                        fold.RightBlending();
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            Console.WriteLine(fold.FromThisPointOfView(side));
        }
    }
}
