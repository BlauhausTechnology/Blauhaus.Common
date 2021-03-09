using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IAsyncIdPublisher<out T, in TId>
    {
        Task<IDisposable> SubscribeAsync(Func<T, Task> handler, TId id);
    }
}