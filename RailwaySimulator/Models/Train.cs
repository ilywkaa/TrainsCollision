using System;

namespace RailwaySimulator
{
    [Serializable]
    public class Train
    {
        public int Speed { get; set; } = 1;
        public int[] Route { get; set; }    //Ordered station ids

        public Train(int speed, int[] route)
        {
            Speed = speed;
            Route = route;
        }

        public Train()
        {
            
        }
    }
}