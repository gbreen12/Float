using System.Configuration;

namespace Float
{
    public static class FloatConfig
    {
        private const string FLOAT_AUTH_TOKEN = "FloatAuthToken";
        private static string _authToken;
        public static string AuthToken
        {
            get
            {
                if (string.IsNullOrEmpty(_authToken))
                    _authToken = ConfigurationManager.AppSettings[FLOAT_AUTH_TOKEN];

                return _authToken;
            }
            set
            {
                _authToken = value;
            }
        }

        private const string USER_AGENT = "FloatUserAgent";
        private static string _userAgent;
        public static string UserAgent
        {
            get
            {
                if (string.IsNullOrEmpty(_userAgent))
                    _userAgent = ConfigurationManager.AppSettings[USER_AGENT];

                return _userAgent;
            }
            set
            {
                _userAgent = value;
            }
        }
    }
}
