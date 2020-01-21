using System.Collections.Generic;

namespace Blauhaus.Common.Domain.CommandResults
{
    public interface ICommandResult<TPayload>
    {
        TPayload Payload { get; set; }
        List<CommandError> UserErrors { get; set; }
    }
}