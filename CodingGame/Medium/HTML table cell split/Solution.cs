using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.HTML_table_cell_split
{
    internal class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "1,1 1,2",
            "1,1"
        };
        static int IS = 2;
        static string DS = "C";
        public void Run()
        {
            int NR = Inputs.Count;
            List<List<Cell>> cells = new List<List<Cell>>();
            for (int i = 0; i < NR; i++)
            {
                string ROW = Inputs[i];
                Console.Error.WriteLine(ROW);
                cells.Add(ROW.Split(' ').Select(x => new Cell(x)).ToList());
            }
            for (int i = 0; i < cells.Count; i++)
            {
                for (int j = 0; j < cells[i].Count; j++)
                {
                    if (cells[i][j].Id == IS)
                    {
                        Cell cell = cells[i][j];
                        if (DS == "C")
                        {
                            List<Cell> newCells = cells[i].Take(j).ToList();
                            newCells.Add(cell);
                            newCells.AddRange(cells[i].Skip(j).ToList());
                            cells[i] = newCells;
                            for (int k = 0; k < cells.Count; k++)
                            {
                                if (k != i)
                                {
                                    cells[k][j].ColSpan += cell.ColSpan;
                                }
                            }
                        }
                        else
                        {

                        }
                        goto End;
                    }
                }
            }
            End:  foreach(List<Cell> a in cells)
            {
                Console.WriteLine(string.Join(" ", a));
            }
        }
    }
}
