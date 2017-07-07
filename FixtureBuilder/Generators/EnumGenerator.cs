using System;
using System.Collections.Generic;
using System.Linq;

namespace FixtureBuilder.Generators
{
    public class EnumGenerator : IGenerator
    {
        private Dictionary<Type, int> lastValues;

        public EnumGenerator()
        {
            lastValues = new Dictionary<Type, int>();
        }

        public Type Type { get; set; }

        public object Generate()
        {
            var hasValue = lastValues.TryGetValue(Type, out int lastValue);

            int nextValue;

            if (hasValue)
            {
                nextValue = GetNextValue(lastValue);
                lastValues[Type] = nextValue;
            }
            else
            {
                nextValue = GetNextValue(null);
                lastValues.Add(Type, nextValue);
            }

            var enumValue = Enum.ToObject(Type, nextValue);

            return enumValue;
        }

        private int GetNextValue(int? lastValue)
        {
            var values = (IEnumerable<int>)Enum.GetValues(Type);

            if (!values.Any())
            {
                throw new TypeNotSupportedException(Type, "Enum cannot be generated as it contains no values.");
            }

            var nextValue = values.First();

            if (lastValue.HasValue)
            { 
                int possibleNextValue = values.SkipWhile(e => e != lastValue).Skip(1).FirstOrDefault();

                if(possibleNextValue > 0)
                {
                    nextValue = possibleNextValue;
                }
            }            

            return nextValue;
        }
    }
}
