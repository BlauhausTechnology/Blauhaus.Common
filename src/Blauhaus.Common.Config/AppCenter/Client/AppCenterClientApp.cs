namespace Blauhaus.Common.Config.AppCenter.Client
{
    public class AppCenterClientApp
    {
        public AppCenterClientApp(string appName, string appSecret, bool isPushEnabled = true)
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