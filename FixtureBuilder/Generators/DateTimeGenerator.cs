namespace FixtureBuilder.Generators
{
    internal class DateTimeGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public DateTimeGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            var value = generatorContext.LastDateTime;
            generatorContext.LastDateTime = generatorContext.LastDateTime.AddDays(1);
            return value;
        }
    }
}
