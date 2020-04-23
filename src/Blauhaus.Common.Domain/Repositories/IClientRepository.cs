using System;
using System.Threading;
using System.Threading.Tasks;
using Blauhaus.Common.Domain.Entities;
using CSharpFunctionalExtensions;

namespace Blauhaus.Common.Domain.Repositories
{
    public interface IClientRepository<TModel, in TDto> 
        where TModel : class, IClientEntity
    {
        Task<Result<TModel>> LoadByIdAsync(Guid id, CancellationToken token);
        Task<Result<TModel>> SaveDtoAsync(TDto dto, CancellationToken token); 
    }
}