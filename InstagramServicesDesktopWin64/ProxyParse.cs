using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServicesDesktopWin64
{
   public static class ProxyParse
    {

        public static Dictionary<string, string> Parse(string private_proxy)
        {
            Dictionary<string, string> proxyDict = new Dictionary<string, string>();

            string[] UNameLog = private_proxy.Split('@');

            string[] UnamePass = UNameLog[0].Split(':');
            string[] IpPort = UNameLog[1].Split(':');

            proxyDict.Add("ip", IpPort[0]);
            proxyDict.Add("port", IpPort[1]);
            proxyDict.Add("username", UnamePass[0]);
            proxyDict.Add("password", UnamePass[1]);

            return proxyDict;
        }
    }
}
