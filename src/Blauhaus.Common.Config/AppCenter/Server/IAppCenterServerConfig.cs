using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.Config.AppCenter.Server
{
    public interface IAppCenterServerConfig
    {
        string ApiToken { get; }
        string OrganizationName { get; } 

        Dictionary<RuntimePlatform, string> AppNames { get; }

    }
}