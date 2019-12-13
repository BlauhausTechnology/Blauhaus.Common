using System.Linq.Expressions;

namespace Blauhaus.Common.Utils.Extensions
{
    public static class ExpressionExtensions
    {
        public static string ToPropertyName<T>(this Expression<T> expression)
        {
            var expressionBody = expression.Body.ToString();
            var propertyName = expressionBody.Substring(expressionBody.IndexOf('.') + 1);
            return propertyName.EndsWith(", Object)") 
                ? propertyName.Substring(0, propertyName.Length - 9) 
                : propertyName;
        }
    }
}