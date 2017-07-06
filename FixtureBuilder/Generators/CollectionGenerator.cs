using System;
using System.Collections;

namespace FixtureBuilder.Generators
{
    internal class CollectionGenerator : IGenerator
    {
        private readonly GeneratorFactory generatorFactory;
        private uint many;
        private uint maxDepth;

        public CollectionGenerator(GeneratorFactory generatorFactory, uint many, uint maxDepth)
        {
            this.generatorFactory = generatorFactory;
            this.many = many;
            this.maxDepth = maxDepth;
        }

        public Type Type { get; set; }
        public uint Depth { get; set; }

        public object Generate()
        {
            var instance = (IList)Activator.CreateInstance(Type);

            this.Depth++;

            var genericType = Type.GenericTypeArguments[0];

            var generator = generatorFactory.GetGenerator(genericType);

            for (int i = 0; i < many; i++)
            {
                instance.Add(generator.Generate());
            }

            return instance;
        }
    }
}
