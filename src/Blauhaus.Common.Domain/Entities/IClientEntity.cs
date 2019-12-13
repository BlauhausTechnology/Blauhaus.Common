using System;

namespace Blauhaus.Common.Domain.Entities
{
    public interface IClientEntity
    {
        Guid Id { get; }
        EntityState EntityState { get; }
        long ModifiedAtTicks { get; }
    }
}