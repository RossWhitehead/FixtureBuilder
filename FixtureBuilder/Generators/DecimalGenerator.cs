namespace FixtureBuilder.Generators
{
    internal class DecimalGenerator : IGenerator
    {
        private GeneratorContext generatorContext;

        public DecimalGenerator(GeneratorContext generatorContext)
        {
            this.generatorContext = generatorContext;
        }

        public object Generate()
        {
            return generatorContext.LastDecimal++;
        }
    }
}
