using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Contracts
{
    public interface IAsyncPublisher<out T>
    {
        Task<IDisposable> SubscribeAsync(Func<T, Task> handler, Func<T, bool>? predicate = null);
    }
}