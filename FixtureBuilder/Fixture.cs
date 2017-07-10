using System;
using FixtureBuilder.Generators;

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
        public uint Many { get; set; }

        /// <summary>
        /// The maximum depth the generator will traverse through the object graph when constructing complex types.
        /// </summary>
        public uint MaxDepth { get; set; }

        private IValueBuilder valueBuilder;

        private IGeneratorFactory generatorFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fixture"/> class.
        /// </summary>
        /// <param name="many">How "many" elements to return for generated collections.</param>
        /// <param name="maxDepth">The maximum depth the generator will traverse through the object graph when constructing complex types.</param>
        public Fixture(uint many = 3, uint maxDepth = 5)
        {
            this.generatorFactory = new GeneratorFactory(many, maxDepth);
            this.valueBuilder = new ValueBuilder(generatorFactory);
        }

        /// <summary>
        /// Instructs fixture to start the build.
        /// </summary>
        /// <typeparam name="T">Type to build.</typeparam>
        /// <returns>A <see cref="IPropertySpecifier{T}"/>.</returns>
        public IPropertySpecifier<T> Build<T>()
        {
            return new PropertySpecifier<T>(valueBuilder);
        }

        /// <summary>
        /// Creates a fixture of type T.
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <returns>An instance of T.</returns>
        public T Create<T>()
        {
            Type type = typeof(T);

            return (T)valueBuilder.GetValue(type);
        }
    }
}
