using System;

namespace Blauhaus.Common.Utils.Disposables
{
    public class Disposables : IDisposable
    {
        private readonly IDisposable[] _disposables;

        public Disposables(params IDisposable[] disposables)
        {
            _disposables = disposables;
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}