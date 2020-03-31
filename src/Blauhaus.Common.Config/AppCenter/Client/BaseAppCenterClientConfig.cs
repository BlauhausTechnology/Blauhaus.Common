using System.Collections.Generic;
using System.Text;
using Blauhaus.Common.ValueObjects.RuntimePlatforms;

namespace Blauhaus.Common.Config.AppCenter.Client
{
    public abstract class BaseAppCenterClientConfig : IAppCenterClientConfig
    {
        private string _connectionString = string.Empty;

        public Dictionary<RuntimePlatform, string> AppSecrets { get; } = new Dictionary<RuntimePlatform, string>();

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    var stringBuilder = new StringBuilder();
                    
                    if (AppSecrets.TryGetValue(RuntimePlatform.Android, out var androidAppSecret))
                    {
                        stringBuilder.Append($"android={androidAppSecret};");
                    }

                    if (AppSecrets.TryGetValue(RuntimePlatform.iOS, out var iosAppSecret))
                    {
                        stringBuilder.Append($"ios={iosAppSecret};");
                    }

                    if (AppSecrets.TryGetValue(RuntimePlatform.UWP, out var uwpAppSecret))
                    {
                        stringBuilder.Append($"uwp={uwpAppSecret};");
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