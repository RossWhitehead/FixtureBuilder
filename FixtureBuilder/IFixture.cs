namespace FixtureBuilder
{
    public interface IFixture
    {
        int Many { get; set; }
        int MaxDepth { get; set; }

        IPropertySpecifier<T> Build<T>();
        T Create<T>();
    }
}