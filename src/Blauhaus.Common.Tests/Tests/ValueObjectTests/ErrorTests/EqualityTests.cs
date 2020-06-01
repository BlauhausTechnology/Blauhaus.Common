using System;
using System.Collections.Generic;
using Blauhaus.Common.Tests.Tests.ValueObjectTests._Base;
using Blauhaus.Common.ValueObjects.Errors;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.ErrorTests
{
    public class EqualityTests : BaseValueObjectEqualtyTest<Error>
    {

        protected override IList<Tuple<Error, Error>> GetEqualObjects()
        {
            return new List<Tuple<Error, Error>>
            {
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("ErrorCode", "ErrorDescription")),
                new Tuple<Error, Error>(TestErrors.TestErrorOne, TestErrors.TestErrorOne),
                new Tuple<Error, Error>(TestErrors.TestErrorThree("three"), TestErrors.TestErrorThree("three")),
                new Tuple<Error, Error>(TestErrors.TestErrorThree("four"), TestErrors.TestErrorThree("three")),
                new Tuple<Error, Error>(TestErrors.TestErrorThree("three"), TestErrors.TestErrorThree("four")),
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("ErrorCode", "Same Code Different Description")),
            };
        }

        protected override IList<Tuple<Error, Error>> GetUnequalObjects()
        {
            return new List<Tuple<Error, Error>>
            {
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("Same Description Different Code", "ErrorDescription")),
                new Tuple<Error, Error>(new Error("ErrorCode", "ErrorDescription"), new Error("Different Code", "Different Description")),
                new Tuple<Error, Error>(TestErrors.TestErrorOne, TestErrors.TestErrorTwo),
                new Tuple<Error, Error>(TestErrors.TestErrorTwo, TestErrors.TestErrorOne),
                new Tuple<Error, Error>(TestErrors.TestErrorTwo, TestErrors.TestErrorThree("3")),
            };
        }
    }
}