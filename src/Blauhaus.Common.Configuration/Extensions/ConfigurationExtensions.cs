using Microsoft.Extensions.Configuration;

namespace Blauhaus.Common.Configuration.Extensions;

public static class ConfigurationExtensions
{
    
    public static IConfiguration PrintValues(this IConfiguration configuration)
    {
        foreach (var configurationSection in configuration.GetChildren())
        {
            Console.Out.WriteLine(configurationSection.Key + ": " + configurationSection.Value);
            foreach (var kid in configurationSection.GetChildren())
            {
                Console.Out.WriteLine(">> "  +kid.Key + ": " + kid.Value);
            }
        }

        return configuration;
    }

    
    public static T GetRequiredValue<T>(this IConfiguration configuration, string? sectionName, string name, Func<string, T> converter, Func<T, bool> validator)
    {

        var rootSections = configuration.GetChildren();
        IEnumerable<IConfigurationSection> targetedSections;

        if (string.IsNullOrWhiteSpace(sectionName))
        {
            targetedSections = rootSections;
        }
        else
        {
            var targetedChild = rootSections.FirstOrDefault(x => string.Equals(x.Key, sectionName, StringComparison.CurrentCultureIgnoreCase));
            if (targetedChild is null)
            {
                throw new InvalidOperationException($"No configuration section was found for {sectionName}");
            }

            targetedSections = targetedChild.GetChildren();
        }
        
        var value = targetedSections.FirstOrDefault(x => string.Equals(x.Key, name, StringComparison.CurrentCultureIgnoreCase));
        if (value is null || string.IsNullOrEmpty(value.Value))
        {
            throw new InvalidOperationException($"No configuration value was found for {name}");
        } 
        
        var convertedValue = converter.Invoke(value.Value);
        if (validator.Invoke(convertedValue))
        {
            return convertedValue;
        }

        throw new InvalidOperationException($"Configuration value {convertedValue} was not valid for {sectionName}:{name}");
    }

    public static string GetRequiredString(this IConfiguration configuration, string? sectionName, string name)
        => configuration.GetRequiredValue<string>(sectionName, name, s => s, s => !string.IsNullOrEmpty(s));
    public static bool GetRequiredBoolen(this IConfiguration configuration, string? sectionName, string name)
        => configuration.GetRequiredValue<bool>(sectionName, name, bool.Parse, s => true);

    public static int GetRequiredInteger(this IConfiguration configuration, string? sectionName, string name)
        => configuration.GetRequiredValue(sectionName, name, int.Parse, i => i > 0);
    
    public static Guid GetRequiredId(this IConfiguration configuration, string? sectionName, string name)
        => configuration.GetRequiredValue(sectionName, name, Guid.Parse, g => g != Guid.Empty);



    public static bool TryGetValue<T>(this IConfiguration configuration, string? sectionName, string name, Func<string, T> converter, Func<T, bool> validator, out T convertedValue)
    {
        convertedValue = default!;

        var rootSections = configuration.GetChildren();
        IEnumerable<IConfigurationSection> targetedSections;

        if (string.IsNullOrEmpty(sectionName))
        {
            targetedSections = rootSections;
        }
        else
        {
            var targetedChild = rootSections.FirstOrDefault(x => string.Equals(x.Key, sectionName, StringComparison.CurrentCultureIgnoreCase));
            if (targetedChild is null)
            {
                return false;
            }

            targetedSections = targetedChild.GetChildren();
        }
        
        var value = targetedSections.FirstOrDefault(x => string.Equals(x.Key, name, StringComparison.CurrentCultureIgnoreCase));
        if (value is null || string.IsNullOrEmpty(value.Value))
        {
            return false;
        } 
        
        convertedValue = converter.Invoke(value.Value);
        return validator.Invoke(convertedValue);
    }
    public static bool TryGetBoolean(this IConfiguration configuration, string? sectionName, string name, out bool booleanValue)
    {
        return configuration.TryGetValue(sectionName, name, bool.Parse, (x) => true, out booleanValue);
    }
    public static bool TryGetInteger(this IConfiguration configuration, string? sectionName, string name, out int integerValue)
    {
        return configuration.TryGetValue(sectionName, name, int.Parse, i => i > 0, out integerValue);
    }
    public static bool TryGetFloat(this IConfiguration configuration, string? sectionName, string name, out float floatValue)
    {
        return configuration.TryGetValue(sectionName, name, float.Parse, i => true, out floatValue);
    }
    public static bool TryGetString(this IConfiguration configuration, string? sectionName, string name, out string stringValue)
    {
        return configuration.TryGetValue(sectionName, name, s => s, s => !string.IsNullOrEmpty(s), out stringValue);
    }
    public static string? TryGetString(this IConfiguration configuration, string? sectionName, string name)
    {
        return configuration.TryGetValue(sectionName, name, s => s, s => !string.IsNullOrEmpty(s), out var stringValue) ? stringValue : null;
    }
    public static bool TryGetId(this IConfiguration configuration, string? sectionName, string name, out Guid idValue)
    {
        return configuration.TryGetValue(sectionName, name, Guid.Parse, id => id != Guid.Empty, out idValue);
    }




    public static bool TryGetValues<T>(this IConfiguration configuration, string? sectionName, string name, Func<string, T> converter, Func<T, bool> validator, out List<T> convertedValues)
    {
        convertedValues = new List<T>();

        var rootSections = configuration.GetChildren();
        IEnumerable<IConfigurationSection> targetedSections;

        if (sectionName is null)
        {
            targetedSections = rootSections;
        }
        else
        {
            var targetedChild = rootSections.FirstOrDefault(x => string.Equals(x.Key, sectionName, StringComparison.CurrentCultureIgnoreCase));
            if (targetedChild is null)
            {
                return false;
            }

            targetedSections = targetedChild.GetChildren();
        }
        
        var value = targetedSections.FirstOrDefault(x => string.Equals(x.Key, name, StringComparison.CurrentCultureIgnoreCase));
        if (value is null)
        {
            return false;
        }
        var values = value.GetChildren();

        foreach (var possibleValue in values)
        {
            if (possibleValue is not null && !string.IsNullOrEmpty(possibleValue.Value))
            {
                var convertedValue = converter.Invoke(possibleValue.Value);
                if (validator.Invoke(convertedValue))
                {
                    convertedValues.Add(convertedValue);
                }
            }
        }

        return convertedValues.Any();
    }
    public static bool TryGetIds(this IConfiguration configuration, string? sectionName, string name, out List<Guid> idValues)
    {
        return configuration.TryGetValues(sectionName, name, Guid.Parse, id => id != Guid.Empty, out idValues);
    }



    public static bool TryGetDictionary(this IConfiguration configuration, string? sectionName, string name, out Dictionary<string, string> dictionary)
    {
        dictionary = new Dictionary<string, string>();

        var rootSections = configuration.GetChildren();
        IEnumerable<IConfigurationSection> targetedSections;

        if (sectionName is null)
        {
            targetedSections = rootSections;
        }
        else
        {
            var targetedChild = rootSections.FirstOrDefault(x => string.Equals(x.Key, sectionName, StringComparison.CurrentCultureIgnoreCase));
            if (targetedChild is null)
            {
                return false;
            }

            targetedSections = targetedChild.GetChildren();
        }

        var values = targetedSections.FirstOrDefault(x => x.Key == name);
        if (values is null)
        {
            return false;
        }
        foreach (var configurationSection in values.GetChildren())
        {
            dictionary.Add(configurationSection.Key, configurationSection.Value);
        }

        return true;
        
    }
}