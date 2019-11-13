using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.Config.AppCenter.Server
{
    public abstract class BaseAppCenterServerConfig : IAppCenterServerConfig
    {
        protected BaseAppCenterServerConfig(string organizationName, string apiToken)
        {
            OrganizationName = organizationName;
            ApiToken = apiToken;
        }

        public string ApiToken { get; }
        public string OrganizationName { get; }
        public Dictionary<RuntimePlatform, string> AppNames { get; } = new Dictionary<RuntimePlatform, string>();
    }
}