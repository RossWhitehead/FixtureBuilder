namespace FixtureBuilder.Generators
{
    public class FloatGenerator : IGenerator
    {
        private float lastValue = 1;

        public object Generate()
        {
            return lastValue++;
        }
    }
}
