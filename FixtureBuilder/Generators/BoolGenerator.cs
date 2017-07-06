namespace FixtureBuilder.Generators
{
    internal class BoolGenerator : IGenerator
    {
        private bool lastValue = false;

        public object Generate()
        {
            lastValue = !lastValue;
            return lastValue;
        }
    }
}
