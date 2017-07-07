using System;
using System.Collections;

namespace FixtureBuilder.Generators
{
    internal class BitArrayGenerator : IGenerator
    {
        private uint many;

        public BitArrayGenerator(uint many)
        {
            this.many = many;
        }

        public object Generate()
        {
            var instance = new BitArray((int)many, true);

            return instance;
        }
    }
}
