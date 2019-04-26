using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace amoCRM.Library.Helpers
{
    public static class AttributeHelper
    {
        public static TValue GetPropertyAttributeValue<T, TOut, TAttribute, TValue>(
        Expression<Func<T, TOut>> propertyExpression,
        Func<TAttribute, TValue> valueSelector)
        where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attr != null ? valueSelector(attr) : default;
        }

        public static string GetStringValue(this ModelType value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());

            var attr = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault() as StringValueAttribute;

            return attr != null ? attr.StringValue : default;
        }
    }
}
