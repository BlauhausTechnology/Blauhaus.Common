﻿using System;
using System.Linq.Expressions;
using System.Threading;
using Blauhaus.Common.Domain.CommandHandlers;
using Blauhaus.Common.ValueObjects.Errors;
using Blauhaus.TestHelpers.MockBuilders;
using CSharpFunctionalExtensions;
using Moq;

namespace Blauhaus.Common.Domain.TestHelpers.MockBuilders.CommandHandlers._Base
{
    public class BaseVoidCommandHandlerMockBuilder<TBuilder, TMock, TCommand> : BaseMockBuilder<TBuilder, TMock>
        where TMock : class, IVoidCommandHandler<TCommand> 
        where TBuilder : BaseMockBuilder<TBuilder, TMock>
    { 
        public TBuilder Where_HandleAsync_returns_result(Result result)
        {
            Mock.Setup(x => x.HandleAsync(It.IsAny<TCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);
            return this as TBuilder;
        }

        public TBuilder Where_HandleAsync_returns_fails(string error)
        {
            Mock.Setup(x => x.HandleAsync(It.IsAny<TCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure(error));
            return this as TBuilder;
        }
        
        public TBuilder Where_HandleAsync_returns_fails(Error error)
        {
            Mock.Setup(x => x.HandleAsync(It.IsAny<TCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure(error.ToString()));
            return this as TBuilder;
        }


        public TBuilder Where_HandleAsync_returns_throws(Exception exception)
        {
            Mock.Setup(x => x.HandleAsync(It.IsAny<TCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(exception);
            return this as TBuilder;
        }

        public void Verify_HandleAsync_called_With(Expression<Func<TCommand, bool>> predicate)
        {
            Mock.Verify(x => x.HandleAsync(It.Is<TCommand>(predicate), It.IsAny<CancellationToken>()));
        }

        public void Verify_HandleAsync_NOT_called_With(Expression<Func<TCommand, bool>> predicate)
        {
            Mock.Verify(x => x.HandleAsync(It.Is<TCommand>(predicate), It.IsAny<CancellationToken>()), Times.Never);
        }

        public void Verify_HandleAsync_NOT_called()
        {
            Mock.Verify(x => x.HandleAsync(It.IsAny<TCommand>(), It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}