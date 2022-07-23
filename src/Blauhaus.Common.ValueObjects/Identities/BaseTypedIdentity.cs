using System;
using Blauhaus.Common.Abstractions.Identities;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Identities
{
    public abstract class BaseTypedIdentity<TIdentity> : BaseValueObject<TIdentity>, ITypedIdentity
        where TIdentity : BaseTypedIdentity<TIdentity>
    {
        protected BaseTypedIdentity(Guid id, Guid typeId)
        {
            Id = id;
            TypeId = typeId;
        }

        public Guid Id { get; }
        public Guid TypeId { get; }

        public override string ToString()
        {
            return $"Id: {Id} | Type: {TypeId}";
        }

        protected override int GetHashCodeCore()
        {
            return TypeId.GetHashCode() ^ Id.GetHashCode();
        }
        protected override bool EqualsCore(TIdentity other)
        {
            return TypeId == other.TypeId && Id == other.Id;
        }

        public static TIdentity Empty = (TIdentity)Activator.CreateInstance(typeof(TIdentity), Guid.Empty, Guid.Empty);
        
    }
}