using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IKeyValueStore
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
        bool Remove(string key);
    }
    
}