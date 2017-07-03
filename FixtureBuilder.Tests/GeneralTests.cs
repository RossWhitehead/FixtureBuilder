using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace FixtureBuilder.Tests
{
    public class GeneralTests
    {
        [Fact]
        public void Build_ThrowsTypeNotSupportedException_WhereTypeDoesNotHaveAGeneratorAndIsNotAClass()
        {
            // Act
            var builder = new Builder();
            Action act = () => builder.Build<long>();

            // Assert
            act.ShouldThrow<TypeNotSupportedException>();
        }
    }
}
