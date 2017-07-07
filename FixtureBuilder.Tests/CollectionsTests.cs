using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class CollectionsTests
    {
        private Fixture fixture;

        public CollectionsTests()
        {
            this.fixture = new Fixture();
        }

        [Fact]
        public void BuildIntArray_ReturnsAnArrayOfInts()
        {
            // Act
            var actualResult = fixture.Create<int[]>();

            // Assert
            actualResult.Should().BeOfType(typeof(int[]));
        }

        [Fact]
        public void BuildIntArray_ReturnsAPopulatedArrayWith3Items()
        {
            // Act
            var actualResult = fixture.Create<int[]>();

            // Assert
            actualResult.Should().HaveCount(3);
            actualResult[0].Should().BePositive();
            actualResult[1].Should().BePositive();
            actualResult[2].Should().BePositive();
        }


        [Fact]
        public void BuildArrayList_ReturnsAnArrayList()
        {
            // Act
            var actualResult = fixture.Create<ArrayList>();

            // Assert
            actualResult.Should().BeOfType(typeof(ArrayList));
        }

        [Fact]
        public void BuildList_ReturnsAList()
        {
            // Act
            var actualResult = fixture.Create<List<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(List<int>));
        }

        [Fact]
        public void BuildList_ReturnsAPopulatedListWith3Items()
        {
            // Act
            var actualResult = fixture.Create<List<int>>();

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
            var actualResult = fixture.Create<ReadOnlyCollection<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(ReadOnlyCollection<int>));
        }

        [Fact]
        public void BuildDictionary_ReturnsADictionary()
        {
            // Act
            var actualResult = fixture.Create<Dictionary<int, string>>();

            // Assert
            actualResult.Should().BeOfType(typeof(Dictionary<int, string>));
        }
    }
}
