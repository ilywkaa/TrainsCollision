using NUnit.Framework;

namespace RailwaySimulator.Tests
{
    public class RailwaySystemTest
    {
        private static Station[] _stations = new Station[]
        {
            new Station() { 
                Id = 1,
                Lines = new Line[]
                {
                    new Line()
                    {
                        Distance = 3,
                        Destination = 2
                    }
                }
            },
            new Station() { 
                Id = 2,
                Lines = new Line[]
                {
                    new Line()
                    {
                        Distance = 3,
                        Destination = 1
                    },
                    new Line()
                    {
                        Distance = 4,
                        Destination = 5
                    },
                    new Line()
                    {
                        Distance = 4,
                        Destination = 3
                    }
                }
            },
            new Station() { 
                Id = 3,
                Lines = new Line[]
                {
                    new Line()
                    {
                        Distance = 4,
                        Destination = 2
                    }
                }
            },
            new Station() { 
                Id = 4,
                Lines = new Line[]
                {
                    new Line()
                    {
                        Distance = 5,
                        Destination = 2
                    },
                    new Line()
                    {
                        Distance = 2,
                        Destination = 5
                    }
                }
            },
            new Station() { 
                Id = 5,
                Lines = new Line[]
                {
                    new Line()
                    {
                        Distance = 2,
                        Destination = 4
                    }
                }
            }
        };
        private static Train[] _trainsNonCollided = new Train[]
        {
            new Train()
            {
                Route = new int[]
                {
                    1,
                    2
                }
            },
            new Train()
            {
                Route = new int[]
                {
                    3,
                    2, 
                    1
                }
            }
        };
        private static Train[] _trainsCollided = new Train[]
        {
            new Train()
            {
                Route = new int[]
                {
                    1,
                    2,
                    3
                }
            },
            new Train()
            {
                Route = new int[]
                {
                    3,
                    2
                }
            }
        };


        [SetUp]
        public void Setup() { }


        [Test]
        //[TestCase(, )]
        public void RailwaySystemCheckTrainsCollisionTest()
        {
            var railway = new Railway()
            {
                Stations = _stations,
                Trains = _trainsNonCollided
            };
            var railwaySystem = new RailwaySystem(railway);
            Assert.IsFalse(railwaySystem.CheckTrainsCollision());
        }


        [Test]
        //[TestCase(,)]
        public void RailwaySystemCheckTrainsCollisionTest1()
        {
            var railway = new Railway()
            {
                Stations = _stations,
                Trains = _trainsCollided
            };
            var railwaySystem = new RailwaySystem(railway);
            Assert.IsTrue(railwaySystem.CheckTrainsCollision());
        }
    }
}