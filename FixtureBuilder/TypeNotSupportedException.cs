namespace FixtureBuilder
{
    using System;

    public class TypeNotSupportedException : Exception
    {
        public TypeNotSupportedException(Type type)
        {
            Type = type;
        }

        public TypeNotSupportedException(Type type, string message) : base(message)
        {
            Type = type;
        }

        public Type Type { get; set; }
    }
}
