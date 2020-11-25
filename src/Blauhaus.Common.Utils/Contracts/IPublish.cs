using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Contracts
{
    public interface IPublish<out T>
    {
        Task<IDisposable> SubscribeAsync(Func<T, Task> handler);
    }
}