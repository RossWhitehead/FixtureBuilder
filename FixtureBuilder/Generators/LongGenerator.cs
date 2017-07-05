namespace FixtureBuilder.Generators
{
    public class LongGenerator : IGenerator
    {
        private static long LastValue { get; set; } = seed;
        private static readonly long seed = 1;

        public object Generate()
        {
            return LastValue++;
        }

        public static void Reset()
        {
            LastValue = seed;
        }
    }
}
