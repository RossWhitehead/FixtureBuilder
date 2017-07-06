namespace FixtureBuilder.Generators
{
    public class UshortGenerator : IGenerator
    {
        private ushort lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
