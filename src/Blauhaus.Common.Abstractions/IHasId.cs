using System;

namespace Blauhaus.Common.Abstractions
{

    public interface IHasId : IHasId<Guid>{}

    public interface IHasId<out TId>
    {
        TId Id { get; }
    }
}