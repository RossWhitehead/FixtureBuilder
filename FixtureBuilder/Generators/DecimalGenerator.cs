namespace FixtureBuilder.Generators
{
    internal class DecimalGenerator : IGenerator
    {
        private decimal lastDecimal = 1;

        public object Generate()
        {
            return lastDecimal++;
        }
    }
}
