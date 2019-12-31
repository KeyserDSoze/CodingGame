using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Plague_Jr
{
    internal class Attempt
    {
        private Dictionary<int, List<int>> Normals = new Dictionary<int, List<int>>();
        private Dictionary<int, List<int>> Infecteds = new Dictionary<int, List<int>>();
        public int Result { get; private set; }
        public Attempt(Dictionary<int, List<int>> normals, int index)
        {
            int count = 0;
            foreach (var normal in normals)
            {
                if (count == index)
                    Infecteds.Add(normal.Key, normal.Value);
                else
                    this.Normals.Add(normal.Key, normal.Value);
                count++;
            }
        }
        public int GetMax()
        {
            int day = 0;
            while (Normals.Count > 0)
            {
                if (this.Infecteds.Count == 0)
                    return int.MaxValue;
                Dictionary<int, List<int>> newInfecteds = new Dictionary<int, List<int>>();
                foreach (KeyValuePair<int, List<int>> t in this.Infecteds)
                    foreach (int x in t.Value)
                        if (!newInfecteds.ContainsKey(x) && this.Normals.ContainsKey(x))
                        {
                            if (this.Normals[x].Count > 1)
                                newInfecteds.Add(x, this.Normals[x]);
                            this.Normals.Remove(x);
                        }
                this.Infecteds = newInfecteds;
                day++;
            }
            return this.Result = day;
        }
    }
}
