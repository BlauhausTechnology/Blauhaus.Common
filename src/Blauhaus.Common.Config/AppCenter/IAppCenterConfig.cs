using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.Config.AppCenter
{
    public interface IAppCenterConfig
    {
        string ApiToken { get; }
        string OrganizationName { get; } 

        Dictionary<RuntimePlatform, AppCenterApp> Apps { get; }
    }
}