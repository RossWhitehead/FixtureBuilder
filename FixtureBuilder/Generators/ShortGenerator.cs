namespace FixtureBuilder.Generators
{
    public class ShortGenerator : IGenerator
    {
        private short lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
