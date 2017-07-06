namespace FixtureBuilder.Generators
{
    internal class ByteGenerator : IGenerator
    {
        private byte lastByte = 1;

        public object Generate()
        {
            return lastByte++;
        }
    }
}
