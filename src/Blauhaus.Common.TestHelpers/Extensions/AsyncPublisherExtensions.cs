using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blauhaus.Common.Abstractions;

namespace Blauhaus.Common.TestHelpers.Extensions
{
    public class PublishedModels<TUpdate> : List<TUpdate>, IDisposable 
    {
        private readonly IAsyncPublisher<TUpdate> _publisher;
        private IDisposable? _token;

        public PublishedModels(IAsyncPublisher<TUpdate> publisher)
        {
            _publisher = publisher;
        }

        public async Task InitializeAsync()
        {
            _token = await _publisher.SubscribeAsync(update =>
            {
                Add(update);
                return Task.CompletedTask;
            });
        }

        public void Dispose()
        {
            _token?.Dispose();
        }
    }
    
    public static class AsyncPublisherExtensions
    {
        public static async Task<PublishedModels<T>> SubscribeToUpdatesAsync<T>(this IAsyncPublisher<T> publisher)
        {
            var models = new PublishedModels<T>(publisher);
            await models.InitializeAsync();
            return models;
        } 
    }
}