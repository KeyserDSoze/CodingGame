using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.ANEO_TrafficLight
{
    internal class TrafficLight
    {
        public int Distance { get; }
        public int Duration { get; }
        public TrafficLight(int distance, int duration)
        {
            this.Distance = distance;
            this.Duration = duration;
        }
        public (bool, int) IsRed(int speed, int seconds)
        {
            int time = seconds + this.Distance / speed;
            return ((time / this.Duration) % 2 == 1, time);
        }
    }
}
