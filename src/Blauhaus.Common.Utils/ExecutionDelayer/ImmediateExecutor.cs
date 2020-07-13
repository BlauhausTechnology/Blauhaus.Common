using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.ExecutionDelayer
{
    public class ImmediateTaskExecutor : ITaskExecutionDelayer
    {
        public async Task ExecuteAfterDelay(Func<Task> taskToExecuteAfterDelay, int delayMs)
        {
            //dummy for test purposes
            await new TaskExecutionDelayer().ExecuteAfterDelay(taskToExecuteAfterDelay, 0);
        }
    }
}