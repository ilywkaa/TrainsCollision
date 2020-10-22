using System;

namespace RailwaySimulator
{
    [Serializable]
    public class Station
    {
        public int Id { get; set; }
        public Line[] Lines { get; set; }

        public Station(int id, Line[] lines)
        {
            Id = id;
            Lines = lines;
        }


        public Station() { }
    }
}
