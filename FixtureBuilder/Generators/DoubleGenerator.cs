using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class DoubleGenerator : IGenerator
    {
        private static double LastValue { get; set; } = seed;
        private static readonly double seed = 1;

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
