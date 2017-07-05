using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class BoolGenerator : IGenerator
    {
        private static bool LastValue { get; set; } = false;

        public object Generate()
        {
            LastValue = !LastValue;
            return LastValue;
        }
    }
}
