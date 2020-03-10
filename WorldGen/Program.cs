using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGenerator;

namespace WorldGen
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = new GenerationParameters {Size = 9, WaterDensity = FillerDensity.Medium, MountainsDensity = FillerDensity.Low};
            var worldGen = new WorldGenerator.WorldGen(parameters);
            var world = worldGen.GenerateWorld();

            var printer = new WorldPrinter();
            printer.PrintWorld(world);

            Console.ReadKey();

        }
    }

    
}
