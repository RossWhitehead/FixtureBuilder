using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class ArrayGenerator : IGenerator
    {
        private readonly int depth;
        private readonly int maxDepth;
        private readonly int many;
        private readonly Type type;

        public ArrayGenerator(int depth, int maxDepth, int many, Type type)
        {
            this.depth = depth;
            this.maxDepth = maxDepth;
            this.many = many;
            this.type = type;
        }

        public object Generate()
        {
            var instance = (IList)Activator.CreateInstance(type, many);

            var generator = new GeneratorFactory(depth, maxDepth, many).CreateGenerator(instance[0].GetType());

            for (int i = 0; i < instance.Count; i++)
            {
                instance[i] = generator.Generate();
            }

            return instance;
        }
    }
}
