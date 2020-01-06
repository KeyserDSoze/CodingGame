using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Dynamic_sorting
{
    internal class LogicObject
    {
        public Queue<Logic> Instance { get; } = new Queue<Logic>();
        public LogicObject(string logic, string ordering)
        {
            string[] logics = logic.Split(',');
            List<string> orders = new List<string>();
            int count = 0;
            string value = "";
            for (int i = 0; i < ordering.Length; i++)
            {
                value += ordering[i];
                if (i > 0 && (ordering[i] == '+' || ordering[i] == '-' || i == ordering.Length - 1))
                {
                    this.Instance.Enqueue(new Logic(value.TrimEnd('+').TrimEnd('-'), logics[count]));
                    value = ordering[i].ToString();
                    count++;
                }
            }
        }
    }
}
