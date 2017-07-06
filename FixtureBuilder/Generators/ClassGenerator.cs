using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FixtureBuilder.Generators
{
    internal class ClassGenerator : IGenerator
    {
        private readonly GeneratorFactory generatorFactory;
        private uint many;
        private uint maxDepth;

        public ClassGenerator(GeneratorFactory generatorFactory, uint many, uint maxDepth)
        {
            this.generatorFactory = generatorFactory;
            this.many = many;
            this.maxDepth = maxDepth;
        }

        public Type Type { get; set; }
        public uint Depth { get; set; }

        public object Generate()
        {
            var constructorInfo = this.Type.GetConstructors().OrderBy(c => c.GetParameters().Count()).First();

            var parameters = new List<object>();

            foreach (var parameterInfo in constructorInfo.GetParameters())
            {
                parameters.Add(Activator.CreateInstance(parameterInfo.ParameterType));
            }

            var instance = constructorInfo.Invoke(parameters.ToArray());

            if (Depth <= maxDepth)
            {
                Depth++;

                foreach (PropertyInfo propertyInfo in this.Type.GetProperties())
                {
                    var propertyType = propertyInfo.PropertyType;
                    var generator = generatorFactory.GetGenerator(propertyType, Depth);
                    propertyInfo.SetValue(instance, generator.Generate());
                }
            }

            return instance;
        }
    }
}