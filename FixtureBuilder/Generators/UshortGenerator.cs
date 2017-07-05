using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class UshortGenerator : IGenerator
    {
        private static ushort LastValue { get; set; } = seed;
        private static readonly ushort seed = 1;

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
