using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class UlongGenerator : IGenerator
    {
        private static ulong LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
