using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class GeneratorContext
    {
        public GeneratorContext(int many, int depth, int maxDepth)
        {
            Many = many;
            Depth = depth;
            MaxDepth = maxDepth;
        }

        public int Many { get; set; }
        public int Depth { get; set; }
        public int MaxDepth { get; set; }

        public Type Type { get; set; }

        public bool LastBool { get; set; } = false;
        public byte LastByte { get; set; } = 1;
        public ushort LastChar { get; set; } = 1;
        public DateTime LastDateTime { get; set; } = DeterministicDateTime.UtcNow;
        public decimal LastDecimal { get; set; } = 1;
        public double LastDouble { get; set; } = 1;
        public float LastFloat { get; set; } = 1;
        public int LastInt { get; set; } = 1;
        public long LastLong { get; set; } = 1;
        public sbyte LastSbyte { get; set; } = 1;
        public short LastShort { get; set; } = 1;
        public uint LastUint { get; set; } = 1;
        public ulong LastUlong { get; set; } = 1;
        public ushort LastUshort { get; set; } = 1;
    }
}
