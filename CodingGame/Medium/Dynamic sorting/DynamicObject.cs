using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Dynamic_sorting
{
    internal class DynamicObject
    {
        public string Id { get; }
        public Dictionary<string, string> StringValues { get; } = new Dictionary<string, string>();
        public Dictionary<string, int> IntValues { get; } = new Dictionary<string, int>();
        public DynamicObject(string input, LogicObject logic)
        {
            string[] values = input.Split(',');
            for (int i = 0; i < values.Length; i++)
            {
                string[] value = values[i].Split(':');
                if (value[0] == "id")
                    this.Id = value[1];
                else if (logic.Instance.FirstOrDefault(x => x.Name == value[0]).IsInteger)
                    this.IntValues[value[0]] = int.Parse(value[1]);
                else
                    this.StringValues[value[0]] = value[1];
            }
        }
    }
}
