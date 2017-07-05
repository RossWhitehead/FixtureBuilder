using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FixtureBuilder.Generators
{
    internal class ClassGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public ClassGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            var constructorInfo = generatorContext.Type.GetConstructors().OrderBy(c => c.GetParameters().Count()).First();

            var parameters = new List<object>();

            foreach (var parameterInfo in constructorInfo.GetParameters())
            {
                parameters.Add(Activator.CreateInstance(parameterInfo.ParameterType));
            }

            var instance = constructorInfo.Invoke(parameters.ToArray());

            if (generatorContext.Depth <= generatorContext.MaxDepth)
            {
                generatorContext.Depth++;

                foreach (PropertyInfo propertyInfo in generatorContext.Type.GetProperties())
                {
                    generatorContext.Type = propertyInfo.PropertyType;
                    var generator = new GeneratorFactory().CreateGenerator(generatorContext);
                    propertyInfo.SetValue(instance, generator.Generate());
                }
            }

            return instance;
        }
    }
}