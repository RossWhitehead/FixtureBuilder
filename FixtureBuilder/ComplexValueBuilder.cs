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
        private readonly int many;
        private readonly int maxDepth;

        public ComplexValueBuilder(int many, int maxDepth)
        {
            this.many = many;
            this.maxDepth = maxDepth;
        }

        public object GetValue(Type type, int depth)
        {
            IGenerator generator = new GeneratorFactory().CreateGenerator(type);
            return generator.Generate();
        }
    }
}
