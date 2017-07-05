using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class DoubleGenerator : IGenerator
    {
        private static double LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
