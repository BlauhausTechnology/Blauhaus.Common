using System;
using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public class KeyValueStoreMockBuilder : BaseKeyValueStoreMockBuilder<KeyValueStoreMockBuilder, IKeyValueStore>
    {
    }

    public abstract class BaseKeyValueStoreMockBuilder<TBuilder, TMock> : BaseMockBuilder<TBuilder, TMock>
        where TBuilder : BaseKeyValueStoreMockBuilder<TBuilder, TMock>
        where TMock : class, IKeyValueStore
    { 
        public TBuilder Where_GetAsync_returns(string value)
        {
            Mock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(value);
            return (TBuilder)this;
        }

        public TBuilder Where_GetAsync_returns(string key, string value)
        {
            Mock.Setup(x => x.GetAsync(key)).ReturnsAsync(value);
            return (TBuilder)this;
        }

        public void VerifySetAsyncCalled(string key, string value)
        {
            Mock.Verify(x => x.SetAsync(key, value));
        }
        
        public void VerifyGetAsyncCalled(string key)
        {
            Mock.Verify(x => x.GetAsync(key));
        }
        
        public void VerifyRemoveCalled(string key)
        {
            Mock.Verify(x => x.Remove(key));
        }
        
    }
    
    
    
    
}
