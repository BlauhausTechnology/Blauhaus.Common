using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public class PublishedModels<TUpdate> : List<TUpdate>, IDisposable 
    {
        private readonly IDisposable? _token;

        public PublishedModels(IAsyncPublisher<TUpdate> bindableObject)
        {
            _token = Task.Run(async () => await bindableObject.SubscribeAsync(update =>
            {
                Add(update);
                return Task.CompletedTask;
            }));
        }
         
        public void Dispose()
        {
            _token?.Dispose();
        }
    }
    
    public static class AsyncPublisherExtensions
    {
        public static PublishedModels<T> SubscribeToUpdates<T>(this IAsyncPublisher<T> publisher)
        {
            return new PublishedModels<T>(publisher);
        } 
    }
}