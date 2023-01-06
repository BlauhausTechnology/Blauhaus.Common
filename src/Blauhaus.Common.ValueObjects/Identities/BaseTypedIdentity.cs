using System;
using Blauhaus.Common.Abstractions.Identities;
using Blauhaus.Common.ValueObjects.Base;

namespace Blauhaus.Common.ValueObjects.Identities
{
    public abstract class BaseTypedIdentity<TIdentity> : BaseValueObject<TIdentity>, ITypedIdentity
        where TIdentity : BaseTypedIdentity<TIdentity>
    {
        private string _serialized;
        protected BaseTypedIdentity(Guid id, Guid typeId, Guid? subTypeId = null)
        {
            Id = id;
            TypeId = typeId;
            SubTypeId = subTypeId;

            _serialized = SubTypeId == null 
                ? $"{Id.ToString()}|{TypeId.ToString()}" 
                : $"{Id.ToString()}|{TypeId.ToString()}|{SubTypeId.ToString()}";
        }

        public Guid Id { get; }
        public Guid TypeId { get; }
        public Guid? SubTypeId { get; } 

        public string Serialize() => _serialized;
        public static TIdentity Deserialize(string serialized)
        {
            var stringIds = serialized.Split('|');
            var id = Guid.Parse(stringIds[0]);
            var typeId = Guid.Parse(stringIds[1]);
            var subTypeId = stringIds.Length == 3 ? Guid.Parse(stringIds[2]) : (Guid?)null; 
            return (TIdentity)Activator.CreateInstance(typeof(TIdentity), id, typeId, subTypeId);
        }

        public override string ToString()
        {
            return SubTypeId == null 
                ? $"Id: {Id.ToString()} | Type: {TypeId.ToString()}"
                : $"Id: {Id.ToString()} | Type: {TypeId.ToString()} | SubTypeId: {SubTypeId.ToString()}";
        }

        protected override int GetHashCodeCore()
        {
            return _serialized.GetHashCode();
        }
        protected override bool EqualsCore(TIdentity other)
        {
            return _serialized == other.Serialize();
        }

        public static TIdentity Empty = (TIdentity)Activator.CreateInstance(typeof(TIdentity), Guid.Empty, Guid.Empty, (Guid?)null);
        
    }
}