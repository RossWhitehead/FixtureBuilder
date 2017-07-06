namespace FixtureBuilder.Generators
{
    public class SbyteGenerator : IGenerator
    {
        private sbyte lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
