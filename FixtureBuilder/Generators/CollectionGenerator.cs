using System;
using System.Collections;

namespace FixtureBuilder.Generators
{
    internal class CollectionGenerator : IGenerator
    {
        private uint many;

        public CollectionGenerator(uint many)
        {
            this.many = many;
        }

        public Type Type { get; set; }

        public object Generate()
        {
            var manyObjects = new Object[3];
            var instance = Activator.CreateInstance(Type, new object[] { manyObjects });

            return instance;
        }
    }
}
