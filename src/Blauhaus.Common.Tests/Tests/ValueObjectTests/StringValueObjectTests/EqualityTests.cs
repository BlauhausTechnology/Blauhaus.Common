using System;
using System.Collections.Generic;
using Blauhaus.Common.Tests.Tests.ValueObjectTests.Base;
using Blauhaus.Common.ValueObjects;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.StringValueObjectTests
{
    public class EqualityTests : BaseValueObjectEqualtyTest<StringValueObject>
    {

        protected override IList<Tuple<StringValueObject, StringValueObject>> GetEqualObjects()
        {
            return new List<Tuple<StringValueObject, StringValueObject>>
            {
                new Tuple<StringValueObject, StringValueObject>(new StringValueObject("me"), new StringValueObject("me"))
            };
        }

        protected override IList<Tuple<StringValueObject, StringValueObject>> GetUnequalObjects()
        {
            return new List<Tuple<StringValueObject, StringValueObject>>
            {
                new Tuple<StringValueObject, StringValueObject>(new StringValueObject("me"), new StringValueObject("not me"))
            };
        }
    }
}