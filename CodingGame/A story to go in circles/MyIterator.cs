using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.A_story_to_go_in_circles
{
    internal class Move
    {
        public long[] Rounds { get; } = new long[4];
        public Move(int angle, long round)
            => this.Rounds[angle] = round;
        public bool SetFurther(int angle, long round)
        {
            if (this.Rounds[angle] > 0)
                return true;
            else
                this.Rounds[angle] = round;
            return false;
        }
    }
    internal class MyIterator
    {
        private int X = 0;
        private MyMap MyMap;
        private Move[] Moves;
        public MyIterator(MyMap myMap)
        {
            this.MyMap = myMap;
            this.Moves = new Move[MyMap.Lines.Length];
        }
        public long Next(long counter)
        {
            this.X += (int)this.Current - (int)'a' + 1;
            if (this.X >= MyMap.Lines.Length)
                this.X %= MyMap.Lines.Length;
            while (this.Current == '#' || this.Current == '@')
                this.MyMap.Rotate(this.Current == '#' ? 1 : -1);
            if (this.Moves[this.X] == null)
                this.Moves[this.X] = new Move(this.MyMap.Angle, counter);
            else if (counter > 100 && this.Moves[this.X].SetFurther(this.MyMap.Angle, counter))
                return (counter - 1) % (this.Moves[this.X].Rounds[this.MyMap.Angle] - counter);
            return --counter;
        }
        public char Current => MyMap.Lines[this.X];
    }
}
