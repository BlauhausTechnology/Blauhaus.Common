using System;
using Blauhaus.Common.Domain.Entities;

namespace Blauhaus.Common.Tests.Tests.DomainTests.TestObjects
{
    public class TestModel : IClientEntity
    {
        public TestModel(Guid id, EntityState entityState, long modifiedAtTicks, string name)
        {
            Id = id;
            EntityState = entityState;
            ModifiedAtTicks = modifiedAtTicks;
            Name = name;
        }

        public Guid Id { get; }
        public EntityState EntityState { get; }
        public long ModifiedAtTicks { get; }

        public string Name { get; }
    }
}