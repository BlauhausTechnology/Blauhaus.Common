namespace Blauhaus.Common.Abstractions
{
    public interface IKeyValueProvider
    {
        string? TryGetValue(string key);
    }
}