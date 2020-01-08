using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.HTML_table_cell_split
{
    internal class Solution : ICodinGame
    {
        //static List<string> Inputs = new List<string>()
        //{
        //    "1,3 3,1",
        //    "1,2 1,1 1,1",
        //    "1,1 1,1"
        //};
        //static int IS = 3;
        //static string DS = "R";
        static List<string> Inputs = new List<string>()
        {
            "1,1 1,2 1,1 2,1",
            "1,3 1,2 2,1",
            "1,1 1,1 1,3",
            "3,2",
            "1,1",
        };
        static int IS = 5;
        static string DS = "C";

        public void Run()
        {
            int NR = Inputs.Count;

            List<string> inputs = new List<string>();
            int totalHeight = 0;
            int maxWidth = 0;
            for (int i = 0; i < NR; i++)
            {
                string ROW = Inputs[i];
                inputs.Add(ROW);
                int maxHeight = 0;
                int countWidth = 0;
                foreach (string value in ROW.Split(' '))
                {
                    string[] splitted = value.Split(',');
                    int width = int.Parse(splitted[0]);
                    int height = int.Parse(splitted[1]);
                    countWidth += width;
                    if (height > maxHeight)
                        maxHeight = height;
                }
                if (countWidth > maxWidth)
                    maxWidth = countWidth;
                totalHeight += maxHeight;
            }
            MyArray<int> bidimensionalMap = new MyArray<int>(totalHeight + 1, maxWidth + 1);
            int id = 0;
            for (int i = 0; i < NR; i++)
            {
                int j = 0;
                foreach (string value in inputs[i].Split(' '))
                {
                    string[] splitted = value.Split(',');
                    int width = int.Parse(splitted[0]);
                    int height = int.Parse(splitted[1]);
                    int counterWidth = width;
                    for (int k = i; k < bidimensionalMap.Length; k++)
                    {
                        for (int l = j; l < bidimensionalMap.Width(k); l++)
                        {
                            
                        }
                    }
                    id++;
                }
            }

        }
    }
}


//public void Run()
//{
//    int NR = Inputs.Count;
//    Map map = new Map();
//    for (int i = 0; i < NR; i++)
//    {
//        string ROW = Inputs[i];
//        int totalWidth = 0;
//        int totalHeight = 0;
//        int width = int.Parse(ROW.Split(' ')[0].Split(',')[0]);
//        if (i > 0)
//        {
//            int maxWidth = map.Max(x => x.EndY);
//            Cell minimum = null;
//            foreach (Cell a in map.OrderBy(x => x.EndX))
//            {

//            }
//            if (minimum == null)
//                minimum = map.Where(x => x.StartY == 0).OrderByDescending(x => x.EndX).FirstOrDefault();
//            totalWidth = minimum.StartY;
//            totalHeight = minimum.EndY;
//        }
//        foreach (string value in ROW.Split(' '))
//        {
//            string[] splitted = value.Split(',');
//            int width = int.Parse(splitted[0]);
//            int height = int.Parse(splitted[1]);
//            Cell cell = new Cell(width + totalWidth - 1, height + totalHeight - 1, totalHeight, totalWidth);
//            map.Add(cell);
//            totalWidth += cell.Width;
//        }
//    }
//    Cell toDuplicate = map.First(x => x.Id == IS);
//    if (DS == "C")
//    {
//        Cell duplication = new Cell(toDuplicate.EndY + 1, toDuplicate.EndX, toDuplicate.StartX, toDuplicate.StartY + 1);
//        foreach (Cell toChange in map.Where(x => x.StartY <= toDuplicate.EndY && toDuplicate.EndY <= toDuplicate.EndY))
//            if (toChange != toDuplicate)
//                toChange.MoveOnY(duplication.Width);
//        map.Add(duplication);
//    }
//    else
//    {
//        Cell duplication = new Cell(toDuplicate.EndY, toDuplicate.EndX, toDuplicate.StartX + 1, toDuplicate.StartY);
//        foreach (Cell toChange in map.Where(x => x.StartX >= duplication.StartX && x.EndX <= duplication.EndX))
//        {
//            toChange.MoveOnY(1);
//        }
//        map.Add(duplication);
//    }
//    Console.WriteLine(map.Draw());
//}
