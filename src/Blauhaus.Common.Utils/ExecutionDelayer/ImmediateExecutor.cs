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
            await new TaskExecutionDelayer().ExecuteAfterDelayAsync(taskToExecuteAfterDelay, 0);
        }

        public void ExecuteAfterDelay(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            new TaskExecutionDelayer().ExecuteAfterDelay(taskToExecuteAfterDelay, 0);
        }
    }
}