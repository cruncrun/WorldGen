using System;
using System.Collections.Generic;
using System.Linq;

namespace WorldGenerator
{
    public class WorldGen
    {
        public GenerationParameters GenerationParameters { get; set; }
        public World World { get; set; }

        public WorldGen(GenerationParameters parameters)
        {
            GenerationParameters = parameters;
        }

        public World GenerateWorld()
        {
            World = new World {GenerationParameters = GenerationParameters, WorldChunks = CreateChunks()};
            PopulateChunks();
            return World;
        }

        private void PopulateChunks()
        {
            SetStartingChunk();
            SetMountainsAndLakes();

            while (World.WorldChunks.Any(c => c.ChunkType != ChunkType.StartingPosition && (c.MonsterLevel == null || c.MonsterLevel == 0)))
                SetChunkData();
        }

        private void SetMountainsAndLakes()
        {
            var mountainChunks = ProcessDensity(GenerationParameters.MountainsDensity);
            var waterDensity = ProcessDensity(GenerationParameters.WaterDensity);
        }

        private int ProcessDensity(FillerDensity density)
        {
            switch (density)
            {
                case FillerDensity.None:
                    return 0;
                case FillerDensity.Low:
                    return Convert.ToInt32(Math.Sqrt(GenerationParameters.Size) / 12);
                case FillerDensity.Medium:
                    return Convert.ToInt32(Math.Sqrt(GenerationParameters.Size) / 8);
                case FillerDensity.High:
                    return Convert.ToInt32(Math.Sqrt(GenerationParameters.Size) / 4);
                default:
                    throw new ArgumentOutOfRangeException(nameof(density), density, null);
            }
        }

        private void SetChunkData()
        {
            foreach (var chunk in World.WorldChunks)
            {
                
                if (Utils.RandomNumber(0,100) > 97)
                {
                    chunk.ChunkType = ChunkType.Mountains;
                    return;
                }

                if (Utils.RandomNumber(0, 100) < 3)
                {
                    chunk.ChunkType = ChunkType.Water;
                    return;
                }
                

                var adjacentChunks = GetAdjacentChunks(chunk);
                if (adjacentChunks.Count >= 2
                    && (chunk.MonsterLevel == null || chunk.MonsterLevel == 0)
                    && (chunk.ChunkType != ChunkType.StartingPosition))
                {
                    chunk.MonsterLevel = SetChunkMonsterLevel(adjacentChunks);
                    chunk.ChunkType = ChunkType.UnclaimedTerritory;
                }
            }
        }

        private int? SetChunkMonsterLevel(List<WorldChunk> adjacentChunks)
        {
            var adjacentChunksLevelSum = adjacentChunks.Select(c => c.MonsterLevel).Sum();
            var monsterLevel = adjacentChunksLevelSum / adjacentChunks.Count + Utils.RandomNumber(1, 4);

            return monsterLevel > 9 ? 9 : monsterLevel;
        }

        private void SetStartingChunk()
        {
            var startingChunk = World.WorldChunks.Single(c =>
                c.PositionX == GenerationParameters.Size / 2 && c.PositionY == GenerationParameters.Size / 2);
            startingChunk.ChunkType = ChunkType.StartingPosition;
            startingChunk.MonsterLevel = 0;
            World.WorldChunks.RemoveAt(startingChunk.Index);
            World.WorldChunks.Add(startingChunk);
            SetStartingArea();
        }

        private void SetStartingArea()
        {
            var startingChunk = World.WorldChunks.Single(c => c.ChunkType == ChunkType.StartingPosition);
            var adjacentChunks = GetAdjacentChunks(startingChunk);
            foreach (var chunk in World.WorldChunks)
            {
                if (adjacentChunks.Select(c => c.Index).Contains(Convert.ToInt32(chunk.Index)))
                {
                    chunk.MonsterLevel = 1;
                    chunk.ChunkType = ChunkType.ClaimedTerritory;
                }
            }
        }

        private List<WorldChunk> GetAdjacentChunks(WorldChunk chunk)
        {
            return World.WorldChunks.Where(
                        c => (c.PositionX == chunk.PositionX - 1 && chunk.PositionX - 1 >= 0) && c.PositionY == chunk.PositionY
                             || (c.PositionX == chunk.PositionX + 1 && chunk.PositionX + 1 <= GenerationParameters.Size) && c.PositionY == chunk.PositionY
                             || c.PositionX == chunk.PositionX && (c.PositionY == chunk.PositionY - 1 && chunk.PositionY - 1 >= 0)
                             || c.PositionX == chunk.PositionX && (c.PositionY == chunk.PositionY + 1 && chunk.PositionY + 1 <= GenerationParameters.Size))
                    .ToList();
        }

        private List<WorldChunk> CreateChunks()
        {
            var chunks = new List<WorldChunk>();
            var index = 0;

            for (int i = 0; i < GenerationParameters.Size; i++)
            {
                for (int j = 0; j < GenerationParameters.Size; j++)
                {
                    chunks.Add(new WorldChunk { Index = index, PositionX = i, PositionY = j, ChunkType = ChunkType.NotSet });
                    index++;
                }
            }

            return chunks;
        }
    }
}
