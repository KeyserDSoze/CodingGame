using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Hard.Nonogram_inversor
{
    class Possibility
    {
        public List<int[]> Values { get; } = new List<int[]>();
        public Possibility(IEnumerable<string> values, int max)
        {
            List<int> dif = values.Select(x => int.Parse(x)).ToList();
            
        }
    }
    class Map
    {
        
    }
}
