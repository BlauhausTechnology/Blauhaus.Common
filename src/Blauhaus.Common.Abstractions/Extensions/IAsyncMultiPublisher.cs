using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Abstractions.Extensions
{
    public interface IAsyncMultiPublisher
    {
        Task<IDisposable> SubscribeAsync<T>(Func<T, Task> handler, bool publishImmediately = true);
    }
}