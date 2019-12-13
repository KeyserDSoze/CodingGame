using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Plague_Jr
{
    internal class Human
    {
        public int Id { get; }
        public List<int> Next { get; private set; }
        public bool Infected { get; private set; } = false;
        public Human(int id, int next)
        {
            this.Id = id;
            this.Next = new List<int>() { next };
        }
        public void AddFurtherNext(int next)
        {
            if (!this.Next.Contains(next))
                this.Next.Add(next);
        }
        public void Infect()
            => this.Infected = true;
        public override string ToString()
            => $"{this.Id} -> {string.Join(",", this.Next)}";
    }
}
