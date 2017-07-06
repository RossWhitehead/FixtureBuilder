namespace FixtureBuilder
{
    public interface IFixture
    {
        uint Many { get; set; }
        uint MaxDepth { get; set; }

        IPropertySpecifier<T> Build<T>();
        T Create<T>();
    }
}