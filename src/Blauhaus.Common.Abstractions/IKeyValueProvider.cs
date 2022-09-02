using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IKeyValueProvider
    {
        Task<string> GetAsync(string key);
        Task SetAsync(string key, string value);
        bool Remove(string key);
    }
    
}