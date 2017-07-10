using System;
using System.Collections;
using System.Collections.Generic;
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
            bitArrayGenerator = new BitArrayGenerator(many);
            boolGenerator = new BoolGenerator();
            byteGenerator = new ByteGenerator();
            charGenerator = new CharGenerator();
            classGenerator = new ClassGenerator(this, many, maxDepth);
            collectionGenerator = new CollectionGenerator(many);
            dateTimeGenerator = new DateTimeGenerator();
            decimalGenerator = new DecimalGenerator();
            dictionaryGenerator = new DictionaryGenerator(many);
            doubleGenerator = new DoubleGenerator();
            enumGenerator = new EnumGenerator();
            floatGenerator = new FloatGenerator();
            genericCollectionGenerator = new GenericCollectionGenerator(this, many, maxDepth);
            genericDictionaryGenerator = new GenericDictionaryGenerator(this, many, maxDepth);
            intGenerator = new IntGenerator();
            longGenerator = new LongGenerator();
            sbyteGenerator = new SbyteGenerator();
            shortGenerator = new ShortGenerator();
            stringGenerator = new StringGenerator();
            structGenerator = new StructGenerator(this, many, maxDepth);
            uintGenerator = new UintGenerator();
            ulongGenerator = new UlongGenerator();
            ushortGenerator = new UshortGenerator();
        }

        private readonly ArrayGenerator arrayGenerator;
        private readonly BitArrayGenerator bitArrayGenerator;
        private readonly BoolGenerator boolGenerator;
        private readonly ByteGenerator byteGenerator;
        private readonly CharGenerator charGenerator;
        private readonly ClassGenerator classGenerator;
        private readonly CollectionGenerator collectionGenerator;
        private readonly DateTimeGenerator dateTimeGenerator;
        private readonly DecimalGenerator decimalGenerator;
        private readonly DictionaryGenerator dictionaryGenerator;
        private readonly DoubleGenerator doubleGenerator;
        private readonly EnumGenerator enumGenerator;
        private readonly FloatGenerator floatGenerator;
        private readonly GenericCollectionGenerator genericCollectionGenerator;
        private readonly GenericDictionaryGenerator genericDictionaryGenerator;
        private readonly IntGenerator intGenerator;
        private readonly LongGenerator longGenerator;
        private readonly SbyteGenerator sbyteGenerator;
        private readonly ShortGenerator shortGenerator;
        private readonly StringGenerator stringGenerator;
        private readonly StructGenerator structGenerator;
        private readonly UintGenerator uintGenerator;
        private readonly UlongGenerator ulongGenerator;
        private readonly UshortGenerator ushortGenerator;


        public IGenerator GetGenerator(Type type)
        {
            return this.GetGenerator(type, 1);
        }

        public IGenerator GetGenerator(Type type, uint depth)
        {
            // Array
            if (type.IsArray)
            {
                arrayGenerator.Type = type;
                arrayGenerator.Depth = depth;
                return arrayGenerator;
            }

            // BitArray
            if (type == typeof(BitArray)) return bitArrayGenerator;

            if (type == typeof(bool)) return boolGenerator;

            if (type == typeof(byte)) return byteGenerator;

            if (type == typeof(char)) return charGenerator;

            // Dictionary
            if (!type.GetTypeInfo().IsGenericType && type.GetInterfaces().Any(t => t == typeof(IDictionary)))
            {
                dictionaryGenerator.Type = type;
                return dictionaryGenerator;
            }

            // ArrayList
            // Hashtable
            if (!type.GetTypeInfo().IsGenericType && type.GetInterfaces().Any(t => t == typeof(ICollection)))
            {
                collectionGenerator.Type = type;
                return collectionGenerator;
            }

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

            // Note. Queue and Stack implement IReadOnlyCollection<>
            if (type.GetTypeInfo().IsGenericType &&  
                (type.GetInterfaces().Any(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>)) ||
                    type.GetInterfaces().Any(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(IReadOnlyCollection<>))) && 
                !type.GetInterfaces().Any(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>)))
            {
                genericCollectionGenerator.Type = type;
                genericCollectionGenerator.Depth = depth;
                return genericCollectionGenerator;
            }

            // Dictionary<,>
            if (type.GetTypeInfo().IsGenericType && 
                type.GetInterfaces().Any(t => t.GetTypeInfo().IsGenericType && t.GetGenericTypeDefinition() == typeof(IDictionary<,>)))
            {
                genericDictionaryGenerator.Type = type;
                genericDictionaryGenerator.Depth = depth;
                return genericDictionaryGenerator;
            }

            if (type == typeof(sbyte)) return sbyteGenerator;

            if (type == typeof(short)) return shortGenerator;

            if (type == typeof(uint)) return uintGenerator;

            if (type == typeof(ulong)) return ulongGenerator;

            if (type == typeof(ushort)) return ushortGenerator;

            // Struct
            if (type.GetTypeInfo().IsValueType)
            {
                structGenerator.Type = type;
                structGenerator.Depth = depth;
                return structGenerator;
            }

            // Class
            if (type.GetTypeInfo().IsClass)
            {
                classGenerator.Type = type;
                classGenerator.Depth = depth;
                return classGenerator;
            }

            throw new TypeNotSupportedException(type);
        }
    }
}
