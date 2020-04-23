using Blauhaus.Common.Domain.Entities;
using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.Domain.Repositories
{
    public static class RepositoryErrors
    {
        public static Error EntityNotFound<T>() => Error.Create($"{typeof(T).Name} entity was not found");
    }
}