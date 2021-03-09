using System;

namespace Blauhaus.Common.Abstractions
{
    public interface IPublisher
    {
        IDisposable Subscribe<T>(Func<T> handler);
    }
}