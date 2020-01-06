using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.ANEO_TrafficLight
{
    class Solution : ICodinGame
    {
        static int[] Inputs = new int[2] { 50, 1 };
        static int[] Distances = new int[1] { 200 };
        static int[] Durations = new int[1] { 10 };
        public void Run()
        {
            int maxSpeed = Inputs[0];
            int lightCount = Inputs[1];
            List<TrafficLight> trafficLights = new List<TrafficLight>();
            for (int i = 0; i < lightCount; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int distance = Distances[i];
                int duration = Durations[i];
                trafficLights.Add(new TrafficLight(distance, duration));
            }
            while (maxSpeed > 0)
            {
                bool check = true;
                //Path
                foreach (TrafficLight trafficLight in trafficLights)
                {
                    if (trafficLight.IsRed(maxSpeed))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    break;
                maxSpeed--;
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine(maxSpeed);
        }
    }
}
