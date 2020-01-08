using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.HTML_table_cell_split
{
    internal class Cell
    {
        private static int AscendingId = 0;
        public int Id { get; }
        public int ColSpan { get; set; }
        public int RowSpan { get; set; }
        public Cell(string value)
        {
            string[] splitted = value.Split(',');
            this.ColSpan = int.Parse(splitted[0]);
            this.RowSpan = int.Parse(splitted[1]);
            this.Id = AscendingId;
            AscendingId++;
        }
        public override string ToString()
        {
            return $"{this.ColSpan},{this.RowSpan}";
        }
    }
}
