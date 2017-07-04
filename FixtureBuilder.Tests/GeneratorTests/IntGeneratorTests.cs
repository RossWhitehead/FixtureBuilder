using System;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class IntGeneratorTests
    {
        [Fact]
        public void BuildInt_ReturnsASequence()
        {
            // Act
            var builder = new Fixture();
            var actualResult1 = builder.Create<int>();
            var actualResult2 = builder.Create<int>();
            var actualResult3 = builder.Create<int>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }
    }
}
