using System;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class DateTimeGeneratorTests
    {
        [Fact]
        public void BuildDateTime_ReturnsASequenceOfDateTimes()
        {
            // Act
            DeterministicDateTime.UtcNowFunc = () => new DateTime(2016, 3, 4);

            var builder = new Builder();
            var actualResult1 = builder.Build<DateTime>();
            var actualResult2 = builder.Build<DateTime>();
            var actualResult3 = builder.Build<DateTime>();

            // Assert
            actualResult1.Should().Be(DeterministicDateTime.UtcNow.AddYears(-1));
            actualResult2.Should().Be(DeterministicDateTime.UtcNow.AddYears(-1).AddDays(1));
            actualResult3.Should().Be(DeterministicDateTime.UtcNow.AddYears(-1).AddDays(2));
        }
    }
}
