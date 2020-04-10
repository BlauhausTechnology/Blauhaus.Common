using System;

namespace Blauhaus.Common.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string ExtractValueBetweenText(this string stringContainingTags, string beginText, string endText)
        {

            var beginTextStartsAt = stringContainingTags.IndexOf(beginText, StringComparison.OrdinalIgnoreCase);
            if (beginTextStartsAt == -1)
            {
                throw new ArgumentException($"Did not find expected beginning text of '{beginText}'");
            }

            var beginTextEndsAt = beginTextStartsAt + beginText.Length;

            var endTextStartsAtIndex = stringContainingTags.IndexOf(endText, StringComparison.OrdinalIgnoreCase);
            if (endTextStartsAtIndex == -1)
            {
                throw new ArgumentException($"Did not find expected ending text of '{beginText}'");
            }


            var payloadLength = endTextStartsAtIndex - beginTextEndsAt;

            return stringContainingTags.Substring(beginTextEndsAt, payloadLength);

        }   

        public static string ExtractValueBetweenTags(this string stringContainingTags, string tagName)
        {
            var openingTag = $"<{tagName}>";
            var closingTag = $"</{tagName}>";

            return stringContainingTags.ExtractValueBetweenText(openingTag, closingTag);
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