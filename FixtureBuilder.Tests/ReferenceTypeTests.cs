using System;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class ReferenceTypeTests
    {
        [Fact]
        public void BuildSimpleClass_ReturnsAnInstanceOfTheClass()
        {
            // Act
            var builder = new Builder();
            var actualResult = builder.Build<SimpleClass>();

            // Assert
            actualResult.Should().BeOfType(typeof(SimpleClass));
        }

        [Fact]
        public void BuildSimpleClassWithValueTypeParameters_PopulatesParameters()
        {
            // Act
            var builder = new Builder();
            var actualResult = builder.Build<SimpleClassWithValueTypeParameters>();

            // Assert
            actualResult.Prop1.Should().NotBe(0);
            actualResult.Prop2.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void BuildSimpleClassWithReferenceTypeParameters_PopulatesParameters()
        {
            // Act
            var builder = new Builder();
            var actualResult = builder.Build<SimpleClassWithReferenceTypeParameters>();

            // Assert
            actualResult.Prop1.Should().BeOfType(typeof(SimpleClass));
        }

        [Fact]
        public void BuildSimpleClassWithReferenceTypeParameters_PopulatesParametersOfChild()
        {
            // Act
            var builder = new Builder();
            var actualResult = builder.Build<SimpleClassWithReferenceTypeParameters>();

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
