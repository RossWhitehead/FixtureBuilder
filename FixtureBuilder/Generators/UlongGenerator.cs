using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class UlongGenerator : IGenerator
    {
        private static ulong LastValue { get; set; } = seed;
        private static readonly ulong seed = 1;

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
