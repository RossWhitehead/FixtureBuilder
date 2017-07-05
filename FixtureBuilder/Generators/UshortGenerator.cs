using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class UshortGenerator : IGenerator
    {
        private static ushort LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
