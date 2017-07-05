using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class UintGenerator : IGenerator
    {
        private static uint LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
