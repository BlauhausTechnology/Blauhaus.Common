﻿using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers
{
    public interface ICommandHandler<TCommand, TPayload>
    {
        Task<Result<TPayload>> HandleAsync(TCommand command, CancellationToken token);
    }
}