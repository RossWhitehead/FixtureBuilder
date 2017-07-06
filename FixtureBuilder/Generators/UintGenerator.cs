namespace FixtureBuilder.Generators
{
    public class UintGenerator : IGenerator
    {
        private uint lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
