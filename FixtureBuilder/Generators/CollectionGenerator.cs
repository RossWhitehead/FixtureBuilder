using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class CollectionGenerator : IGenerator
    {
        private int depth;
        private readonly int maxDepth;
        private readonly int many;
        private readonly Type type;

        public CollectionGenerator(int depth, int maxDepth, int many, Type type)
        {
            this.depth = ++depth;
            this.maxDepth = maxDepth;
            this.many = many;
            this.type = type;
        }

        public object Generate()
        {
            var instance = (IList)Activator.CreateInstance(type);

            var generator = new GeneratorFactory(depth, maxDepth, many).CreateGenerator(type);

            for (int i = 0; i < many; i++)
            {
                instance.Add(generator.Generate());
            }

            return instance;
        }
    }
}