using System;
using System.Collections.Generic;
using System.Linq;

namespace RailwaySimulator
{
    public class RailwaySystem
    {
        private readonly Dictionary<int, int> _lines;
        private readonly List<Run> _runs;

        public RailwaySystem(Railway railway)
        {
            _lines = new Dictionary<int, int>();
            _runs = new List<Run>();

            foreach (var station in railway.Stations)
            {
                foreach (var stationLine in station.Lines)
                {
                    _lines[GetLineHash(station.Id, stationLine.Destination)] = stationLine.Distance;
                }
            }

            foreach (var train in railway.Trains)
            {
                int currentTime = 0;

                for (int i = 0; i < train.Route.Length - 1; i++)
                {
                    var run = new Run();
                    int lineId = GetLineHash(train.Route[i], train.Route[i + 1]);
                    run.LineId = lineId;
                    run.IsInverse = InversedPath(train.Route[i], train.Route[i + 1]);
                    int runTime = _lines[lineId] / train.Speed;
                    run.TimeStart = currentTime;
                    run.TimeFinish = currentTime + runTime;

                    currentTime = runTime;
                    _runs.Add(run);
                }
            }
        }


        private RailwaySystem() { }


        public bool CheckTrainsCollision()
        {
            var runsGrouped = _runs
                .GroupBy(run => run.LineId);

            foreach (var runGroup in runsGrouped)
            {
                var directRuns = runGroup.Where(run => !run.IsInverse).ToList();
                var inverseRuns = runGroup.Where(run => run.IsInverse).ToList();

                if (directRuns.Count > 0 && inverseRuns.Count > 0)
                {
                    foreach (var directRun in directRuns)
                    {
                        foreach (var inverseRun in inverseRuns)
                        {
                            if (directRun.TimeStart <= inverseRun.TimeFinish &&
                                directRun.TimeFinish >= inverseRun.TimeStart)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }


        private bool InversedPath(int source, int destination)
        {
            return source > destination;
        }

        
        private int GetLineHash(int source, int destination)
        {
            int h0 = (source << 16) | destination;
            int h1 = (destination << 16) | source;

            return (source < destination) ? h0 : h1;
        }


        private struct Run
        {
            public int LineId;
            public int TimeStart;
            public int TimeFinish;
            public bool IsInverse;
        }
    }
}