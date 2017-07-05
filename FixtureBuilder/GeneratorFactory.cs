using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class GeneratorFactory
    {
        private readonly int depth;
        private readonly int maxDepth;
        private readonly int many;

        public GeneratorFactory() : this(1)
        {
        }

        public GeneratorFactory(int depth) : this(depth, 5)
        { 
        }

        public GeneratorFactory(int depth, int maxDepth) : this(depth, maxDepth, 3)
        {
        }

        public GeneratorFactory(int depth, int maxDepth, int many)
        {
            this.depth = depth;
            this.maxDepth = maxDepth;
            this.many = many;
        }

        public IGenerator CreateGenerator(Type type)
        {
            if (type == typeof(bool)) return new BoolGenerator();
            if (type == typeof(byte)) return new ByteGenerator();
            if (type == typeof(char)) return new CharGenerator();
            if (type == typeof(DateTime)) return new DateTimeGenerator();
            if (type == typeof(decimal)) return new DecimalGenerator();
            if (type == typeof(double)) return new DoubleGenerator();
            if (type == typeof(float)) return new FloatGenerator();
            if (type == typeof(int)) return new IntGenerator();
            if (type == typeof(long)) return new LongGenerator();
            if (type == typeof(sbyte)) return new SbyteGenerator();
            if (type == typeof(short)) return new ShortGenerator();
            if (type == typeof(string)) return new StringGenerator();
            if (type == typeof(uint)) return new UintGenerator();
            if (type == typeof(ulong)) return new UlongGenerator();
            if (type == typeof(ushort)) return new UshortGenerator();
            if (type.IsArray) return new ArrayGenerator(depth, maxDepth, many, type);
            if (type.GetInterfaces().Any(t => t.Name == "IReadOnlyCollection`1") && !type.GetInterfaces().Any(t => t.Name == "IDictionary"))
                return new ReadOnlyCollectionGenerator(depth, maxDepth, many, type);
            if (type.GetInterfaces().Any(t => t.Name == "IDictionary")) return new DictionaryGenerator(depth, maxDepth, many, type);
            if (type.GetInterfaces().Any(t => t == typeof(IEnumerable))) return new CollectionGenerator(depth, maxDepth, many, type);
            if (type.GetTypeInfo().IsClass) return new ClassGenerator(depth, maxDepth, many, type);

            throw new TypeNotSupportedException(type);
        }
    }
}
