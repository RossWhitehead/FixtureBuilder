using System;
using FixtureBuilder;
using FluentAssertions;
using Xunit;

namespace Fixturefixture.Tests
{
    public class ValueTypeTests
    {
        private Fixture fixture;

        public ValueTypeTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void CreateBool_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<bool>();
            var actualResult2 = fixture.Create<bool>();
            var actualResult3 = fixture.Create<bool>();

            // Assert
            actualResult1.Should().Be(true);
            actualResult2.Should().Be(false);
            actualResult3.Should().Be(true);
        }

        [Fact]
        public void CreateByte_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<byte>();
            var actualResult2 = fixture.Create<byte>();
            var actualResult3 = fixture.Create<byte>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateChar_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<char>();
            var actualResult2 = fixture.Create<char>();
            var actualResult3 = fixture.Create<char>();

            // Assert
            actualResult1.Should().Be(Convert.ToChar(1));
            actualResult2.Should().Be(Convert.ToChar(2));
            actualResult3.Should().Be(Convert.ToChar(3));
        }

        [Fact]
        public void CreateDecimal_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<decimal>();
            var actualResult2 = fixture.Create<decimal>();
            var actualResult3 = fixture.Create<decimal>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateDouble_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<double>();
            var actualResult2 = fixture.Create<double>();
            var actualResult3 = fixture.Create<double>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateEnum_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<TestEnum>();
            var actualResult2 = fixture.Create<TestEnum>();
            var actualResult3 = fixture.Create<TestEnum>();

            // Assert
            actualResult1.Should().Be(TestEnum.One);
            actualResult2.Should().Be(TestEnum.Two);
            actualResult3.Should().Be(TestEnum.One);
        }

        [Fact]
        public void CreateEnum_ThrowsTypeNotSupportedException_WhereEnumHasNoValues()
        {
            // Act
            Action act = () => fixture.Create<EmptyEnum>();
         
            // Assert
            act.ShouldThrow<TypeNotSupportedException>();
        }

        [Fact]
        public void CreateFloat_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<float>();
            var actualResult2 = fixture.Create<float>();
            var actualResult3 = fixture.Create<float>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateInt_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<int>();
            var actualResult2 = fixture.Create<int>();
            var actualResult3 = fixture.Create<int>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateLong_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<long>();
            var actualResult2 = fixture.Create<long>();
            var actualResult3 = fixture.Create<long>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateSbyte_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<sbyte>();
            var actualResult2 = fixture.Create<sbyte>();
            var actualResult3 = fixture.Create<sbyte>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateShort_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<short>();
            var actualResult2 = fixture.Create<short>();
            var actualResult3 = fixture.Create<short>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void BuildString_ReturnsAGuidAsString()
        {
            // Act
            var actualResult = fixture.Create<string>();

            Guid actualGuid;
            var isGuid = Guid.TryParse(actualResult, out actualGuid);

            // Assert
            isGuid.Should().Be(true);
        }

        [Fact]
        public void CreateUlong_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<ulong>();
            var actualResult2 = fixture.Create<ulong>();
            var actualResult3 = fixture.Create<ulong>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateUshort_ReturnsASequence()
        {
            // Act
            var actualResult1 = fixture.Create<ushort>();
            var actualResult2 = fixture.Create<ushort>();
            var actualResult3 = fixture.Create<ushort>();

            // Assert
            actualResult1.Should().Be(1);
            actualResult2.Should().Be(2);
            actualResult3.Should().Be(3);
        }

        [Fact]
        public void CreateStruct_ReturnsAStruct()
        {
            // Act
            var actualResult1 = fixture.Create<TestStruct>();

            // Assert
            actualResult1.Should().BeOfType(typeof(TestStruct));
        }
    }

    public enum EmptyEnum
    {
    }

    public enum TestEnum
    {
        One = 1,
        Two = 2
    }

    public struct TestStruct
    {
        public decimal prop1;
        public string prop2;
        public ChildStruct childStruct;
    }

    public struct ChildStruct
    {
        public int prop1;
    }
}
