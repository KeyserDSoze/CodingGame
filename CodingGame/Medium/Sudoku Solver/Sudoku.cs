using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Sudoku_Solver
{
    internal class Sudoku
    {
        public Cell[,] Map { get; } = new Cell[9, 9];
        public void AddLine(string line, int index)
        {
            for (int i = 0; i < line.Length; i++)
                this.Map[index, i] = new Cell(int.Parse(line[i].ToString()), index, i);
        }
        public void SetPossibleValues()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (this.Map[i, j].Value == 0)
                        this.SetPossibleValues(i, j);
        }
        private void SetPossibleValues(int indexI, int indexJ)
        {
            List<int> values = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                values.Remove(this.Map[i, indexJ].Value);
                values.Remove(this.Map[indexI, i].Value);
            }
            this.Map[indexI, indexJ].PossibleValues = values;
        }
        private void RemovePossibleValues(int value, int indexI, int indexJ)
        {
            for (int i = 0; i < 9; i++)
            {
                if (this.Map[i, indexJ].Value == 0)
                    this.Map[i, indexJ].PossibleValues.Remove(value);
                if (this.Map[indexI, i].Value == 0)
                    this.Map[indexI, i].PossibleValues.Remove(value);
            }
        }
        public void Solve()
        {
            List<Cell> theZeroCell = new List<Cell>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (this.Map[i, j].Value == 0)
                        theZeroCell.Add(this.Map[i, j]);
            foreach (Cell cell in theZeroCell.OrderBy(x => x.PossibleValues.Count))
            {
                Console.Error.WriteLine(cell);
            }
            int count = theZeroCell.Count;
            for (int i = 0; i < count; i++)
            {
                Cell cell = theZeroCell.OrderBy(x => x.PossibleValues.Count).First();
                if (cell.PossibleValues.Count > 0)
                {
                    cell.Value = cell.PossibleValues.First();
                    RemovePossibleValues(cell.Value, cell.I, cell.J);
                }
                else
                {
                    throw new NotImplementedException();
                }
                theZeroCell.Remove(cell);
            }
        }
    }
    internal class Cell
    {
        public int Value { get; set; }
        public int I { get; }
        public int J { get; }
        public List<int> PossibleValues { get; set; }

        public Cell(int value, int i, int j)
        {
            this.Value = value;
            this.I = i;
            this.J = j;
        }
        public override string ToString()
        {
            return $"{I} {J} => {Value} ({this.PossibleValues.Count})";
        }
    }
}
