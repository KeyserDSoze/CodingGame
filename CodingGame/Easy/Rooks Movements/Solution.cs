using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Rooks_Movements
{
    internal class Solution : ICodinGame
    {
        static string rookPosition = "d5";
        static List<string> Inputs = new List<string>()
        {
            "0 g5",
            "0 d2"
        };
        static int nbPieces = Inputs.Count;
        public void Run()
        {
            Rock rock = new Rock(rookPosition);
            for (int i = 0; i < nbPieces; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                int colour = int.Parse(inputs[0]);
                string onePiece = inputs[1];
                rock.SetMaxAndMin(onePiece, colour == 1);
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.Error.WriteLine($"{rock.MinX} {rock.MinY} {rock.MaxX} {rock.MaxY}");
            rock.Print();
        }
    }
}
