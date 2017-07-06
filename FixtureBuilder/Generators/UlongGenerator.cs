namespace FixtureBuilder.Generators
{
    public class UlongGenerator : IGenerator
    {
        private ulong lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
