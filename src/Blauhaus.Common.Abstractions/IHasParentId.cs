using System;

namespace Blauhaus.Common.Abstractions
{
    public interface IHasParentId<TId> 
    {
        Guid ParentId { get; }
    }
}