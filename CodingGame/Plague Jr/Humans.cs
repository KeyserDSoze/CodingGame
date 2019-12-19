using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Plague_Jr
{
    internal class Humans
    {
        private static Dictionary<int, Human> HumanFactory = new Dictionary<int, Human>();
        public static int Infected { get; internal set; }
        public static Human Instance(int id)
        {
            if (!HumanFactory.ContainsKey(id))
                HumanFactory.Add(id, new Human(id));
            return HumanFactory[id];
        }
        public static Human First() 
        {
            Human human = HumanFactory.OrderByDescending(x => x.Value.Next.Count).FirstOrDefault().Value;
            human.Infect();
            return human;
        }
        public static int MaxConnections() 
        {
            return HumanFactory.Select(x => x.Value.Max()).OrderByDescending(x => x).FirstOrDefault();
        }
        
    }
}
