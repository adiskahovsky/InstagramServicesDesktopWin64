using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramServicesDesktopWin64
{
    public static class LinkConverter
    {

        public static string ConvertToInstaUserName(string link)
        {
            var result = link.Split(new string[] { "//", "/" }, StringSplitOptions.None);
            return result[2];
            

        }


    }
}
