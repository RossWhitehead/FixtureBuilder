using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class Builder
    {
        private Dictionary<Type, IGenerator> Generators { get; set; }
        public int Many { get; set; } = 3;

        public Builder()
        {
            LoadGenerators();
        }

        public T Build<T>()
        {
            Type type = typeof(T);

            return (T)GetValue(type);
        }

        private object GetValue(Type type)
        {
            IGenerator generator;
            var hasGenerator = Generators.TryGetValue(type, out generator);

            if (hasGenerator)
            {
                return generator.Generate();
            }
            else
            {
                if (type.IsArray)
                {
                    var instance = (IList)Activator.CreateInstance(type, Many);

                    for (int i = 0; i < instance.Count; i++)
                    {
                        instance[i] = GetValue(instance[i].GetType());
                    }

                    return instance;
                }

                if (type.GetInterfaces().Any(t => t.Name == "IReadOnlyCollection`1"))
                {
                    var ofType = type.GenericTypeArguments[0];
                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(ofType);

                    var list = (IList)Activator.CreateInstance(constructedListType);

                    for (int i = 0; i < Many; i++)
                    {
                        list.Add(GetValue(ofType));
                    }

                    var instance = Activator.CreateInstance(type, list);

                    return instance;
                }

                if (type.GetInterfaces().Any(t => t == typeof(IEnumerable)) && type.IsConstructedGenericType)
                {
                    var instance = (IList)Activator.CreateInstance(type);

                    for (int i = 0; i < Many; i++)
                    {
                        instance.Add(GetValue(type.GenericTypeArguments[0]));
                    }

                    return instance;
                }

                if (type.GetTypeInfo().IsClass)
                {
                    var instance = Activator.CreateInstance(type);

                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        propertyInfo.SetValue(instance, GetValue(propertyInfo.PropertyType));
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
                { typeof(int), new IntGenerator() },
                { typeof(string), new StringGenerator() },
                { typeof(bool), new BoolGenerator() },
                { typeof(byte), new ByteGenerator() }
            };
        }
    }
}
