using System;

namespace RailwaySimulator
{
    [Serializable]
    public class Line
    {
        public int Distance { get; set; }
        public int Destination { get; set; }    //StationId

        public Line(int distance, int destination)
        {
            Distance = distance;
            Destination = destination;
        }

        public Line()
        {
            
        }
    }
}