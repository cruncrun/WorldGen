using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGenerator;

namespace WorldGen
{
    class MapObject
    {
        public ConsoleColor TextColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }
        public string MapCharacter { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }

    class StartingPosition : MapObject
    {
        public StartingPosition(WorldChunk chunk)
        {
            TextColor = ConsoleColor.Yellow;
            BackgroundColor = ConsoleColor.Blue;
            MapCharacter = "S";
            PositionX = chunk.PositionX;
            PositionY = chunk.PositionY;
        }
    }

    class UnclaimedTerritory : MapObject
    {
        public UnclaimedTerritory(WorldChunk chunk)
        {
            TextColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Green;
            MapCharacter = chunk.MonsterLevel.ToString();
            PositionX = chunk.PositionX;
            PositionY = chunk.PositionY;
        }
    }

    class NotSet : MapObject
    {
        public NotSet(WorldChunk chunk)
        {
            TextColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Gray;
            MapCharacter = "N";
            PositionX = chunk.PositionX;
            PositionY = chunk.PositionY;
        }
    }

    class ClaimedTerritory : MapObject
    {
        public ClaimedTerritory(WorldChunk chunk)
        {
            TextColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.DarkCyan;
            MapCharacter = chunk.MonsterLevel.ToString();
            PositionX = chunk.PositionX;
            PositionY = chunk.PositionY;
        }
    }

    class MapObjectWater : MapObject
    {
        public MapObjectWater(WorldChunk chunk)
        {
            TextColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.DarkBlue;
            MapCharacter = " ";
            PositionX = chunk.PositionX;
            PositionY = chunk.PositionY;
        }
    }

    class MapObjectMountains : MapObject
    {
        public MapObjectMountains(WorldChunk chunk)
        {
            TextColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.DarkGray;
            MapCharacter = "^";
            PositionX = chunk.PositionX;
            PositionY = chunk.PositionY;
        }
    }
}
