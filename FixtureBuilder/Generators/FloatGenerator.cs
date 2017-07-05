using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class FloatGenerator : IGenerator
    {
        private static float LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
