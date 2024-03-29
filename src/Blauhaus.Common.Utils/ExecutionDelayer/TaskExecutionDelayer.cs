﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.ExecutionDelayer
{

    public class TaskExecutionDelayer : ITaskExecutionDelayer
    {
       private CancellationTokenSource _throttleCts = new CancellationTokenSource();

        /// <summary>
        /// Executes the given function after the given delay, and resets the delay each time it is called. Only the last call is executed
        /// </summary>
        public async Task ExecuteAfterDelayAsync(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            try
            {
                _throttleCts.Cancel();
                _throttleCts = new CancellationTokenSource();

                await Task.Delay(TimeSpan.FromMilliseconds(delayMs), _throttleCts.Token)
                    .ContinueWith(async task => await taskToExecuteAfterDelay.Invoke(), 
                        CancellationToken.None, 
                        TaskContinuationOptions.OnlyOnRanToCompletion, 
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch(TaskCanceledException)
            {
                //Ignore any Threading errors
            }
        }

        [Obsolete("User ExecuteAfterDelayAsync instead")]
        public async void ExecuteAfterDelay(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            try
            {
                _throttleCts.Cancel();
                _throttleCts = new CancellationTokenSource();

                await Task.Delay(TimeSpan.FromMilliseconds(delayMs), _throttleCts.Token)
                    .ContinueWith(async task => await taskToExecuteAfterDelay.Invoke(),
                        CancellationToken.None,
                        TaskContinuationOptions.OnlyOnRanToCompletion,
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch(TaskCanceledException)
            {
                //Ignore any Threading errors
            }

        }
 
 
    }
}