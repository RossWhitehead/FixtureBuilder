using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class SbyteGenerator : IGenerator
    {
        private static sbyte LastValue { get; set; } = seed;
        private static readonly sbyte seed = 1;

        public object Generate()
        {
            return LastValue++;
        }

        public static void Reset()
        {
            LastValue = seed;
        }
    }
}
