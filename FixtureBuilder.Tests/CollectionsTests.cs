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

        // Array - not strictly a collection
        // ArrayList
        // BitArray
        // Hashtable
        // Queue
        // SortedList
        // Stack

        [Fact]
        public void BuildIntArray_ReturnsAPopulatedArrayOfInts()
        {
            // Act
            var actualResult = fixture.Create<int[]>();

            // Assert
            actualResult.Should().BeOfType(typeof(int[]));
            actualResult.Length.Should().Be(3);
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
            actualResult.Count.Should().Be(3);
        }

        [Fact]
        public void BuildBitArray_ReturnsABitArray()
        {
            // Act
            var actualResult = fixture.Create<BitArray>();

            // Assert
            actualResult.Should().BeOfType(typeof(BitArray));
            actualResult.Length.Should().Be(3);
            actualResult.Get(0).Should().BeTrue();
            actualResult.Get(1).Should().BeTrue();
            actualResult.Get(2).Should().BeTrue();
        }

        [Fact]
        public void BuildHashtable_ReturnsAHashtable()
        {
            // Act
            var actualResult = fixture.Create<Hashtable>();

            // Assert
            actualResult.Should().BeOfType(typeof(Hashtable));
            actualResult.Count.Should().Be(3);
        }
    }
}
