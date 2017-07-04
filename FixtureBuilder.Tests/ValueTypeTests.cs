using System;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class ValueTypeTests
    {
        [Fact]
        public void BuildInt_ReturnsAnInt()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<int>();

            // Assert
            actualResult.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void BuildString_ReturnsAGuidAsString()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<string>();

            Guid actualGuid;
            var isGuid = Guid.TryParse(actualResult, out actualGuid);

            // Assert
            isGuid.Should().Be(true);
        }

        [Fact]
        public void BuildIntArray_ReturnsAnArrayOfInts()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<int[]>();

            // Assert
            actualResult.Should().BeOfType(typeof(int[]));
        }

        [Fact]
        public void BuildBool_ReturnsASequenceOfBools()
        {
            // Act
            var builder = new Fixture();
            var actualResult1 = builder.Create<bool>();
            var actualResult2 = builder.Create<bool>();
            var actualResult3 = builder.Create<bool>();

            // Assert
            actualResult1.Should().Be(true);
            actualResult2.Should().Be(false);
            actualResult3.Should().Be(true);
        }

        [Fact]
        public void BuildByte_ReturnsASequenceOfBytes()
        {
            // Act
            var builder = new Fixture();
            var actualResult1 = builder.Create<byte>();
            var actualResult2 = builder.Create<byte>();
            var actualResult3 = builder.Create<byte>();

            // Assert
            actualResult1.Should().BeOfType(typeof(byte));
            actualResult2.Should().BeOfType(typeof(byte));
            actualResult3.Should().BeOfType(typeof(byte));

            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }
    }
}
