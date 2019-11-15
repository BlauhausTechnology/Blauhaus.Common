using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;

namespace Blauhaus.Common.TestHelpers
{

    public abstract class BaseMockBuilder<TMockBuilder, TMock> 
        where TMockBuilder : BaseMockBuilder<TMockBuilder, TMock>
        where TMock : class
    {
        public readonly Mock<TMock> Mock = new Mock<TMock>();
        public TMock Object => Mock.Object;
        public List<TMock> ToList => new List<TMock>{Mock.Object};

        public TMockBuilder With<TProperty>(Expression<Func<TMock, TProperty>> expression, TProperty value)
        {
            Mock.Setup(expression).Returns(value);
            return this as TMockBuilder;
        }
    }
}