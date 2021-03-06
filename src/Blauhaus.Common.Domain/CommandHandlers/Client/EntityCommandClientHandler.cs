﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.Analytics.Abstractions.Service;
using Blauhaus.Common.Domain.Entities;
using Blauhaus.Common.Domain.Repositories;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.CommandHandlers.Client
{
    public class EntityCommandClientHandler<TModel, TModelDto, TCommandDto, TCommand> : ICommandHandler<TModel, TCommand> 
        where TModel : class, IClientEntity 
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly ICommandConverter<TCommandDto, TCommand> _converter;
        private readonly ICommandHandler<TModelDto, TCommandDto> _dtoCommandHandler;
        private readonly IClientRepository<TModel, TModelDto> _repository;

        public EntityCommandClientHandler(
            IAnalyticsService analyticsService,
            ICommandConverter<TCommandDto, TCommand> converter,
            ICommandHandler<TModelDto, TCommandDto> dtoCommandHandler, 
            IClientRepository<TModel, TModelDto> repository)
        {
            _analyticsService = analyticsService;
            _converter = converter;
            _dtoCommandHandler = dtoCommandHandler;
            _repository = repository;
        }

        public async Task<Result<TModel>> HandleAsync(TCommand command, CancellationToken token)
        {
            _analyticsService.TraceVerbose(this, $"{typeof(TCommand).Name} Handler started", command.ToObjectDictionary("Command"));

            var commandDto = _converter.Convert(command);
            var dtoResult = await _dtoCommandHandler.HandleAsync(commandDto, token);
            if (dtoResult.IsFailure)
            {
                return Result.Failure<TModel>(dtoResult.Error);
            }

            var model = await _repository.SaveDtoAsync(dtoResult.Value);

            _analyticsService.TraceVerbose(this, $"{typeof(TCommand).Name} Handler succeeded");

            return Result.Success(model);
        }
    }
}