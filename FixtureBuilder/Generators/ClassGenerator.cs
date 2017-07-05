using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FixtureBuilder.Generators
{
    internal class ClassGenerator : IGenerator
    {
        private int depth;
        private readonly int maxDepth;
        private readonly int many;
        private readonly Type type;

        public ClassGenerator(int depth, int maxDepth, int many, Type type)
        {
            this.depth = ++depth;
            this.maxDepth = maxDepth;
            this.many = many;
            this.type = type;
        }

        public object Generate()
        {
            var constructorInfo = type.GetConstructors().OrderBy(c => c.GetParameters().Count()).First();

            var parameters = new List<object>();

            foreach (var parameterInfo in constructorInfo.GetParameters())
            {
                parameters.Add(Activator.CreateInstance(parameterInfo.ParameterType));
            }

            var instance = constructorInfo.Invoke(parameters.ToArray());

            if (depth <= maxDepth)
            {
                foreach (PropertyInfo propertyInfo in type.GetProperties())
                {
                    var generator = new GeneratorFactory(depth, maxDepth, many).CreateGenerator(propertyInfo.PropertyType);
                    propertyInfo.SetValue(instance, generator.Generate());
                }
            }

            return instance;
        }
    }
}