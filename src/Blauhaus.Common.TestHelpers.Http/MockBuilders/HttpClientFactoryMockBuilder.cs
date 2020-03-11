using System.Net.Http;
using Moq;

namespace Blauhaus.Common.TestHelpers.Http.MockBuilders
{
    public class HttpClientFactoryMockBuilder : BaseMockBuilder<HttpClientFactoryMockBuilder, IHttpClientFactory>
    {

        public HttpClientFactoryMockBuilder Where_CreateClient_returns(HttpClient client, string clientName = "")
        {
            Mock.Setup(x => x.CreateClient(string.IsNullOrEmpty(clientName) ? It.IsAny<string>() : clientName))
                .Returns(client);

            return this;
        }
    }
}