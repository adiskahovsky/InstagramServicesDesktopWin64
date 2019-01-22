using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SmsLibrary.SmsOnline;

namespace SmsLibrary
{
    interface ISms
    {
        string GetNumber(List<string> countries);
        string GetSms();
        Dictionary<string, string> Proxy { get; set; }
    }
}
