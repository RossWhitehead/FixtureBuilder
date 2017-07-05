using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    internal class BoolGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public BoolGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            generatorContext.LastBool = !generatorContext.LastBool;
            return generatorContext.LastBool;
        }
    }
}
