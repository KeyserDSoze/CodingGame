using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Easy.Robot_show
{
    class Duct
    {
        public int Length { get; }
        public List<Robot> Robots { get; } = new List<Robot>();
        public bool HasRobots => this.Robots.Count > 0;
        public Duct(int length, IEnumerable<int> robots, bool onLeft)
        {
            this.Length = length;
            foreach (var robotPosition in robots.OrderBy(x => x))
                this.Robots.Add(new Robot(robotPosition, onLeft = !onLeft));
        }
        public void Run()
        {
            foreach (Robot robot in this.Robots)
                robot.TurnPlayed = false;
            foreach (Robot robot in this.Robots)
                robot.Move(this);
            foreach (Robot robot in this.Robots)
                robot.Turn();
        }
        public void Remove()
        {
            foreach (var t in this.Robots.Where(x => x.X < 0 || x.X > this.Length).ToList())
                this.Robots.Remove(t);
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= Length; i++)
            {
                if (this.Robots.Any(x => x.X == i))
                    stringBuilder.Append(this.Robots.Where(x => x.X == i).Count() > 1 ? "X" : this.Robots.FirstOrDefault(x => x.X == i).ToString());
                else
                    stringBuilder.Append("-");
            }
            return stringBuilder.ToString();
        }
    }
    class Robot
    {
        public int X { get; private set; }
        public bool OnLeft { get; private set; }
        public bool OnRight => !this.OnLeft;
        public bool TurnPlayed { get; set; }
        public bool NeedToTurn { get; set; }
        public void Turn()
        {
            if (this.NeedToTurn)
            {
                this.NeedToTurn = false;
                this.OnLeft = !this.OnLeft;
            }
        }

        public Robot(int x, bool onLeft)
        {
            this.X = x;
            this.OnLeft = onLeft;
        }
        public void Move(Duct duct)
        {
            this.TurnPlayed = true;
            if (OnLeft)
            {
                this.X--;
                if (duct.Robots.Any(x => ((x.X == this.X - 1 && !x.TurnPlayed)
                    || (x.X == this.X && x.TurnPlayed))
                    && x.OnLeft != this.OnLeft))
                    this.NeedToTurn = true;
            }
            else
            {
                this.X++;
                if (duct.Robots.Any(x => ((x.X == this.X + 1 && !x.TurnPlayed)
                    || (x.X == this.X && x.TurnPlayed))
                    && x.OnLeft != this.OnLeft))
                    this.NeedToTurn = true;
            }
        }
        public override string ToString()
            => OnLeft ? "<" : ">";
    }
}