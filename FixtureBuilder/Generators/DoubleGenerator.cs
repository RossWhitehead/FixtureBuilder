namespace FixtureBuilder.Generators
{
    public class DoubleGenerator : IGenerator
    {
        private double lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
