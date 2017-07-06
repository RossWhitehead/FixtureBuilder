using System;

namespace FixtureBuilder.Generators
{
    internal class CharGenerator : IGenerator
    {
        private ushort lastChar = 1;

        public object Generate()
        {
            // Chars are 16-bit unicode characters
            return Convert.ToChar(lastChar++);
        }
    }
}
