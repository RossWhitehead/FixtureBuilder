using System;
using System.Collections;
using System.Collections.Generic;

namespace FixtureBuilder.Generators
{
    internal class DictionaryGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public DictionaryGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            var keyType = generatorContext.Type.GenericTypeArguments[0];
            var valueType = generatorContext.Type.GenericTypeArguments[1];

            Type dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);

            var instance = (IDictionary)Activator.CreateInstance(dictType);

            var keyGenerator = new GeneratorFactory().CreateGenerator(keyType);
            var valueGenerator = new GeneratorFactory().CreateGenerator(valueType);

            for (int i = 0; i < many; i++)
            {
                instance.Add(keyGenerator.Generate(), valueGenerator.Generate());
            }

            return instance;
        }
    }
}