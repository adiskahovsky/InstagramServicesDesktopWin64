using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServicesDesktopWin64
{
    public static class UsersParse
    {
        public static Dictionary<string, string> Parse(string user)
        {

            string[] result = user.Split(':');

            Dictionary<string, string> userDict = new Dictionary<string, string>();



            userDict.Add("maillogin", result[2]);
            userDict.Add("mailpassword", result[3]);
            userDict.Add("username", result[0]);
            userDict.Add("password", result[1]);
            return userDict;

        }

    }
}