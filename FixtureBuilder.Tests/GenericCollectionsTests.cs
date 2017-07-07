using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class GenericCollectionsTests
    {
        private Fixture fixture;

        public GenericCollectionsTests()
        {
            // Arrange
            this.fixture = new Fixture();
        }

        // Dictionary<,>
        // HashSet<>
        // LinkedList<>
        // List<>
        // Queue<>
        // ReadOnlyCollection<,>
        // SortedDictionary<,>
        // SortedList<,>
        // SortedSet<>
        // Stack<>

        [Fact]
        public void BuildDictionary_ReturnsAPopulatedDictionary()
        {
            // Act
            var actualResult = fixture.Create<Dictionary<int, string>>();

            // Assert
            actualResult.Should().BeOfType(typeof(Dictionary<int, string>));
            actualResult.Count.Should().Be(3);
            actualResult.Keys.All(x => x > 0).Should().BeTrue();
            actualResult.Values.All(x => x.Length > 0).Should().BeTrue();
        }

        [Fact]
        public void BuildHashSet_ReturnsAPopulatedHashSet()
        {
            // Act
            var actualResult = fixture.Create<HashSet<byte>>();

            // Assert
            actualResult.Should().BeOfType(typeof(HashSet<byte>));
            actualResult.Count.Should().Be(3);
            actualResult.All(x => x > 0).Should().BeTrue();
        }

        [Fact]
        public void BuildLinkedList_ReturnsAPopulatedLinkedList()
        {
            // Act
            var actualResult = fixture.Create<LinkedList<double>>();

            // Assert
            actualResult.Should().BeOfType(typeof(LinkedList<double>));
            actualResult.Count.Should().Be(3);
            actualResult.First.Value.Should().BePositive();
            actualResult.First.Next.Value.Should().BePositive();
            actualResult.First.Next.Next.Value.Should().BePositive();
        }

        [Fact]
        public void BuildList_ReturnsAPopulatedList()
        {
            // Act
            var actualResult = fixture.Create<List<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(List<int>));
            actualResult.Should().HaveCount(3);
            actualResult.All(x => x > 0).Should().BeTrue();
        }

        [Fact]
        public void BuildList_ReturnsAPopulatedQueue()
        {
            // Act
            var actualResult = fixture.Create<Queue<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(Queue<int>));
            actualResult.Should().HaveCount(3);
            actualResult.Dequeue().Should().BePositive();
            actualResult.Dequeue().Should().BePositive();
            actualResult.Dequeue().Should().BePositive();
        }

        [Fact]
        public void BuildReadOnlyCollection_ReturnsAPopulatedReadOnlyCollection()
        {
            // Act
            var actualResult = fixture.Create<ReadOnlyCollection<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(ReadOnlyCollection<int>));
            actualResult.Count.Should().Be(3);
            actualResult.All(x => x > 0).Should().BeTrue();
        }

        [Fact]
        public void BuildSortedDictionary_ReturnsAPopulatedSortedDictionary()
        {
            // Act
            var actualResult = fixture.Create<SortedDictionary<int, string>>();

            // Assert
            actualResult.Should().BeOfType(typeof(SortedDictionary<int, string>));
            actualResult.Count.Should().Be(3);
            actualResult.Keys.All(x => x > 0).Should().BeTrue();
            actualResult.Values.All(x => x.Length > 0).Should().BeTrue();
        }

        [Fact]
        public void BuildSortedList_ReturnsAPopulatedSortedList()
        {
            // Act
            var actualResult = fixture.Create<SortedSet<float>>();

            // Assert
            actualResult.Should().BeOfType(typeof(SortedSet<float>));
            actualResult.Should().HaveCount(3);
            actualResult.All(x => x > 0).Should().BeTrue();
        }

        [Fact]
        public void BuildStack_ReturnsAPopulatedStack()
        {
            // Act
            var actualResult = fixture.Create<Stack<int>>();

            // Assert
            actualResult.Should().BeOfType(typeof(Stack<int>));
            actualResult.Should().HaveCount(3);
            actualResult.Pop().Should().BePositive();
            actualResult.Pop().Should().BePositive();
            actualResult.Pop().Should().BePositive();
        }
    }
}
