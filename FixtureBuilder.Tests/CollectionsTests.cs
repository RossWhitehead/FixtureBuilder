using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class CollectionsTests
    {
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
        public void BuildIntArray_ReturnsAPopulatedArrayWith3Items()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<int[]>();

            // Assert
            actualResult.Should().HaveCount(3);
            actualResult[0].Should().BePositive();
            actualResult[1].Should().BePositive();
            actualResult[2].Should().BePositive();
        }

        [Fact]
        public void BuildList_ReturnsAList()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<List<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(List<int>));
        }

        [Fact]
        public void BuildList_ReturnsAPopulatedListWith3Items()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<List<int>>();

            // Assert
            actualResult.Should().HaveCount(3);
            actualResult[0].Should().BePositive();
            actualResult[1].Should().BePositive();
            actualResult[2].Should().BePositive();
        }

        [Fact]
        public void BuildReadOnlyCollection_ReturnsAReadOnlyCollection()
        {
            // Act
            var builder = new Fixture();
            var actualResult = builder.Create<ReadOnlyCollection<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(ReadOnlyCollection<int>));
        }
    }
}
