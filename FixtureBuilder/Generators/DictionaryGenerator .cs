using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class DictionaryGenerator : IGenerator
    {
        private uint many;

        public DictionaryGenerator(uint many)
        {
            this.many = many;
        }

        public Type Type { get; set; }

        public object Generate()
        {
            var instance = (IDictionary)Activator.CreateInstance(Type);

            for (int i = 0; i < many; i++)
            {
                instance.Add(new object(), new object());
            }

            return instance;
        }
    }
}