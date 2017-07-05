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
        private GeneratorContext generatorContext;

        public ComplexValueBuilder(int many, int maxDepth)
        {
            this.generatorContext = new GeneratorContext(many, 1, maxDepth);
        }

        public object GetValue(Type type)
        {
            generatorContext.Type = type;
            generatorContext.Depth = 1;
            IGenerator generator = new GeneratorFactory().CreateGenerator(generatorContext);
            return generator.Generate();
        }
    }
}
