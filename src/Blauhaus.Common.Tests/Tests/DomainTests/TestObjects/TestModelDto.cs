using System;
using Blauhaus.Common.Domain.Entities;

namespace Blauhaus.Common.Tests.Tests.DomainTests.TestObjects
{
    public class TestModelDto
    {
        public Guid Id { get; set; }
        public EntityState EntityState { get;  set;}
        public long ModifiedAtTicks { get;  set;}
        public string Name { get;  set;}
    }
}