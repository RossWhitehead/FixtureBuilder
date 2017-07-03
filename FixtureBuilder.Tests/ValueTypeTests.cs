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
            var builder = new Builder();
            var actualResult = builder.Build<int>();

            // Assert
            actualResult.Should().BeOfType(typeof(int));
        }

        [Fact]
        public void BuildInt_ReturnsASequence()
        {
            // Act
            var builder = new Builder();
            var actualResult1 = builder.Build<int>();
            var actualResult2 = builder.Build<int>();
            var actualResult3 = builder.Build<int>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void BuildString_ReturnsAGuidAsString()
        {
            // Act
            var builder = new Builder();
            var actualResult = builder.Build<string>();

            Guid actualGuid;
            var isGuid = Guid.TryParse(actualResult, out actualGuid);

            // Assert
            isGuid.Should().Be(true);
        }

        [Fact]
        public void BuildIntArray_ReturnsAnArrayOfInts()
        {
            // Act
            var builder = new Builder();
            var actualResult = builder.Build<int[]>();

            // Assert
            actualResult.Should().BeOfType(typeof(int[]));
        }

        [Fact]
        public void BuildBool_ReturnsASequenceOfBools()
        {
            // Act
            var builder = new Builder();
            var actualResult1 = builder.Build<bool>();
            var actualResult2 = builder.Build<bool>();
            var actualResult3 = builder.Build<bool>();

            // Assert
            actualResult1.Should().Be(true);
            actualResult2.Should().Be(false);
            actualResult3.Should().Be(true);
        }

        [Fact]
        public void BuildByte_ReturnsASequenceOfBytes()
        {
            // Act
            var builder = new Builder();
            var actualResult1 = builder.Build<byte>();
            var actualResult2 = builder.Build<byte>();
            var actualResult3 = builder.Build<byte>();

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
