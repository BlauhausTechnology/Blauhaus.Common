using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{
    public class AsyncPublisherMockBuilder<TMock, T> : BaseAsyncPublisherMockBuilder<AsyncPublisherMockBuilder<TMock, T>, TMock, T>
        where TMock : class, IAsyncPublisher<T>
    {
        
      
    }
}