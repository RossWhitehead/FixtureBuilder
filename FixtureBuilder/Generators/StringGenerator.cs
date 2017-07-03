using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class StringGenerator : IGenerator
    {
        public object Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
