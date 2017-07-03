using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class IntGenerator : IGenerator
    {
        private int LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
