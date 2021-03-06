﻿using System.Threading;
using System.Threading.Tasks;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Domain.Repositories;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers.Client
{
    public class VoidCommandClientHandler<TCommandDto, TCommand> : IVoidCommandHandler<TCommand>
    {
        private IAnalyticsService _analyticsService;
        private ICommandConverter<TCommandDto, TCommand> _converter;
        private IVoidCommandHandler<TCommandDto> _dtoCommandHandler;

        public VoidCommandClientHandler(IAnalyticsService analyticsService,
            ICommandConverter<TCommandDto, TCommand> converter,
            IVoidCommandHandler<TCommandDto> dtoCommandHandler)
        {
            _analyticsService = analyticsService;
            _converter = converter;
            _dtoCommandHandler = dtoCommandHandler;
        }

        public async Task<Result> HandleAsync(TCommand command, CancellationToken token)
        {
            _analyticsService.TraceVerbose(this, $"{typeof(TCommand).Name} Handler started", command.ToObjectDictionary("Command"));

            var commandDto = _converter.Convert(command);
            var dtoResult = await _dtoCommandHandler.HandleAsync(commandDto, token);
            if (dtoResult.IsFailure)
            {
                return Result.Failure(dtoResult.Error);
            }

            _analyticsService.TraceVerbose(this, $"{typeof(TCommand).Name} Handler succeeded");

            return Result.Success();
        }
    }
}