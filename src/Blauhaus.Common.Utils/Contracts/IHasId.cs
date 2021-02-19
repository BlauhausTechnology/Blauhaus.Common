using System;

namespace Blauhaus.Common.Utils.Contracts
{

    public interface IHasId : IHasId<Guid>{}

    public interface IHasId<out TId>
    {
        TId Id { get; }
    }
}