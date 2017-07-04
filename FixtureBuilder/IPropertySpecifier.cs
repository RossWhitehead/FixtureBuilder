using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FixtureBuilder
{
    public interface IPropertySpecifier<T>
    {
        T Create();
        IPropertySpecifier<T> With(Expression<Func<T, object>> propertyPicker, object value);
    }
}
