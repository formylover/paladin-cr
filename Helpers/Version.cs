using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Paladin.Helpers
{
    public static class Version
    {
        public static bool CheckVersion()
        {
            return CurrentLocalVersion() == CurrentRemoteVersion();
        }

        public static System.Version CurrentLocalVersion()
        {
            return new System.Version(0, 2, 0);
        }

        public static System.Version CurrentRemoteVersion()
        {
            WebRequest req = WebRequest.Create("https://raw.githubusercontent.com/oruna/paladin-cr/master/Helpers/Version.cs");
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Regex regex = new Regex(@"new System\.Version\((.*)\)");
                Match match = regex.Match(line);

                if (match.Success)
                    return new System.Version(match.Value);
            }

            return null;
        }
    }
}
