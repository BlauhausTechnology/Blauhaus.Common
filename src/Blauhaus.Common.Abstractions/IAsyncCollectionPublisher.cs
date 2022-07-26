using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IAsyncCollectionPublisher<T> : IAsyncPublisher<IReadOnlyList<T>>
    {
        Task<IReadOnlyList<T>> GetCollectionAsync();
        Task AddItemAsync(T item);
        Task RemoveItemAsync(T item);
    }
}