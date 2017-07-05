using System;
using System.Collections.Generic;
using System.Text;

namespace FixtureBuilder.Generators
{
    public class DateTimeGenerator : IGenerator
    {
        private static DateTime LastValue { get; set; } = DeterministicDateTime.UtcNow.AddYears(-1);

        public object Generate()
        {
            var value = LastValue;
            LastValue = LastValue.AddDays(1);
            return value;
        }
    }
}
