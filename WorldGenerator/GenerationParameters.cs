using System;
using System.Collections.Generic;
using System.Text;

namespace WorldGenerator
{
    public class GenerationParameters
    {
        public int Size { get; set; }
        public FillerDensity MountainsDensity { get; set; }
        public FillerDensity WaterDensity { get; set; }
    }

    public enum FillerDensity
    {
        None,
        Low, 
        Medium,
        High
    }
}
