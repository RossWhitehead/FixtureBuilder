using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class ComplexValueBuilder : IValueBuilder
    {
        private readonly GeneratorFactory generatorFactory;

        public ComplexValueBuilder(GeneratorFactory generatorFactory)
        {
            this.generatorFactory = generatorFactory;
        }

        public object GetValue(Type type)
        {
            IGenerator generator = generatorFactory.GetGenerator(type, 1);
            return generator.Generate();
        }
    }
}
