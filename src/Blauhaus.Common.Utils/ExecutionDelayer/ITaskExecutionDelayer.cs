using System;
using System.Threading.Tasks;

namespace Blauhaus.Common.Utils.ExecutionDelayer
{
    public interface ITaskExecutionDelayer
    {
        /// <summary>
        /// Executes the given function after the given delay, and resets the delay each time it is called;
        /// </summary>
        Task ExecuteAfterDelayAsync(Func<Task> taskToExecuteAfterDelay, int delayMs); 
    }

}