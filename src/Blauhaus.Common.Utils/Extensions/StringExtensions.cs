using System;

namespace Blauhaus.Common.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ExtractValueBetweenTags(this string stringContainingTags, string tagName)
        {
            var openingTag = $"<{tagName}>";
            var closingTag = $"</{tagName}>";

            var openingTagStartsAtIndex= stringContainingTags.IndexOf(openingTag, StringComparison.Ordinal);
            if (openingTagStartsAtIndex == -1)
            {
                throw new ArgumentException($"Opening tag '<{tagName}>' was not found");
            }

            var openingTagEndsAtIndex = openingTagStartsAtIndex + openingTag.Length;

            var closingTagStartsAtIndex = stringContainingTags.IndexOf(closingTag, StringComparison.Ordinal);
            if (closingTagStartsAtIndex == -1)
            {
                throw new ArgumentException($"Closing tag '</{tagName}>' was not found");
            }


            var payloadLength = closingTagStartsAtIndex - openingTagEndsAtIndex;

            return stringContainingTags.Substring(openingTagEndsAtIndex, payloadLength);

        }   
    }
}