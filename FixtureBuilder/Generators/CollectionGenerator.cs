using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class CollectionGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public CollectionGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            var instance = (IList)Activator.CreateInstance(generatorContext.Type);

            generatorContext.Depth++;

            var generator = new GeneratorFactory().CreateGenerator(generatorContext);

            for (int i = 0; i < generatorContext.Many; i++)
            {
                instance.Add(generator.Generate());
            }

            return instance;
        }
    }
}