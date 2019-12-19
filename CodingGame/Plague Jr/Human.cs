using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Plague_Jr
{
    internal class Human
    {
        public int Id { get; }
        public List<Human> Before { get; private set; }
        public List<Human> Next { get; private set; }
        public bool Infected { get; private set; } = false;
        public Human(int id)
        {
            this.Id = id;
            this.Next = new List<Human>();
            this.Before = new List<Human>();
        }
        public Human(int id, int next)
        {
            this.Id = id;
            this.Next = new List<Human>() { Humans.Instance(next) };
            this.Before = new List<Human>();
        }
        public void AddFurtherNext(int next)
        {
            Human human = Humans.Instance(next);
            if (!this.Next.Contains(human))
                this.Next.Add(human);
            if (!human.Before.Contains(this))
                human.Before.Add(this);
        }
        public int Max(int max = 0)
        {
            if (this.Next.Count > 0)
            {
                foreach (Human next in this.Next)
                {
                    int value = next.Max(max);
                    if (value > max)
                        max = value;
                }
            }
            return max + 1;
        }

        public int MaxConnection(int id = 0, int max = 0)
        {
            if (id == this.Id)
                return 0;
            if (id == 0)
                id = this.Id;
            foreach (Human next in this.Next)
            {
                int value = next.MaxConnection(this.Id, max);
                if (value > max)
                    max = value;
            }
            return max + 1;
        }
        public Human Infect()
        {
            this.Infected = true;
            Humans.Infected++;
            return this;
        }

        public override string ToString()
            => $"{this.Id} -> {string.Join(",", this.Next)}";
    }
}
