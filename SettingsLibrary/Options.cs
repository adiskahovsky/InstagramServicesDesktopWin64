using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsLibrary
{
    public static class Options
    {
        public static List<string> SmsOnlineCountries { get; set; }
        public static List<string> SimSmsCountries { get; set; }

        public static Dictionary<string, int> InstUnsub_WorkDelay { get; set; }
        public static Dictionary<string, int> InstUnsub_RequestCount { get; set; }
        public static Dictionary<string, int> InstUnsub_RequestDelay_InMinutes { get; set; }

        public static int InstUnsubDeleteCount { get; set; }
        public static int InstUnsubLoadAccount_InMinutes { get; set; }
        public static int SmsRequestDelay { get; set; }
        public static int LoadAccountDelay_InSeconds { get; set; }

        public static bool IsSafeAllLogsEnabled { get; set; }
        public static bool IsSafeTokenEnabled { get; set; }
        public static bool IsNoShowLogEnabled { get; set; }
        public static bool IsDetailedLogEnabled { get; set; }
        public static bool IsRandomUnsubDelay_InstLoginEnabled { get; set; }
        public static bool IsSmsActivate_UsingEnabled { get; set; }
        public static bool IsCheapSms_UsingEnabled { get; set; }
        public static bool IsVakSms_UsingEnabled { get; set; }
        public static bool IsSimSms_UsingEnabled { get; set; }
        public static bool IsSmsOnline_UsingEnabled { get; set; }
        public static bool IsSmsWithoutProxyEnabled { get; set; }
    }
}
