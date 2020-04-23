using System;
using System.Threading;
using Blauhaus.Common.Domain.Entities;
using Blauhaus.Common.Domain.Repositories;
using Blauhaus.Common.ValueObjects.Errors;
using Blauhaus.TestHelpers.MockBuilders;
using CSharpFunctionalExtensions;
using Moq;

namespace Blauhaus.Common.Domain.TestHelpers.MockBuilders.Repositories._Base
{
    public abstract class BaseRepositoryMockBuilder<TBuilder, TMock, TModel, TDto> : BaseMockBuilder<TBuilder, TMock> 
        where TBuilder : BaseRepositoryMockBuilder<TBuilder, TMock, TModel, TDto>
        where TMock : class, IClientRepository<TModel, TDto>
        where TModel : class, IClientEntity
    {


        public TBuilder Where_LoadByIdAsync_returns(TModel model)
        {
            Mock.Setup(x => x.LoadByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Success(model));
            return this as TBuilder;
        }
        public TBuilder Where_LoadByIdAsync_fails(string error)
        {
            Mock.Setup(x => x.LoadByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure<TModel>(error));
            return this as TBuilder;
        }
        public TBuilder Where_LoadByIdAsync_fails(Error error)
        {
            Mock.Setup(x => x.LoadByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure<TModel>(error.ToString()));
            return this as TBuilder;
        }

        
        public TBuilder Where_SaveDtoAsync_returns(TModel userModel)
        {
            Mock.Setup(x => x.SaveDtoAsync(It.IsAny<TDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Success(userModel));
            return this as TBuilder;
        }
        public TBuilder Where_SaveDtoAsync_fails(string error)
        {
            Mock.Setup(x => x.SaveDtoAsync(It.IsAny<TDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure<TModel>(error));
            return this as TBuilder;
        }
        public TBuilder Where_SaveDtoAsync_fails(Error error)
        {
            Mock.Setup(x => x.SaveDtoAsync(It.IsAny<TDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Result.Failure<TModel>(error.ToString()));
            return this as TBuilder;
        }
    }
}