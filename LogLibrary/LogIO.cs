using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public static class LogIO
    {
        public static string path = "FirstLog.log";
        public delegate void Logging(string text,Log log);
        public static void WriteLog(string path, Log log)
        {
            try
            {
                File.WriteAllText(path, log.ToString());
            }
            catch (Exception ex)
            {

            }
        }




    }
}
