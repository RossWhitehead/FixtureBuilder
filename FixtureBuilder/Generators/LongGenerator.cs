namespace FixtureBuilder.Generators
{
    public class LongGenerator : IGenerator
    {
        private long lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
