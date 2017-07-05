using System;

namespace FixtureBuilder
{
    public interface IValueBuilder
    {
        object GetValue(Type type);
    }
}