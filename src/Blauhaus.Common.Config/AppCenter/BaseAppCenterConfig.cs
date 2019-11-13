using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.Config.AppCenter
{
    public abstract class BaseAppCenterConfig : IAppCenterConfig
    {
        private string _connectionString = string.Empty;


        public string ApiToken { get; protected set; }
        public string OrganizationName { get; protected set; }
        public Dictionary<RuntimePlatform, AppCenterApp> Apps { get; } = new Dictionary<RuntimePlatform, AppCenterApp>();

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    var stringBuilder = new StringBuilder();
                    
                    if (Apps.TryGetValue(RuntimePlatform.Android, out var androidApp))
                    {
                        stringBuilder.Append($"android={androidApp.AppSecret};");
                    }

                    if (Apps.TryGetValue(RuntimePlatform.iOS, out var iosApp))
                    {
                        stringBuilder.Append($"ios={iosApp.AppSecret};");
                    }

                    if (Apps.TryGetValue(RuntimePlatform.UWP, out var uwpApp))
                    {
                        stringBuilder.Append($"uwp={uwpApp.AppSecret};");
                    }
                
                    if (stringBuilder.Length > 0)
                    {
                        //trim last semicolon
                        stringBuilder.Length -= 1;

                        _connectionString = stringBuilder.ToString();
                    }
                }

                return _connectionString;
            }
        }
    }
}