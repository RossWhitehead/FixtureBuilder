﻿using System;
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
            var instance = (IList)Activator.CreateInstance(Type, new object[] { (int)many });

            for (int i = 0; i < many; i ++)
            {
                instance.Add(new object());
            }

            return instance;
        }
    }
}
