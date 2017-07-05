namespace FixtureBuilder.Generators
{
    public class LongGenerator : IGenerator
    {
        private static long LastValue { get; set; } = 1;

        public object Generate()
        {
            return LastValue++;
        }
    }
}
