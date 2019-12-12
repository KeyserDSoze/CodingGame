using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.ANEO_TrafficLight
{
    class TrafficLight
    {
        public int Distance { get; }
        public int Duration { get; }
        public TrafficLight(int distance, int duration)
        {
            this.Distance = distance;
            this.Duration = duration;
        }
        public bool IsRed(int speed)
            => (18 * this.Distance) % (10 * speed * this.Duration) >= (5 * speed * this.Duration);
    }
}
