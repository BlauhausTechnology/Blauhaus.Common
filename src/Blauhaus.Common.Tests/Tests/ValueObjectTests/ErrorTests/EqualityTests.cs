using System;
using System.Collections.Generic;
using Blauhaus.Common.Tests.Tests.ValueObjectTests._Base;
using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class EqualityTests : BaseValueObjectEqualtyTest<Error, Error>
    {

        protected override IList<Tuple<Error, Error>> GetEqualObjects()
        {
            return new List<Tuple<Error, Error>>
            {
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("ErrorCode", "ErrorDescription")),
                new Tuple<Error, Error>(TestErrors.TestErrorOne, TestErrors.TestErrorOne)
            };
        }

        protected override IList<Tuple<Error, Error>> GetUnequalObjects()
        {
            return new List<Tuple<Error, Error>>
            {
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("ErrorCode", "Wrong")),
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("Wrong", "ErrorDescription")),
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("Wrong", "Wrong")),
                new Tuple<Error, Error>(TestErrors.TestErrorOne, TestErrors.TestErrorTwo),
                new Tuple<Error, Error>(TestErrors.TestErrorTwo, TestErrors.TestErrorOne)
            };
        }
    }
}