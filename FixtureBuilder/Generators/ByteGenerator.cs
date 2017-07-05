using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    internal class ByteGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public ByteGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            return generatorContext.LastByte++;
        }
    }
}
