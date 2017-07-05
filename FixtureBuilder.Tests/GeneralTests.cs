using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class GeneralTests
    {
        [Fact]
        public void Build_ReturnsAPropertySpecifier()
        {
            // Act
            var fixture = new Fixture();
            var actualResult = fixture.Build<int>();

            // Assert
            actualResult.Should().BeOfType(typeof(PropertySpecifier<int>));
        }

        [Fact]
        public void With_ReturnsAPropertySpecifier()
        {
            // Act
            var fixture = new Fixture();
            var actualResult = fixture.Build<SimpleClass>().With(x => x.Prop1, 2);

            // Assert
            actualResult.Should().BeOfType(typeof(PropertySpecifier<SimpleClass>));
        }

        [Fact]
        public void With_AppliesAValue()
        {
            // Act
            var expectedValue1 = 88;
            var expectedValue2 = "Hello";
            var fixture = new Fixture();

            var actualResult = fixture
                .Build<SimpleClass>()
                .With(x => x.Prop1, expectedValue1)
                .With(x => x.Prop2, expectedValue2)
                .Create();

            // Assert
            actualResult.Prop1.Should().Be(expectedValue1);
            actualResult.Prop2.Should().Be(expectedValue2);
        }

        [Fact]
        public void Create_UtilisesConstructorToApplyValues()
        {
            // Act
            var fixture = new Fixture();

            var actualResult = fixture.Create<SimpleClassWithContructor>();

            // Assert
            actualResult.Prop1.Should().BePositive();
        }

        [Fact]
        public void Create_BuildsComplexClass()
        {
            // Act
            var fixture = new Fixture();

            var actualResult = fixture.Create<ComplexClass>();

            // Assert
            actualResult.Prop1.Should().BeOfType(typeof(SimpleClass));
            actualResult.Prop1.Prop1.Should().BePositive();
            actualResult.Prop1.Prop2.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Create_BuildsComplexClassWithConstructor()
        {
            // Act
            var fixture = new Fixture();

            var actualResult = fixture.Create<ComplexClassWithConstructor>();

            // Assert
            actualResult.Prop1.Should().BeOfType(typeof(SimpleClass));
            actualResult.Prop1.Prop1.Should().BePositive();
            actualResult.Prop1.Prop2.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void Create_ThrowsTypeNotSupportedException_WhereTypeDoesNotHaveAGeneratorAndIsNotAClass()
        {
            //// Act
            //var fixture = new Fixture();
            //Action act = () => fixture.Create<int>();

            //// Assert
            //act.ShouldThrow<TypeNotSupportedException>();
        }

        [Fact]
        public void Create_StopsAt5Levels_WhenClassIsRecursive()
        {
            // Act
            var fixture = new Fixture();

            var actualResult = fixture.Create<RecursiveClass>();

            // Assert
            actualResult.Should().BeOfType(typeof(RecursiveClass));
            actualResult.Prop1.Should().BeOfType(typeof(RecursiveClass));
            actualResult.Prop1.Prop1.Should().BeOfType(typeof(RecursiveClass));
            actualResult.Prop1.Prop1.Prop1.Should().BeOfType(typeof(RecursiveClass));
            actualResult.Prop1.Prop1.Prop1.Prop1.Should().BeOfType(typeof(RecursiveClass));
            actualResult.Prop1.Prop1.Prop1.Prop1.Prop1.Should().BeNull();
        }

    }

    public class SimpleClass
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
    }


    public class SimpleClassWithContructor
    {
        public int Prop1 { get; private set; }
        public string Prop2 { get; set; }

        public SimpleClassWithContructor(int prop1)
        {
            this.Prop1 = prop1;
        }
    }

    public class ComplexClass
    {
        public SimpleClass Prop1 { get; private set; }
    }

    public class ComplexClassWithConstructor
    {
        public ComplexClassWithConstructor(SimpleClass prop1)
        {
            this.Prop1 = prop1;       
        }

        public SimpleClass Prop1 { get; private set; }
    }

    public class RecursiveClass
    {
        public RecursiveClass Prop1 { get; set; }
    }
}
