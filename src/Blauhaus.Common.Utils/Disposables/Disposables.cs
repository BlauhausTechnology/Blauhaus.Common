using System;
using System.Collections.Generic;
using System.Linq;

namespace Blauhaus.Common.Utils.Disposables
{
    public class Disposables : IDisposable
    {
        private readonly List<IDisposable?> _disposables = new List<IDisposable?>();

        public Disposables(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables)
            {
                _disposables.Add(disposable);
            }
        }

        public void Add(IDisposable disposable)
        {
            _disposables.Add(disposable);
        }
        
        public void Remove(IDisposable disposable)
        {
            _disposables.Remove(disposable);
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable?.Dispose();
            }
            _disposables.Clear();
        }
    }
}