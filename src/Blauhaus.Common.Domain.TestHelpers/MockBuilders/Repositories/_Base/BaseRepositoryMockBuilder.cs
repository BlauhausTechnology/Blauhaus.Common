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
    public abstract class BaseClientRepositoryMockBuilder<TBuilder, TMock, TModel, TDto> : BaseMockBuilder<TBuilder, TMock> 
        where TBuilder : BaseClientRepositoryMockBuilder<TBuilder, TMock, TModel, TDto>
        where TMock : class, IClientRepository<TModel, TDto>
        where TModel : class, IClientEntity
    {


        public TBuilder Where_LoadByIdAsync_returns(TModel model)
        {
            Mock.Setup(x => x.LoadByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(model);
            return this as TBuilder;
        }
        
        public TBuilder Where_LoadByIdAsync_throws(Exception e)
        {
            Mock.Setup(x => x.LoadByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(e);
            return this as TBuilder;
        }
        public TBuilder Where_SaveDtoAsync_returns(TModel userModel)
        {
            Mock.Setup(x => x.SaveDtoAsync(It.IsAny<TDto>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(userModel);
            return this as TBuilder;
        }
        public TBuilder Where_SaveDtoAsync_throws(Exception e)
        {
            Mock.Setup(x => x.SaveDtoAsync(It.IsAny<TDto>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(e);
            return this as TBuilder;
        }
    }
}