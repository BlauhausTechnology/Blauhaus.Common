using System;

namespace Blauhaus.Common.Domain.Entities
{
    public interface IServerEntity : IClientEntity
    {
        DateTimeOffset CreatedAt { get; }
        DateTimeOffset ModifiedAt { get; }
    }
}