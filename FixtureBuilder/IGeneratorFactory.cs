using System;
using FixtureBuilder.Generators;

namespace FixtureBuilder
{
    public interface IGeneratorFactory
    {
        IGenerator GetGenerator(Type type);
        IGenerator GetGenerator(Type type, uint depth);
    }
}