using System;
using Blauhaus.Common.Abstractions;
using Blauhaus.Common.Abstractions.Extensions;
using NUnit.Framework;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public static class HasProptertiesExtensions
    {
        
        public static bool VerifyValue(this IHasProperties hasProperties, string key, string expectedValue)
        {
            if (!hasProperties.Properties.TryGetValue(key, out var actualValue))
            {
                Assert.Fail($"No value found with key {key}");
                return false;
            } 

            Assert.That(actualValue, Is.EqualTo(expectedValue));
            return true;
        }

    
        public static T RemoveProperty<T>(this T hasProperties, string key) where T : IHasProperties
        {
            if (hasProperties.Properties.TryGetValue(key, out var _))
            {
                hasProperties.Properties.Remove(key);
            } 

            return hasProperties;
        }

        public static T RemoveProperty<T>(this T hasProperties, Guid key) where T : IHasProperties
        {
            if (hasProperties.TryGetValue(key.ToString(), out var _))
            {
                hasProperties.Properties.Remove(key.ToString());
            } 

            return hasProperties;
        }
    }
}