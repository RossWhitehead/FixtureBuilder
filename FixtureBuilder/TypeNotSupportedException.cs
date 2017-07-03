namespace FixtureBuilder
{
    using System;

    public class TypeNotSupportedException : Exception
    {
        public TypeNotSupportedException(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
    }
}
