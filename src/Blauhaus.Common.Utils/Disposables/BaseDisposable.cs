using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.Disposables
{
    public abstract class BaseDisposable : IAsyncDisposable
    {
        private bool _isDisposed;
        
        public async ValueTask DisposeAsync()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                await DisposeAsyncCore();
                GC.SuppressFinalize(this);
            }
        }

        protected virtual ValueTask DisposeAsyncCore()
        {
            return new ValueTask();
        }
 
    }
}