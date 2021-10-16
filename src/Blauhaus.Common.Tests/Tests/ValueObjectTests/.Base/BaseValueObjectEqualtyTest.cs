using System;
using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.Base;
using Blauhaus.TestHelpers.BaseTests;
using NUnit.Framework;

namespace Blauhaus.Common.Tests.Tests.ValueObjectTests.Base
{
    public abstract class BaseValueObjectEqualtyTest<TSut> : BaseUnitTest<TSut> 
        where TSut : BaseValueObject<TSut> 
    {

        [Test]
        public void WHEN_values_are_the_same_SHOULD_return_TRUE()
        {
            foreach (var equalObjectPair in GetEqualObjects())
            {
                var item1 = equalObjectPair.Item1;
                var item2 = equalObjectPair.Item2;

                Assert.AreEqual(item1, item2);
                Assert.That(item1 == item2, Is.True);
                Assert.That(item1 != item2, Is.False);
                Assert.That(item1.GetHashCode(), Is.EqualTo(item2.GetHashCode()));
                Assert.That(item1.Equals(item2), Is.True);
            }
        }
        
        
        [Test]
        public void WHEN_values_are_not_the_same_SHOULD_return_FALSE()
        {
            foreach (var unequalObjectPair in GetUnequalObjects())
            {
                var item1 = unequalObjectPair.Item1;
                var item2 = unequalObjectPair.Item2;

                Assert.AreNotEqual(item1, item2);
                Assert.That(item1 != item2, Is.True);
                Assert.That(item1 == item2, Is.False);
                Assert.That(item1.GetHashCode(), Is.Not.EqualTo(item2.GetHashCode()));
                Assert.That(item1.Equals(item2), Is.False);
            }
        }

        protected abstract IList<Tuple<TSut, TSut>> GetEqualObjects();
        protected abstract IList<Tuple<TSut, TSut>> GetUnequalObjects();

        
        
        protected override TSut ConstructSut()
        {
            throw new InvalidOperationException("Populate Suts using GetEqualObjects() and GetUnequalObjects()");
        }


    }


}