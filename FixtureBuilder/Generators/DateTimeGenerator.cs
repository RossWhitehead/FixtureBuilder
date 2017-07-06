using System;

namespace FixtureBuilder.Generators
{
    internal class DateTimeGenerator : IGenerator
    {
        private DateTime lastDateTime = DeterministicDateTime.UtcNow.AddYears(-1);

        public object Generate()
        {
            var value = lastDateTime;
            lastDateTime = lastDateTime.AddDays(1);
            return value;
        }
    }
}
