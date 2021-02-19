using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Contracts
{
    public interface IPublisher
    {
        IDisposable Subscribe<T>(Func<T> handler);
    }
}