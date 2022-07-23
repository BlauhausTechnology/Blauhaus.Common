using System;

namespace Blauhaus.Common.Abstractions.Identities
{
    public interface ITypedIdentity
    {
        public Guid Id { get; }
        public Guid TypeId { get; }
    }
}