using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class DictionaryGenerator : IGenerator
    {
        private int depth;
        private readonly int maxDepth;
        private readonly int many;
        private readonly Type type;

        public DictionaryGenerator(int depth, int maxDepth, int many, Type type)
        {
            this.depth = ++depth;
            this.maxDepth = maxDepth;
            this.many = many;
            this.type = type;
        }

        public object Generate()
        {
            var keyType = type.GenericTypeArguments[0];
            var valueType = type.GenericTypeArguments[1];

            Type dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);

            var instance = (IDictionary)Activator.CreateInstance(dictType);

            var keyGenerator = new GeneratorFactory(depth).CreateGenerator(keyType);
            var valueGenerator = new GeneratorFactory(depth).CreateGenerator(valueType);

            for (int i = 0; i < many; i++)
            {
                instance.Add(keyGenerator.Generate(), valueGenerator.Generate());
            }

            return instance;
        }
    }
}