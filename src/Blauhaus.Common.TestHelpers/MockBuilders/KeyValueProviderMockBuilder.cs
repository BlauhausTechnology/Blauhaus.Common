using System;
using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.Abstractions;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.Common.TestHelpers.MockBuilders
{
    public class KeyValueProviderMockBuilder : BaseMockBuilder<KeyValueProviderMockBuilder, IKeyValueProvider>
    {
        public KeyValueProviderMockBuilder Where_TryGetValue_returns(string? value)
        {
            Mock.Setup(x => x.TryGetValue(It.IsAny<string>())).Returns(value);
            return this;
        }
        
        public KeyValueProviderMockBuilder Where_TryGetValue_returns(string? value, string key)
        {
            Mock.Setup(x => x.TryGetValue(key)).Returns(value);
            return this;
        }
    }
}
