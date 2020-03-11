using System.Net.Http;
using Moq;

namespace Blauhaus.Common.TestHelpers.Http.MockBuilders
{
    public class HttpClientFactoryMockBuilder : BaseMockBuilder<HttpClientFactoryMockBuilder, IHttpClientFactory>
    {

        public HttpClientFactoryMockBuilder Where_CreateClient_returns(HttpClient client, string clientName = "")
        {
            if (string.IsNullOrEmpty(clientName))
            {
                Mock.Setup(x => x.CreateClient(It.IsAny<string>()))
                    .Returns(client);
            }
            else
            {
                Mock.Setup(x => x.CreateClient(clientName))
                    .Returns(client);
            }

            return this;
        }
    }
}