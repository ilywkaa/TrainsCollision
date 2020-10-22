using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using RailwaySimulator;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name with railway data.");
            string fileName = Console.ReadLine();
 
            var fileInfo = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
            if (!fileInfo.Exists)
            {
                Console.Write(
                    $"There are no file with \"{fileName}\" name in \"{AppDomain.CurrentDomain.BaseDirectory}\" directory.");
                return;
            }
            
            using FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
            XmlSerializer formatter = new XmlSerializer(typeof(Railway));

            Railway railway = (Railway) formatter.Deserialize(fs);
            
            RailwaySystem railwaySystem = new RailwaySystem(railway);
            bool result = railwaySystem.CheckTrainsCollision();

            if (result)
            {
                Console.WriteLine("There is a catastrophe could happen!");
            }
            else
            {
                Console.WriteLine("Success.");
            }
            Console.ReadLine();
        }
    }
}
