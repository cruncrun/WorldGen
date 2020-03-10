using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGenerator;

namespace WorldGen
{
    class MapObjectFactory
    {
        public MapObject GenerateMapObject(WorldChunk chunk) =>
            chunk.ChunkType switch
            {
                ChunkType.StartingPosition => (new StartingPosition(chunk) as MapObject),
                ChunkType.UnclaimedTerritory => (new UnclaimedTerritory(chunk) as MapObject),
                ChunkType.ClaimedTerritory => (new ClaimedTerritory(chunk) as MapObject),
                ChunkType.NotSet => (new NotSet(chunk) as MapObject),
                ChunkType.Water => (new MapObjectWater(chunk) as MapObject),
                ChunkType.Mountains => (new MapObjectMountains(chunk) as MapObject)
            };
    }
}
