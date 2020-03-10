using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGenerator;

namespace WorldGen
{
    class WorldPrinter
    {
        private readonly MapObjectFactory _mapObjectFactoryfactory = new MapObjectFactory();

        public void PrintWorld(World world)
        {
            var sortedChunks = world.WorldChunks.OrderBy(i => i.Index);
            var mapObjects = sortedChunks.Select(chunk => _mapObjectFactoryfactory.GenerateMapObject(chunk)).ToList();

            foreach (var mapObject in mapObjects)
            {
                Console.SetCursorPosition(mapObject.PositionX, mapObject.PositionY);
                Console.ForegroundColor = mapObject.TextColor;
                Console.BackgroundColor = mapObject.BackgroundColor;
                Console.Write(mapObject.MapCharacter);
            }

            /*
            foreach (var chunk in sortedChunks)
            {
                if (chunk.ChunkType == ChunkType.StartingPosition)
                {
                    Console.WriteLine($"{chunk.Index}\tX:{chunk.PositionX}, Y:{chunk.PositionY}\tStarting Chunk!");
                }
                else
                {
                    Console.WriteLine($"{chunk.Index}\tX:{chunk.PositionX}, Y:{chunk.PositionY}\tMonster Level: {chunk.MonsterLevel}");
                }
            }
            */
        }
    }
}
