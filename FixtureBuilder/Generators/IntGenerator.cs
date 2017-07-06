namespace FixtureBuilder.Generators
{
    public class IntGenerator : IGenerator
    {
        private int lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
