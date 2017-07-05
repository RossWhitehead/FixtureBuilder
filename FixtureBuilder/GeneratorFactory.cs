using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class GeneratorFactory
    {
        public GeneratorFactory() 
        {
        }

        public IGenerator CreateGenerator(GeneratorContext generatorContext)
        {
            var type = generatorContext.Type;

            if (type == typeof(bool)) return new BoolGenerator(generatorContext);
            if (type == typeof(byte)) return new ByteGenerator(generatorContext);
            if (type == typeof(char)) return new CharGenerator(generatorContext);
            if (type == typeof(DateTime)) return new DateTimeGenerator(generatorContext);
            if (type == typeof(decimal)) return new DecimalGenerator(generatorContext);
            if (type == typeof(double)) return new DoubleGenerator(generatorContext);
            if (type == typeof(float)) return new FloatGenerator(generatorContext);
            if (type == typeof(int)) return new IntGenerator(generatorContext);
            if (type == typeof(long)) return new LongGenerator(generatorContext);
            if (type == typeof(sbyte)) return new SbyteGenerator(generatorContext);
            if (type == typeof(short)) return new ShortGenerator(generatorContext);
            if (type == typeof(string)) return new StringGenerator(generatorContext);
            if (type == typeof(uint)) return new UintGenerator(generatorContext);
            if (type == typeof(ulong)) return new UlongGenerator(generatorContext);
            if (type == typeof(ushort)) return new UshortGenerator(generatorContext);
            if (type.IsArray) return new ArrayGenerator(generatorContext);
            if (type.GetInterfaces().Any(t => t.Name == "IReadOnlyCollection`1") && !type.GetInterfaces().Any(t => t.Name == "IDictionary")) return new ReadOnlyCollectionGenerator(generatorContext);
            if (type.GetInterfaces().Any(t => t.Name == "IDictionary")) return new DictionaryGenerator(generatorContext;
            if (type.GetInterfaces().Any(t => t == typeof(IEnumerable))) return new CollectionGenerator(generatorContext);
            if (type.GetTypeInfo().IsClass) return new ClassGenerator(generatorContext);

            throw new TypeNotSupportedException(type);
        }
    }
}
