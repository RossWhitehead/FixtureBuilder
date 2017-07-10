using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class GenericCollectionGenerator : IGenerator
    {
        private readonly GeneratorFactory generatorFactory;
        private uint many;
        private uint maxDepth;

        public GenericCollectionGenerator(GeneratorFactory generatorFactory, uint many, uint maxDepth)
        {
            this.generatorFactory = generatorFactory;
            this.many = many;
            this.maxDepth = maxDepth;
        }

        public Type Type { get; set; }
        public uint Depth { get; set; }

        public object Generate()
        {
            var genericType = Type.GenericTypeArguments[0];
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(genericType);

            var list = (IList)Activator.CreateInstance(constructedListType);

            var generator = generatorFactory.GetGenerator(genericType, ++Depth);

            for (int i = 0; i < many; i++)
            {
                list.Add(generator.Generate());
            }

            var instance = Activator.CreateInstance(Type, list);

            return instance;
        }
    }
}
