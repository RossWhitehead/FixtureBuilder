using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class IntGenerator : IGenerator
    {
        private static int LastValue { get; set; } = seed;
        private static readonly int seed = 1;

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
