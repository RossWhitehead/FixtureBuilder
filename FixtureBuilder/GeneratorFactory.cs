using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class GeneratorFactory
    {
        public GeneratorFactory(uint many, uint maxDepth)
        {
            arrayGenerator = new ArrayGenerator(this, many, maxDepth);
            boolGenerator = new BoolGenerator();
            byteGenerator = new ByteGenerator();
            charGenerator = new CharGenerator();
            classGenerator = new ClassGenerator(this, many, maxDepth);
            collectionGenerator = new CollectionGenerator(this, many, maxDepth);
            dateTimeGenerator = new DateTimeGenerator();
            decimalGenerator = new DecimalGenerator();
            dictionaryGenerator = new DictionaryGenerator(this, many, maxDepth);
            doubleGenerator = new DoubleGenerator();
            enumGenerator = new EnumGenerator();
            floatGenerator = new FloatGenerator();
            intGenerator = new IntGenerator();
            longGenerator = new LongGenerator();
            readOnlyCollectionGenerator = new ReadOnlyCollectionGenerator(this, many, maxDepth);
            sbyteGenerator = new SbyteGenerator();
            shortGenerator = new ShortGenerator();
            stringGenerator = new StringGenerator();
            uintGenerator = new UintGenerator();
            ulongGenerator = new UlongGenerator();
            ushortGenerator = new UshortGenerator();
        }

        private readonly ArrayGenerator arrayGenerator;
        private readonly BoolGenerator boolGenerator;
        private readonly ByteGenerator byteGenerator;
        private readonly CharGenerator charGenerator;
        private readonly ClassGenerator classGenerator;
        private readonly DateTimeGenerator dateTimeGenerator;
        private readonly DecimalGenerator decimalGenerator;
        private readonly DoubleGenerator doubleGenerator;
        private readonly EnumGenerator enumGenerator;
        private readonly FloatGenerator floatGenerator;
        private readonly IntGenerator intGenerator;
        private readonly LongGenerator longGenerator;
        private readonly SbyteGenerator sbyteGenerator;
        private readonly ShortGenerator shortGenerator;
        private readonly StringGenerator stringGenerator;
        private readonly UintGenerator uintGenerator;
        private readonly UlongGenerator ulongGenerator;
        private readonly UshortGenerator ushortGenerator;
        private readonly ReadOnlyCollectionGenerator readOnlyCollectionGenerator;
        private readonly DictionaryGenerator dictionaryGenerator;
        private readonly CollectionGenerator collectionGenerator;

        public IGenerator GetGenerator(Type type)
        {
            return this.GetGenerator(type, 1);
        }

        public IGenerator GetGenerator(Type type, uint depth)
        {
            if (type.IsArray)
            {
                arrayGenerator.Type = type;
                arrayGenerator.Depth = depth;
                return arrayGenerator;
            } 

            if (type == typeof(bool)) return boolGenerator;

            if (type == typeof(byte)) return byteGenerator;

            if (type == typeof(char)) return charGenerator;

            if (type == typeof(DateTime)) return dateTimeGenerator;

            if (type == typeof(decimal)) return decimalGenerator;

            if (type == typeof(double)) return doubleGenerator;

            if (type == typeof(float)) return floatGenerator;

            if (type == typeof(int)) return intGenerator;

            if (type == typeof(long)) return longGenerator;

            // Must be before the collection check
            if (type == typeof(string)) return stringGenerator;

            if (type.GetTypeInfo().IsEnum)
            {
                enumGenerator.Type = type;
                return enumGenerator;
            }

            // TODO: Improve checks
            if (type.GetInterfaces().Any(t => t.Name == "IReadOnlyCollection`1") && !type.GetInterfaces().Any(t => t.Name == "IDictionary"))
            {
                readOnlyCollectionGenerator.Type = type;
                readOnlyCollectionGenerator.Depth = depth;
                return readOnlyCollectionGenerator;
            }

            // The check for dictionary needs to be after the check for readonlycollection (see above)
            // And needs to be befoe the IEnumerable and IsClass checks.
            if (type.GetInterfaces().Any(t => t.Name == "IDictionary"))
            {
                dictionaryGenerator.Type = type;
                dictionaryGenerator.Depth = depth;
                return dictionaryGenerator;
            }

            // TODO: Differentiate between IEnumerable and IEnumerable<,>
            if (type.GetInterfaces().Any(t => t == typeof(IEnumerable)))
            {
                collectionGenerator.Type = type;
                collectionGenerator.Depth = depth;
                return collectionGenerator;
            }

            if (type.GetTypeInfo().IsClass)
            {
                classGenerator.Type = type;
                classGenerator.Depth = depth;
                return classGenerator;
            }

            if (type == typeof(sbyte)) return sbyteGenerator;

            if (type == typeof(short)) return shortGenerator;

            if (type == typeof(uint)) return uintGenerator;

            if (type == typeof(ulong)) return ulongGenerator;

            if (type == typeof(ushort)) return ushortGenerator;

            throw new TypeNotSupportedException(type);
        }
    }
}
