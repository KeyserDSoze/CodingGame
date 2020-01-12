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
                    if (!this.Map[i, j].HasValue)
                        this.RemovePossibleValues(this.Map[i, j]);
        }
        private void RemovePossibleValues(Cell cell)
        {
            cell.PossibleValues = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < 9; i++)
            {
                if (this.Map[i, cell.J].HasValue)
                    cell.PossibleValues.Remove(this.Map[i, cell.J].Value);
                if (this.Map[cell.I, i].HasValue)
                    cell.PossibleValues.Remove(this.Map[cell.I, i].Value);
            }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (this.Map[i, j].Q == cell.Q && this.Map[i, j].HasValue)
                        cell.PossibleValues.Remove(this.Map[i, j].Value);
        }
        private List<Cell> Solutions;
        public List<Cell> Solve()
        {
            List<Cell> theZeroCell = new List<Cell>();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (this.Map[i, j].Value == 0)
                        theZeroCell.Add(this.Map[i, j]);
            return this.Solutions = this.NextStep(0, 0, 0, theZeroCell, new List<Cell>[9, 9, 10]);
        }
        public void Draw()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.Map[i, j].Value == 0)
                        this.Map[i, j] = this.Solutions.First(x => x.I == i && x.J == j);
                    Console.Write(this.Map[i, j].Value);
                }
                Console.WriteLine(string.Empty);
            }
        }
        public List<Cell> NextStep(int i, int j, int value, List<Cell> theZeroCell, List<Cell>[,,] memoization)
        {
            if (theZeroCell == null)
                return null;
            if (theZeroCell.Count == 0)
                return new List<Cell>() { new Cell(value, i, j) };
            if (memoization[i, j, value] != null)
                return memoization[i, j, value];
            Cell first = theZeroCell.OrderBy(x => x.PossibleValues.Count).FirstOrDefault();
            if (first == null)
                return null;
            List<Cell> solutions = null;
            foreach (int possibleValue in first.PossibleValues)
            {
                List<Cell> attempt = this.NextStep(first.I, first.J, possibleValue, theZeroCell.SetNewPossibilities(first, possibleValue), memoization);
                if (attempt != null)
                {
                    solutions = attempt;
                    if (value > 0)
                        solutions.Add(new Cell(value, i, j));
                    break;
                }
            }
            return memoization[i, j, value] = solutions;
        }
    }
    internal static class CellListExtensions
    {
        public static List<Cell> SetNewPossibilities(this List<Cell> cells, Cell first, int value)
        {
            List<Cell> newCells = new List<Cell>();
            foreach (Cell cell in cells)
            {
                if (cell.I == first.I && cell.J == first.J)
                    continue;
                else if (cell.I == first.I || cell.J == first.J || cell.Q == first.Q)
                {
                    Cell newCell = cell.Copy();
                    if (cell.PossibleValues.Contains(value))
                        newCell.PossibleValues.Remove(value);
                    newCells.Add(newCell);
                }
                else
                    newCells.Add(cell.Copy());
            }
            return newCells;
        }
    }
    internal class Cell
    {
        public int Value { get; set; }
        public int I { get; }
        public int J { get; }
        public int Q => 3 * (this.I / 3) + this.J / 3 + 1;
        public bool HasValue => this.Value > 0;
        public List<int> PossibleValues { get; set; }

        public Cell(int value, int i, int j)
        {
            this.Value = value;
            this.I = i;
            this.J = j;
        }
        public Cell(int value, int i, int j, List<int> possibleValues) : this(value, i, j)
        {
            this.PossibleValues = new List<int>();
            foreach (int possibleValue in possibleValues)
                PossibleValues.Add(possibleValue);
        }
        public override string ToString()
            => $"{I} {J} {Q} => {Value} ({this.PossibleValues?.Count})";
        public Cell Copy()
            => new Cell(this.Value, this.I, this.J, this.PossibleValues);
    }
}
