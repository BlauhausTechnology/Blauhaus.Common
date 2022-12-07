using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions
{
    public interface IAsyncPublisher
    {
        Task<IDisposable> SubscribeAsync<T>(Func<T, Task> handler, Func<T, bool>? filter = null);
    }

    public interface IAsyncPublisher<out T>
    {
        Task<IDisposable> SubscribeAsync(Func<T, Task> handler, Func<T, bool>? filter = null);
    }
}