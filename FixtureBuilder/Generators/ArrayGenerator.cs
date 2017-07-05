using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    internal class ArrayGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public ArrayGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            var instance = (IList)Activator.CreateInstance(generatorContext.Type, generatorContext.Many);

            generatorContext.Type = instance[0].GetType();
            var generator = new GeneratorFactory(generatorContext.Depth, generatorContext.MaxDepth, generatorContext.Many).CreateGenerator(generatorContext);

            for (int i = 0; i < instance.Count; i++)
            {
                instance[i] = generator.Generate();
            }

            return instance;
        }
    }
}
