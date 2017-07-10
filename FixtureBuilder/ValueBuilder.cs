using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class ValueBuilder : IValueBuilder
    {
        private readonly IGeneratorFactory generatorFactory;

        public ValueBuilder(IGeneratorFactory generatorFactory)
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
