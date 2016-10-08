using System;
using System.Net;
using System.Net.Cache;
using System.IO;
using System.Text.RegularExpressions;

namespace Paladin.Helpers
{
    public static class Version
    {
        public static bool CheckVersion()
        {
            return CurrentLocalVersion >= CurrentRemoteVersion;
        }

        private static System.Version _localVersion;
        public static System.Version CurrentLocalVersion
        {
            get
            {
                if (_localVersion == null)
                {
                    _localVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                }

                return _localVersion;
            }
        }

        private static System.Version _remoteVersion;
        public static System.Version CurrentRemoteVersion
        {
            get
            {
                if (_remoteVersion == null)
                {
                    WebResponse resp = GetResponseNoCache("https://raw.githubusercontent.com/oruna/paladin-cr/master/Helpers/Version.cs");
                    if (resp == null) return new System.Version(0,0,0);
                    StreamReader sr = new StreamReader(resp.GetResponseStream());

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Regex regex = new Regex(@"new System\.Version\((.*)\)");
                        Match match = regex.Match(line);

                        if (match.Success && match.Groups.Count >= 2)
                        {
                            _remoteVersion = new System.Version(match.Groups[1].Value.Replace(",", ".").Replace(" ", ""));
                            break;
                        }
                    }
                }
                return _remoteVersion;
            }
        }

        private static string _changelog;
        public static string Changelog
        {
            get
            {
                if (_changelog == null)
                {
                    WebResponse resp = GetResponseNoCache("https://raw.githubusercontent.com/oruna/paladin-cr/master/CHANGELOG");
                    if (resp == null) return "";
                    StreamReader sr = new StreamReader(resp.GetResponseStream());
                    _changelog = sr.ReadToEnd();
                }

                return _changelog;
            }
        }

        public static WebResponse GetResponseNoCache(string url)
        {
            try
            {
                // Set a default policy level for the "http:" and "https" schemes.
                HttpRequestCachePolicy policy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Default);
                HttpWebRequest.DefaultCachePolicy = policy;
                // Create the request.
                WebRequest request = WebRequest.Create(url);
                // Define a cache policy for this request only. 
                HttpRequestCachePolicy noCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
                request.CachePolicy = noCachePolicy;
                WebResponse response = request.GetResponse();
                return response;
            }
            catch (Exception) { }

            return null;
        }
    }
}
