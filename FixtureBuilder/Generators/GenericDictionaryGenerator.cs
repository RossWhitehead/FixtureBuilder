﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class GenericDictionaryGenerator : IGenerator
    {
        private readonly GeneratorFactory generatorFactory;
        private uint many;
        private uint maxDepth;

        public GenericDictionaryGenerator(GeneratorFactory generatorFactory, uint many, uint maxDepth)
        {
            this.generatorFactory = generatorFactory;
            this.many = many;
            this.maxDepth = maxDepth;
        }

        public Type Type { get; set; }
        public uint Depth { get; set; }

        public object Generate()
        {
            var keyType = this.Type.GenericTypeArguments[0];
            var valueType = this.Type.GenericTypeArguments[1];

            var instance = (IDictionary)Activator.CreateInstance(Type);

            var keyGenerator = generatorFactory.GetGenerator(keyType);
            var valueGenerator = generatorFactory.GetGenerator(valueType);

            for (int i = 0; i < many; i++)
            {
                instance.Add(keyGenerator.Generate(), valueGenerator.Generate());
            }

            return instance;
        }
    }
}