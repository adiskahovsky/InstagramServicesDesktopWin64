using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmsLibrary
{
    class SimSms : ISms
    {
        private const string _apiToken = "H8DYuXSV1N86kYUQ9cgrXt5f4bzKre";
        private int _orderId;
        private string randomCountry;

        private Dictionary<string, string> _proxy;
        public Dictionary<string, string> Proxy
        {
            get { return _proxy; }
            set { _proxy = value; }
        }


        public string GetBalance()
        {
            HttpWebRequest webRequest = WebRequest.Create
                ($"http://simsms.org/priemnik.php?metod=get_balance&service=opt16&apikey={_apiToken}&service_id=instagram")
                            as HttpWebRequest;
            if (webRequest == null)
                return null;

            WebProxy wp = new WebProxy(_proxy["ip"], Int32.Parse(_proxy["port"]));
            wp.Credentials = new NetworkCredential(_proxy["username"], _proxy["password"]);

            webRequest.Proxy = wp;
            webRequest.ContentType = "application/json";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<Balance>(contributorsAsJson);

                    s.Close();
                    sr.Close();
                    return result.balance;
                }
            }
        }

        public string GetNumber(List<string> countries)
        {
            randomCountry = countries[Randomer.Next(countries.Count)];
            HttpWebRequest webRequest = WebRequest.Create
                ($"http://simsms.org/priemnik.php?metod=get_number&country={randomCountry}&service=opt16&id=1&apikey={_apiToken}")
                            as HttpWebRequest;
            if (webRequest == null)
                return null;

            //TODO: Check available numbers for country

            WebProxy wp = new WebProxy(_proxy["ip"], Int32.Parse(_proxy["port"]));
            wp.Credentials = new NetworkCredential(_proxy["username"], _proxy["password"]);

            webRequest.Proxy = wp;
            webRequest.ContentType = "application/json";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<OrderNumber>(contributorsAsJson);

                    _orderId = result.id;
                    s.Close();
                    sr.Close();
                    return result.CountryCode + result.number;
                }
            }
        }        

        public string GetSms()
        {
            HttpWebRequest webRequest = WebRequest.Create
                ($"http://simsms.org/priemnik.php?metod=get_sms&country={randomCountry}&service=opt16&id={_orderId}&apikey={_apiToken}")
                            as HttpWebRequest;
            if (webRequest == null)
                return null;

            WebProxy wp = new WebProxy(_proxy["ip"], Int32.Parse(_proxy["port"]));
            wp.Credentials = new NetworkCredential(_proxy["username"], _proxy["password"]);

            webRequest.Proxy = wp;
            webRequest.ContentType = "application/json";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    var result = JsonConvert.DeserializeObject<OrderSms>(contributorsAsJson);

                    _orderId = result.id;
                    s.Close();
                    sr.Close();
                    return result.sms?.ToString();
                }
            }
        }


        public class OrderSms
        {
            public string response { get; set; }
            public object number { get; set; }
            public int id { get; set; }
            public object text { get; set; }
            public string extra { get; set; }
            public float karma { get; set; }
            public string pass { get; set; }
            public object sms { get; set; }
            public int balanceOnPhone { get; set; }
        }
        
        public class OrderNumber
        {
            public string response { get; set; }
            public string number { get; set; }
            public int id { get; set; }
            public int again { get; set; }
            public object text { get; set; }
            public string extra { get; set; }
            public float karma { get; set; }
            public object pass { get; set; }
            public object sms { get; set; }
            public int balanceOnPhone { get; set; }
            public object service { get; set; }
            public object country { get; set; }
            public string CountryCode { get; set; }
            public int branchId { get; set; }
            public bool callForwarding { get; set; }
        }

        public class Balance
        {
            public string response { get; set; }
            public string balance { get; set; }
        }
    }
}
