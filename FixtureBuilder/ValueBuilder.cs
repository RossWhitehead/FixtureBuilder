using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public class ValueBuilder
    {
        private readonly int many;

        private Dictionary<Type, IGenerator> Generators { get; set; }

        public ValueBuilder(int many)
        {
            this.many = many;
            LoadGenerators();
        }

        public object GetValue(Type type)
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
                    var instance = (IList)Activator.CreateInstance(type, many);

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

                    for (int i = 0; i < many; i++)
                    {
                        list.Add(GetValue(ofType));
                    }

                    var instance = Activator.CreateInstance(type, list);

                    return instance;
                }

                if (type.GetInterfaces().Any(t => t == typeof(IEnumerable)) && type.IsConstructedGenericType)
                {
                    var instance = (IList)Activator.CreateInstance(type);

                    for (int i = 0; i < many; i++)
                    {
                        instance.Add(GetValue(type.GenericTypeArguments[0]));
                    }

                    return instance;
                }

                if (type.GetTypeInfo().IsClass)
                {
                    var constructorInfo = type.GetConstructors().OrderBy(c => c.GetParameters().Count()).First();

                    var parameters = new List<object>();

                    foreach (var parameterInfo in constructorInfo.GetParameters())
                    {
                        parameters.Add(Activator.CreateInstance(parameterInfo.ParameterType));
                    }

                    var instance = constructorInfo.Invoke(parameters.ToArray());

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
                { typeof(bool), new BoolGenerator() },
                { typeof(byte), new ByteGenerator() },
                { typeof(DateTime), new DateTimeGenerator() },
                { typeof(int), new IntGenerator() },
                { typeof(string), new StringGenerator() }
            };
        }
    }
}
