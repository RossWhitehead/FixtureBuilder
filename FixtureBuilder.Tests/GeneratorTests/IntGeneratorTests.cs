using System;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class IntGeneratorTests
    {
        [Fact]
        public void CreateInt_ReturnsASequence()
        {
            // Act
            var fixture = new Fixture();
            var actualResult1 = fixture.Create<int>();
            var actualResult2 = fixture.Create<int>();
            var actualResult3 = fixture.Create<int>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }
    }
}
