namespace Blauhaus.Common.Config.AppCenter
{
    public class AppCenterApp
    {
        public AppCenterApp(string appName, string appSecret, bool isPushEnabled = true)
        {
            AppName = appName;
            AppSecret = appSecret;
            IsPushEnabled = isPushEnabled;
        }

        public string AppName { get; }
        public string AppSecret { get; }
        public bool IsPushEnabled { get;  } 
    }
}