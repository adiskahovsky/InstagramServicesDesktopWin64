using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmsLibrary
{
    public class CheapSms : ISms
    {
        private const string _apiToken = "7ae295999ac3c18881833c3d3c97b486";
        private string _orderId;

        private Dictionary<string, string> _proxy;
        public Dictionary<string, string> Proxy
        {
            get { return _proxy; }
            set { _proxy = value; }
        }


        /// <summary>
        /// Returns count of numbers available for instagram on cheapsms service
        /// </summary>
        /// <returns>number count</returns>
        public int GetNumberCount()
        {
            HttpWebRequest webRequest = WebRequest.Create($"https://cheapsms.pro/handler/index?api_key={_apiToken}&action=getNumbersStatus&country=$country")
                            as HttpWebRequest;

            if (webRequest == null)
                return -1;
<<<<<<< HEAD

=======
            
>>>>>>> d6f5b8f... settings class
            WebProxy wp = new WebProxy(_proxy["ip"], Int32.Parse(_proxy["port"]));
            wp.Credentials = new NetworkCredential(_proxy["username"], _proxy["password"]);

            webRequest.Proxy = wp;
            NumberCount result = new NumberCount();
            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    result = JsonConvert.DeserializeObject<NumberCount>(contributorsAsJson);
                }
            }
            return result.ig_0;
        }

        /// <summary>
        /// create request and return number from cheapsms service
        /// </summary>
        /// <param name="countries">not useable</param>
        /// <returns>number</returns>
        public string GetNumber(List<string> countries = null)
        {
            HttpWebRequest webRequest = WebRequest.Create($"http://cheapsms.pro/stubs/handler_api.php?api_key={_apiToken}&action=getNumber&service=ig_0")
                            as HttpWebRequest;

            if (webRequest == null)
                return null;


            WebProxy wp = new WebProxy(_proxy["ip"], Int32.Parse(_proxy["port"]));
            wp.Credentials = new NetworkCredential(_proxy["username"], _proxy["password"]);

            webRequest.Proxy = wp;
            string number = null;

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributors = sr.ReadToEnd();
                    var res = contributors.Split(':');
                    number = res[2];
                    _orderId = res[1];
                }
            }
            return number;
        }

        /// <summary>
        /// create request for current orderId and returns sms code
        /// </summary>
        /// <returns>sms code</returns>
        public string GetSms()
        {
            string sms = null;
            HttpWebRequest setStatusRequest = WebRequest.Create
                ($"https://cheapsms.pro/handler/index?api_key={_apiToken}&&action=setStatus&status=1&id={_orderId}")
                            as HttpWebRequest;

            if (setStatusRequest == null)
                return null;


            WebProxy wp = new WebProxy(_proxy["ip"], Int32.Parse(_proxy["port"]));
            wp.Credentials = new NetworkCredential(_proxy["username"], _proxy["password"]);

            setStatusRequest.Proxy = wp;
            using (setStatusRequest.GetResponse().GetResponseStream())
            {
                HttpWebRequest smsRequest = WebRequest.Create
                    ($"http://cheapsms.pro/stubs/handler_api.php?api_key={_apiToken}&action=getStatus&id={_orderId}")
                            as HttpWebRequest;

                if (smsRequest == null)
                    return null;

                smsRequest.Proxy = wp;
                using (var s = smsRequest.GetResponse().GetResponseStream())
                {
                    using (var sr = new StreamReader(s))
                    {
                        string wait = sr.ReadToEnd();
                        while (wait == "STATUS_WAIT_CODE")
                        {
                            var reset = smsRequest.GetResponse().GetResponseStream();
                            var res = new StreamReader(reset);
                            wait = res.ReadToEnd();
                        }
                        sms = wait.Split(':')[1];
                    }
                }
            }
            return sms;
        }


        
        public class NumberCount
        {
            public int vk_0 { get; set; }
            public int ok_0 { get; set; }
            public int vi_0 { get; set; }
            public int tg_0 { get; set; }
            public int go_0 { get; set; }
            public int fb_0 { get; set; }
            public int tw_0 { get; set; }
            public int ig_0 { get; set; }
            public int ss_0 { get; set; }
            public int ym_0 { get; set; }
            public int ma_0 { get; set; }
            public int mb_0 { get; set; }
            public int ot_0 { get; set; }
            public int qw_0 { get; set; }
            public int wb_0 { get; set; }
            public int av_0 { get; set; }
            public int ub_0 { get; set; }
            public int gt_0 { get; set; }
            public int sn_0 { get; set; }
            public int we_0 { get; set; }
            public int ya_0 { get; set; }
            public int mt_0 { get; set; }
            public string oi_0 { get; set; }
            public int fd_0 { get; set; }
            public int pm_0 { get; set; }
            public int oy_0 { get; set; }
            public int sm_0 { get; set; }
            public int wm_0 { get; set; }
            public int fs_0 { get; set; }
            public int mm_0 { get; set; }
            public string cp_0 { get; set; }
            public int py_0 { get; set; }
            public int pk_0 { get; set; }
            public int sp_0 { get; set; }
            public int ds_0 { get; set; }
            public int wp_0 { get; set; }
            public int dd_0 { get; set; }
            public int vt_0 { get; set; }
            public int vm_0 { get; set; }
            public string mg_0 { get; set; }
            public string bd_0 { get; set; }
            public string dc_0 { get; set; }
            public string dt_0 { get; set; }
            public string rn_0 { get; set; }
            public int find_0 { get; set; }
        }
    }
}