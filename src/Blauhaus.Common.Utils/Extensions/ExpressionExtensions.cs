using System.Linq.Expressions;

namespace Blauhaus.Common.Utils.Extensions
{
    public static class ExpressionExtensions
    {
        public static string ToPropertyName<T>(this Expression<T> expression)
        {
            var expressionBody = expression.Body.ToString();
            return expressionBody.Substring(expressionBody.IndexOf('.') + 1);
        }
    }
}