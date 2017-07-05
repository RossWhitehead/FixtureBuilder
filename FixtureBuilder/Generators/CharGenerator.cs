using System;

namespace FixtureBuilder.Generators
{
    public class CharGenerator : IGenerator
    {
        private static ushort LastValue { get; set; } = 0;

        public object Generate()
        {
            // Chars are 16-bit unicode characters
            return Convert.ToChar(++LastValue);
        }
    }
}
