using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Blauhaus.Common.Utils.Extensions
{
    public static class ObjectExtensions
    {
        public static T With<T, TProperty>(this T theObject, Expression<Func<T, TProperty>> expression, TProperty value)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertyName = (expression.Body as MemberExpression)?.Member.Name;
            var propertyToSet = properties.FirstOrDefault(p => p.Name == propertyName);

            if (propertyToSet != null)
            {
                propertyToSet.SetValue(theObject, value);
            }

            return theObject;
        }
    }
}