using System;
using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{

    public class KeyValueProviderMockBuilder : BaseKeyValueProviderMockBuilder<KeyValueProviderMockBuilder, IKeyValueProvider>
    {
    }

    public abstract class BaseKeyValueProviderMockBuilder<TBuilder, TMock> : BaseMockBuilder<TBuilder, TMock>
        where TBuilder : BaseKeyValueProviderMockBuilder<TBuilder, TMock>
        where TMock : class, IKeyValueProvider
    {
        public TBuilder Where_TryGetValue_returns(string? value)
        {
            Mock.Setup(x => x.TryGetValue(It.IsAny<string>())).Returns(value);
            return (TBuilder)this;
        }
        
        public TBuilder Where_TryGetValue_returns(string? value, string key)
        {
            Mock.Setup(x => x.TryGetValue(key)).Returns(value);
            return (TBuilder)this;
        }
        
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
