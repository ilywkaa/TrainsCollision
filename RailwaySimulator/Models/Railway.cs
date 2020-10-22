using System;

namespace RailwaySimulator
{
    [Serializable]
    public class Railway
    {
        public Station[] Stations { get; set; }
        public Train[] Trains { get; set; }

        public Railway(Station[] stations, Train[] trains)
        {
            Stations = stations;
            Trains = trains;
        }

        public Railway()
        {

        }
    }
}
