using System;

namespace FixtureBuilder
{
    /// <summary>
    /// Fixture class responsible generating anonymous test fixtures.
    /// </summary>
    public class Fixture : IFixture
    {
        /// <summary>
        /// How "many" elements to return for generated collections.
        /// </summary>
        public int Many { get; set; }

        /// <summary>
        /// The maximum depth the generator will traverse through the object graph when constructing complex types.
        /// </summary>
        public int MaxDepth { get; set; } 

        private IValueBuilder valueBuilder;

        private IValueBuilder ValueBuilder
        {
            get
            {
                if(valueBuilder == null)
                {
                    valueBuilder = new ComplexValueBuilder(Many, MaxDepth);
                }

                return valueBuilder;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fixture"/> class.
        /// </summary>
        /// <param name="many">How "many" elements to return for generated collections.</param>
        /// <param name="maxDepth">The maximum depth the generator will traverse through the object graph when constructing complex types.</param>
        public Fixture(int many = 3, int maxDepth = 5)
        {
            Many = many;
            MaxDepth = maxDepth;
        }

        /// <summary>
        /// Instructs fixture to start the build.
        /// </summary>
        /// <typeparam name="T">Type to build.</typeparam>
        /// <returns>A <see cref="IPropertySpecifier{T}"/>.</returns>
        public IPropertySpecifier<T> Build<T>()
        {
            return new PropertySpecifier<T>(ValueBuilder, Many);
        }

        /// <summary>
        /// Creates a fixture of type T.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <returns>An instance of T.</returns>
        public T Create<T>()
        {
            Type type = typeof(T);

            var depth = 0;
            return (T)ValueBuilder.GetValue(type, depth);
        }
    }
}
