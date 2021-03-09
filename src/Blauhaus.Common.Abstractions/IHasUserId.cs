using System;

namespace Blauhaus.Common.Abstractions
{ 

    public interface IHasUserId : IHasUserId<Guid>{}

    public interface IHasUserId<out TId>
    {
        TId UserId { get; }
    }
}