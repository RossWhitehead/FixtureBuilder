using System;
using System.Collections;

namespace FixtureBuilder.Generators
{
    internal class ArrayGenerator : IGenerator
    {
        private readonly GeneratorFactory generatorFactory;
        private uint many;
        private uint maxDepth;

        public ArrayGenerator(GeneratorFactory generatorFactory, uint many, uint maxDepth)
        {
            this.generatorFactory = generatorFactory;
            this.many = many;
            this.maxDepth = maxDepth;
        }

        public Type Type { get; set; }
        public uint Depth { get; set; }

        public object Generate()
        {
            var instance = (IList)Activator.CreateInstance(Type, (int)many) ;

            var elementType = instance[0].GetType();
            var generator = generatorFactory.GetGenerator(elementType, ++Depth);

            for (int i = 0; i < instance.Count; i++)
            {
                instance[i] = generator.Generate();
            }

            return instance;
        }
    }
}
