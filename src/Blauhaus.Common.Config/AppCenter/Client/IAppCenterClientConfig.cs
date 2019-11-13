using System.Collections.Generic;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.Config.AppCenter.Client
{
    public interface IAppCenterClientConfig
    {

        Dictionary<RuntimePlatform, string> AppSecrets { get; }

        string ConnectionString { get; }
    }
}