using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.ExecutionDelayer
{

    public class TaskExecutionDelayer : ITaskExecutionDelayer
    {
        private CancellationTokenSource _throttleCts = new CancellationTokenSource();

        /// <summary>
        /// Executes the given function after the given delay, and resets the delay each time it is called;
        /// </summary>
        public async Task ExecuteAfterDelay(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            try
            {
                Interlocked.Exchange(ref _throttleCts, new CancellationTokenSource()).Cancel();
                await Task.Delay(TimeSpan.FromMilliseconds(delayMs), _throttleCts.Token)
                    .ContinueWith(async task => await taskToExecuteAfterDelay.Invoke(), 
                        CancellationToken.None, 
                        TaskContinuationOptions.OnlyOnRanToCompletion, 
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch  
            {
                //Ignore any Threading errors
            }
        }
    }
}