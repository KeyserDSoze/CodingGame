using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingGame.ShadowsOfTheKnightEp2
{
    internal sealed class Map
    {
        private int Width;
        private int Height;
        private IList<Position> Positions = new List<Position>();
        public Map(int n, int m)
        {
            this.Width = n;
            this.Height = m;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    this.Positions.Add(new Position(i, j));
        }
        public Position StartPoint(int x, int y) => this.NextPoint(x, y);
        public Position FirstJump()
        {
            Position position = this.Positions.FirstOrDefault(ƒ => ƒ.X == this.Width / 2 && ƒ.Y == this.Height / 2);
            this.RemovePoint(position);
            return position;
        }
        public Position RandomPoint()
        {
            Position position = this.Positions[new Random().Next(this.Positions.Count)];
            this.RemovePoint(position);
            return position;
        }
        public Position AveragePosition()
        {
            int x = 0;
            int y = 0;
            foreach (Position position in this.Positions)
            {
                x += position.X;
                y += position.Y;
            }
            Position averagePosition = new Position(x / this.Positions.Count, y / this.Positions.Count);
            if (!this.Positions.Any(ƒ => ƒ.X == averagePosition.X && ƒ.Y == averagePosition.Y))
                averagePosition = this.Positions.OrderBy(ƒ => ƒ.Distance(averagePosition)).FirstOrDefault();
            this.RemovePoint(averagePosition);
            return averagePosition;
        }
        public Position NextPoint(int x, int y)
        {
            Position position = new Position(x, y);
            this.RemovePoint(position);
            return position;
        }
        public Position Next(Position previous, Position current)
        {
            string status = ShadowsMain.IsNear(current);
            Player.Log($"prev: {previous.X} {previous.Y}");
            Player.Log($"{status} {current.X} {current.Y}");
            this.RemovePointIf(previous, current, status);
            Player.Log(string.Join(',', this.Positions));
            return this.AveragePosition();
        }

        public void RemovePoint(int x, int y)
            => this.RemovePoint(new Position(x, y));
        public void RemovePoint(Position position)
            => this.Positions.Remove(position);
        public void RemovePointIf(Position previous, Position current, string status)
        {
            for (int i = 0; i < this.Positions.Count; i++)
            {
                Position position = this.Positions[i];
                int previousDistance = previous.Distance(position);
                int currentDistance = current.Distance(position);
                bool removed = false;
                if (removed = status == "COLDER" && currentDistance < previousDistance)
                    this.RemovePoint(position);
                else if (removed = status == "WARMER" && previousDistance < currentDistance)
                    this.RemovePoint(position);
                else if (removed = status == "SAME" && previousDistance != currentDistance)
                    this.RemovePoint(position);
                if (removed)
                    i--;
            }
        }
    }
}
