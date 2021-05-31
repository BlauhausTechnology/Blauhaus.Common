using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public static class AsyncPublisherExtensions
    {
        public static async Task<PublishedItems<T>> SubscribeToUpdatesAsync<T>(this IAsyncPublisher<T> publisher, Func<T, bool> filter)
        {
            var models = new PublishedItems<T>(publisher, filter);
            await models.InitializeAsync();
            return models;
        } 
        public static async Task<PublishedItems<T>> SubscribeToUpdatesAsync<T>(this IAsyncPublisher<T> publisher)
        {
            var models = new PublishedItems<T>(publisher);
            await models.InitializeAsync();
            return models;
        }  
          
        
        public class PublishedItems<T> : List<T>, IDisposable 
        {
            private readonly IAsyncPublisher<T> _publisher;
            private readonly Func<T, bool>? _filter;
            private IDisposable? _token;

            public PublishedItems(IAsyncPublisher<T> publisher, Func<T, bool>? filter = null)
            {
                _publisher = publisher;
                _filter = filter;
            }

            public async Task InitializeAsync()
            {
                _token = await _publisher.SubscribeAsync(update =>
                {
                    Add(update);
                    return Task.CompletedTask;
                }, _filter);
            }

            public void Dispose()
            {
                _token?.Dispose();
            }
        }

    }
}