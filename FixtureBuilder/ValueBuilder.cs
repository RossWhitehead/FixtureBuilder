using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class ValueBuilder : IValueBuilder
    {
        private readonly int many;
        private readonly int maxDepth;

        private Dictionary<Type, IGenerator> Generators { get; set; }

        public ValueBuilder(int many, int maxDepth)
        {
            this.many = many;
            this.maxDepth = maxDepth;
            LoadGenerators();
        }

        public object GetValue(Type type, int depth)
        {
            IGenerator generator;

            var hasGenerator = Generators.TryGetValue(type, out generator);

            if (hasGenerator)
            {
                return generator.Generate();
            }
            else
            {
                // Arrays
                if (type.IsArray)
                {
                    var instance = (IList)Activator.CreateInstance(type, many);

                    for (int i = 0; i < instance.Count; i++)
                    {
                        instance[i] = GetValue(instance[i].GetType(), depth);
                    }

                    return instance;
                }

                // Read only collections
                if (type.GetInterfaces().Any(t => t.Name == "IReadOnlyCollection`1") &&
                    !type.GetInterfaces().Any(t => t.Name == "IDictionary"))
                {
                    var ofType = type.GenericTypeArguments[0];
                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(ofType);

                    var list = (IList)Activator.CreateInstance(constructedListType);

                    for (int i = 0; i < many; i++)
                    {
                        list.Add(GetValue(ofType, depth));
                    }

                    var instance = Activator.CreateInstance(type, list);

                    return instance;
                }

                // Dictionaries
                if (type.GetInterfaces().Any(t => t.Name == "IDictionary"))
                {
                    var keyType = type.GenericTypeArguments[0];
                    var valueType = type.GenericTypeArguments[1];

                    Type dictType = typeof(Dictionary<,>).MakeGenericType(keyType, valueType);

                    var instance = (IDictionary)Activator.CreateInstance(dictType);

                    for (int i = 0; i < many; i++)
                    {
                        instance.Add(GetValue(keyType, depth), GetValue(valueType, depth));
                    }

                    return instance;
                }

                // Collections
                if (type.GetInterfaces().Any(t => t == typeof(IEnumerable)))
                {
                    var instance = (IList)Activator.CreateInstance(type);

                    for (int i = 0; i < many; i++)
                    {
                        instance.Add(GetValue(type.GenericTypeArguments[0], depth));
                    }

                    return instance;
                }

                // Classes
                if (type.GetTypeInfo().IsClass)
                {
                    var constructorInfo = type.GetConstructors().OrderBy(c => c.GetParameters().Count()).First();

                    var parameters = new List<object>();

                    foreach (var parameterInfo in constructorInfo.GetParameters())
                    {
                        parameters.Add(Activator.CreateInstance(parameterInfo.ParameterType));
                    }

                    var instance = constructorInfo.Invoke(parameters.ToArray());

                    if (depth < maxDepth)
                    {
                        foreach (PropertyInfo propertyInfo in type.GetProperties())
                        {
                            propertyInfo.SetValue(instance, GetValue(propertyInfo.PropertyType, ++depth));
                        }
                    }

                    return instance;
                }
                else
                {
                    throw new TypeNotSupportedException(type);
                }
            }
        }

        private void LoadGenerators()
        {
            Generators = new Dictionary<Type, IGenerator>()
            {
                { typeof(bool), new BoolGenerator() },
                { typeof(byte), new ByteGenerator() },
                { typeof(char), new CharGenerator() },
                { typeof(DateTime), new DateTimeGenerator() },
                { typeof(decimal), new DecimalGenerator() },
                { typeof(double), new DoubleGenerator() },
                { typeof(float), new FloatGenerator() },
                { typeof(int), new IntGenerator() },
                { typeof(long), new LongGenerator() },
                { typeof(sbyte), new SbyteGenerator() },
                { typeof(short), new ShortGenerator() },
                { typeof(string), new StringGenerator() },
                { typeof(uint), new UintGenerator() },
                { typeof(ulong), new UlongGenerator() },
                { typeof(ushort), new UshortGenerator() }
            };
        }
    }
}
