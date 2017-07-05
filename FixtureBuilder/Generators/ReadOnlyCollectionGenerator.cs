using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class ReadOnlyCollectionGenerator : IGenerator
    {
        private int depth;
        private readonly int maxDepth;
        private readonly int many;
        private readonly Type type;

        public ReadOnlyCollectionGenerator(int depth, int maxDepth, int many, Type type)
        {
            this.depth = ++depth;
            this.maxDepth = maxDepth;
            this.many = many;
            this.type = type;
        }

        public object Generate()
        {
            var ofType = type.GenericTypeArguments[0];
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(ofType);

            var list = (IList)Activator.CreateInstance(constructedListType);

            var generator = new GeneratorFactory(depth, maxDepth, many).CreateGenerator(ofType);

            for (int i = 0; i < many; i++)
            {
                list.Add(generator.Generate());
            }

            var instance = Activator.CreateInstance(type, list);

            return instance;
        }
    }
}