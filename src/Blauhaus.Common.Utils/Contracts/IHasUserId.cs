using System;

namespace Blauhaus.Common.Utils.Contracts
{ 

    public interface IHasUserId : IHasId<Guid>{}

    public interface IHasUserId<out TId>
    {
        TId UserId { get; }
    }
}