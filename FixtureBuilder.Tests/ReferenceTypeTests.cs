using System;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class ReferenceTypeTests
    {
        private Fixture fixture;

        public ReferenceTypeTests()
        {
            this.fixture = new Fixture();
        }

        [Fact]
        public void CreateDynamic_ReturnsADynamic()
        {
            // Act
            var actualResult = fixture.Create<dynamic>();

            // Assert
            Assert.NotNull(actualResult);
        }

        [Fact]
        public void CreateSimpleClass_ReturnsAnInstanceOfTheClass()
        {
            // Act
            var actualResult = fixture.Create<SimpleClass>();

            // Assert
            actualResult.Should().BeOfType(typeof(SimpleClass));
        }

        [Fact]
        public void CreateSimpleClassWithValueTypeParameters_PopulatesParameters()
        {
            // Act
            var actualResult = fixture.Create<SimpleClassWithValueTypeParameters>();

            // Assert
            actualResult.Prop1.Should().NotBe(0);
            actualResult.Prop2.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void BuildSimpleClassWithReferenceTypeParameters_PopulatesParameters()
        {
            // Act
            var actualResult = fixture.Create<SimpleClassWithReferenceTypeParameters>();

            // Assert
            actualResult.Prop1.Should().BeOfType(typeof(SimpleClass));
        }

        [Fact]
        public void BuildSimpleClassWithReferenceTypeParameters_PopulatesParametersOfChild()
        {
            // Act
            var actualResult = fixture.Create<SimpleClassWithReferenceTypeParameters>();

            // Assert
            actualResult.Prop1.Prop1.Should().NotBe(0);
            actualResult.Prop1.Prop2.Should().NotBeNullOrWhiteSpace();
        }

        private class SimpleClass
        {
            public int Prop1 { get; set; }
            public string Prop2 { get; set; }
        }

        private class SimpleClassWithValueTypeParameters
        {
            public int Prop1 { get; set; }
            public string Prop2 { get; set; }
        }

        private class SimpleClassWithReferenceTypeParameters
        {
            public SimpleClass Prop1 { get; set; }
        }
    }
}
