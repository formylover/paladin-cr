using System;
using System.Net;
using System.IO;

namespace Paladin.Helpers
{
    public static class Version
    {
        public static bool CheckVersion(System.Version version)
        {
            // TODO send current version and on server check if it is a locked one
            WebRequest req = WebRequest.Create(string.Format("https://www.foo-bar.me/version.php?version={0}", version));
            WebResponse resp = req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string remoteVersion = sr.ReadToEnd().Trim();
            
            return remoteVersion != "1";
        }
    }
}
