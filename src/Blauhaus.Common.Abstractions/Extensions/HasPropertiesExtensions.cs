using System;
using System.Collections.Generic;

namespace Blauhaus.Common.Abstractions.Extensions
{
    public static class HasPropertiesExtensions
    {
        
        public static T AddProperties<T>(this T hasProperties, Dictionary<string, string> properties) where T : IHasProperties
        {
            foreach (var property in properties)
            {
                hasProperties.Properties[property.Key] = property.Value;
            }

            return hasProperties;
        }

        public static bool TryGetValue(this IHasProperties hasProperties, string key, out string value, bool allowEmpty = false)
        {
            foreach (var property in hasProperties.Properties)
            {
                if (string.Equals(property.Key, key, StringComparison.InvariantCultureIgnoreCase))
                {
                    value = property.Value;
                    if (allowEmpty)
                    {
                        return true;
                    }

                    return !string.IsNullOrEmpty(property.Value);
                }
            }

            value = string.Empty;
            return false;
        }

        public static bool TryGetId(this IHasProperties hasProperties, string key, out Guid value, bool allowEmpty = false) 
        {
            foreach (var property in hasProperties.Properties)
            {
                if (string.Equals(property.Key, key, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Guid.TryParse(property.Value, out value))
                    {
                        if (allowEmpty)
                        {
                            return true;
                        }
                        else
                        {
                            if (value != Guid.Empty)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            value = Guid.Empty;
            return false;
        }
        
        
        public static T WithValue<T>(this T hasProperties, string key, string value) where T : IHasProperties
        {
            hasProperties.Properties[key] = value;
            return hasProperties;
        }
    }
}