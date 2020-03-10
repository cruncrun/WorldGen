using System;
using System.Collections.Generic;
using System.Text;

namespace WorldGenerator
{
    public class WorldChunk
    {
        public int Index { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int? MonsterLevel { get; set; }
        public ChunkType ChunkType { get; set; }

    }
}
