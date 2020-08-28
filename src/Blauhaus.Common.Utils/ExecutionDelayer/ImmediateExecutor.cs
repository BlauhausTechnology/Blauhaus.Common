using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.ExecutionDelayer
{
    //dummy for test purposes
    public class ImmediateTaskExecutor : ITaskExecutionDelayer
    {
        public async Task ExecuteAfterDelayAsync(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            taskToExecuteAfterDelay.Invoke();
        }

        public void ExecuteAfterDelay(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            taskToExecuteAfterDelay.Invoke();
        }
    }
}