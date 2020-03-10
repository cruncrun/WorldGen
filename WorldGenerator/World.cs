using System;
using System.Collections.Generic;
using System.Text;

namespace WorldGenerator
{
    public class World
    {
        public IList<WorldChunk> WorldChunks { get; set; }
        public GenerationParameters GenerationParameters { get; set; }
    }
}
