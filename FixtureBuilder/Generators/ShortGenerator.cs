using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class ShortGenerator : IGenerator
    {
        private static short LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
