﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FixtureBuilder
{
    public class PropertySpecifier<T> : IPropertySpecifier<T>
    {
        private IValueBuilder valueBuilder;
        private readonly int many;
        private Dictionary<Expression<Func<T, object>>, object> propertySpecifications;

        public PropertySpecifier(IValueBuilder valueBuilder, int many)
        {
            this.valueBuilder = valueBuilder;
            this.many = many;
            this.propertySpecifications = new Dictionary<Expression<Func<T, object>>, object>();
        }

        public T Create()
        {
            Type type = typeof(T);

            var depth = 1;

            var value = (T)valueBuilder.GetValue(type, depth);

            ApplyProperties(value);

            return value;
        }

        public IPropertySpecifier<T> With(Expression<Func<T, object>> propertyPicker, object value)
        {
            propertySpecifications.Add(propertyPicker, value);
            return this;
        }

        private void ApplyProperties(T value)
        {
            foreach (var item in propertySpecifications)
            {
                var selector = item.Key;
                var propertyValue = item.Value;
                var prop = GetPropertyInfo(selector);
                prop.SetValue(value, propertyValue, null);
            }
        }

        private PropertyInfo GetPropertyInfo(Expression<Func<T, Object>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                return (PropertyInfo)((MemberExpression)expression.Body).Member;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return (PropertyInfo)((MemberExpression)op).Member;
            }
        }
    }
}
