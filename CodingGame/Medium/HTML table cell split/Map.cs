using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.HTML_table_cell_split
{
    internal class Map : IEnumerable<Cell>, IEnumerable
    {
        private List<Cell> Cells = new List<Cell>();
        public void Add(Cell cell) => this.Cells.Add(cell);
        public IEnumerator<Cell> GetEnumerator() => new MapEnumerator(this.Cells);
        IEnumerator IEnumerable.GetEnumerator() => new MapEnumerator(this.Cells);
        public Cell this[int x, int y] => this.Cells.FirstOrDefault(ƒ => ƒ.StartX == x && ƒ.StartY == y);
        //public int Length => this.Cells.Select(x => x.EndX).Distinct().Count();
        //public int Width(int x) => this.Cells.Where(ƒ => ƒ.EndX == x).Select(x => x.EndY).Distinct().Count();
        public string Draw()
        {
            int row = 0;
            string input = string.Empty;
            foreach (Cell cell in Cells.OrderBy(x => x.StartX).ThenBy(x => x.StartY))
            {
                if (cell.StartX != row)
                {
                    input = $"{input.Trim()}{'\n'}{cell} ";
                    row = cell.StartX;
                }
                else
                    input += $"{cell} ";
            }
            return input.Trim();
        }
    }
    internal class MapEnumerator : IEnumerator<Cell>
    {
        public int X = 0;
        private List<Cell> Cells;
        public MapEnumerator(List<Cell> cells) => this.Cells = cells;
        public object Current => this.Cells[this.X];
        Cell IEnumerator<Cell>.Current => this.Cells[this.X];
        public void Dispose() => this.Cells = null;
        public bool MoveNext()
        {
            this.X++;
            return this.X < this.Cells.Count;
        }
        public void Reset() => this.X = 0;
    }
}
