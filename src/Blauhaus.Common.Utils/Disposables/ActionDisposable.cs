using System;

namespace Blauhaus.Common.Utils.Disposables
{
    public class ActionDisposable : IDisposable
    {
        private readonly Action? _disposeAction;

        public ActionDisposable(Action disposeAction)
        {
            _disposeAction = disposeAction;
        }

        public void Dispose()
        {
            _disposeAction?.Invoke();
        }
    }
}