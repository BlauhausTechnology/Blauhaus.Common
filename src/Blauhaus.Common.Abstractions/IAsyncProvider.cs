using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IAsyncProvider<T>
    {
        Task<T> GetAsync();
    }
}