using System;

namespace Blauhaus.Common.Domain.Entities
{
    public interface IServerEntity : IClientEntity
    {
        DateTime CreatedAt { get; }
        DateTime ModifiedAt { get; }
    }
}