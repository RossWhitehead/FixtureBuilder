using System;

namespace FixtureBuilder.Generators
{
    internal class CharGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public CharGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            // Chars are 16-bit unicode characters
            return Convert.ToChar(++generatorContext.LastChar);
        }
    }
}
