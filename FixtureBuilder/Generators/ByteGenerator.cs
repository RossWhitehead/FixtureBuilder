using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class ByteGenerator : IGenerator
    {
        private byte LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
