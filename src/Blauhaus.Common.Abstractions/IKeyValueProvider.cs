using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IKeyValueProvider
    {
        string? TryGetValue(string key);
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
        bool Remove(string key);
    }
    
}