namespace Blauhaus.Common.Config.AppCenter
{
    public class AppCenterApp
    {
        public AppCenterApp(string appName, string appSecret, bool isCrashEnabled= true, bool isAnalyticsEnabled = true, bool isPushEnabled = true)
        {
            AppName = appName;
            AppSecret = appSecret;
            IsCrashEnabled = isCrashEnabled;
            IsAnalyticsEnabled = isAnalyticsEnabled;
            IsPushEnabled = isPushEnabled;
        }

        public string AppName { get; }
        public string AppSecret { get; }
        public bool IsPushEnabled { get;  } 
        public bool IsAnalyticsEnabled { get;  } 
        public bool IsCrashEnabled { get;  } 
    }
}