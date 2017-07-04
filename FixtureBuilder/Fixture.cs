using System;

namespace FixtureBuilder
{
    public class Fixture
    {
        public int Many { get; set; } = 3;

        private ValueBuilder valueBuilder;

        private ValueBuilder ValueBuilder
        {
            get
            {
                if(valueBuilder == null)
                {
                    valueBuilder = new ValueBuilder(Many);
                }

                return valueBuilder;
            }
        }

        public Fixture()
        {
        }

        public Fixture(int many)
        {
            Many = many;
        }

        public IPropertySpecifier<T> Build<T>()
        {
            return new PropertySpecifier<T>(ValueBuilder, Many);
        }

        public T Create<T>()
        {
            Type type = typeof(T);

            return (T)ValueBuilder.GetValue(type);
        }
    }
}
