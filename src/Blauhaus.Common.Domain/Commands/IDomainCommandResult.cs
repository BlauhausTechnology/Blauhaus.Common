using System;
using System.Collections.Generic;

namespace Blauhaus.Common.Domain.Commands
{
    [Obsolete]
    public interface IDomainCommandResult<TPayload>
    {
        TPayload Payload { get; set; }
        List<DomainCommandError> Errors { get; set; }
    }
}