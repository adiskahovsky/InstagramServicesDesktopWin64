using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Collections.ObjectModel;
using System.Threading;

namespace SmsLibrary
{
    public class SmsOnline
    {
        private const string _apiToken = "R9BVOS6S3QAFB9PMTMJPB9LO5QGJL3UNVF66YKVDQ16CCQAP6OCLOHCXDAN1";
        private OrderClass contr;

        public SmsOnline() { }

        public string GetNumber(List<string> countries, string ip, int port, string login, string password)
        {
            HttpWebRequest webRequest = WebRequest.Create("https://sms-online.pro/api/orders/create/24?api_token=R9BVOS6S3QAFB9PMTMJPB9LO5QGJL3UNVF66YKVDQ16CCQAP6OCLOHCXDAN1")
                            as HttpWebRequest;
            if (webRequest == null)
            {
                return null;
            }


            WebProxy wp = new WebProxy(ip, port);
            wp.Credentials = new NetworkCredential(login, password);

            webRequest.Proxy = wp;
            webRequest.ContentType = "application/json";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    contr = JsonConvert.DeserializeObject<OrderClass>(contributorsAsJson);

                    CheckStatus(contr.data.id);
                    while (CheckStatus(contr.data.id).data.state == "awaiting_phone")
                    {
                        CheckStatus(contr.data.id);
                        Thread.Sleep(8000);
                    }
                    s.Close();
                    sr.Close();
                    return CheckStatus(contr.data.id).data.phone;
                }
            }
        }

        public string GetSms()
        {
            CheckStatus(contr.data.id);

            if (CheckStatus(contr.data.id).data.state == "sms_timeout")
                CheckStatus(contr.data.id).data.reorder = true;

            while (CheckStatus(contr.data.id).data.state == "awaiting_sms")
            {
                CheckStatus(contr.data.id);
                Thread.Sleep(8000);
            }
            if (CheckStatus(contr.data.id).data.state == "success")
                return CheckStatus(contr.data.id).data.description;
            else
                return null;
        }

        public bool GetBalance()
        {
            var webRequest = WebRequest.Create("https://sms-online.pro/api/balance/get?api_token=R9BVOS6S3QAFB9PMTMJPB9LO5QGJL3UNVF66YKVDQ16CCQAP6OCLOHCXDAN1")
                as HttpWebRequest;

            if (webRequest == null)
            {
                return false;
            }

            webRequest.ContentType = "application/json";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    var contrs = JsonConvert.DeserializeObject<BalanceClass>(contributorsAsJson);
                }
            }
            return true;
        }

        private OrderStatusClass CheckStatus(int orderID)
        {
            var webRequest = WebRequest.Create($@"https://sms-online.pro/api/orders/status/{orderID}?api_token={_apiToken}")
                            as HttpWebRequest;
            if (webRequest == null)
            {
                return null;
            }

            webRequest.ContentType = "application/json";
            OrderStatusClass contrs = new OrderStatusClass();

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    contrs = JsonConvert.DeserializeObject<OrderStatusClass>(contributorsAsJson);
                }
            }
            return contrs;
        }

        #region WORKFLOW_JSON__GET_ALL_SERVICES
        public class WorkflowClass
        {
            public Workflow[] data { get; set; }
        }

        public class Workflow
        {
            public int id { get; set; }
            public string country { get; set; }
            public string country_code { get; set; }
            public string name { get; set; }
            public float price { get; set; }
            public object quantity { get; set; }
            public bool forwardable { get; set; }
            public string image_url { get; set; }
        }
        #endregion

        #region ORDER_JSON__GET_ORDER
        public class OrderClass
        {
            public Order data { get; set; }
        }

        public class Order
        {
            public int id { get; set; }
            public object sms_service_name { get; set; }
            public object country { get; set; }
            public object country_code { get; set; }
            public object image_url { get; set; }
            public string phone { get; set; }
            public string state { get; set; }
            public string state_descripted { get; set; }
            public bool cancelling_required { get; set; }
            public bool reorder { get; set; }
            public string forward_to { get; set; }
            public string description { get; set; }
            public string created_at { get; set; }
        }
        #endregion

        #region ORDER_STATUS_JSON__GET_STATUS
        public class OrderStatusClass
        {
            public OrderStatus data { get; set; }
        }

        public class OrderStatus
        {
            public int id { get; set; }
            public string sms_service_name { get; set; }
            public string country { get; set; }
            public string country_code { get; set; }
            public string image_url { get; set; }
            public string phone { get; set; }
            public string state { get; set; }
            public string state_descripted { get; set; }
            public bool cancelling_required { get; set; }
            public bool reorder { get; set; }
            public string forward_to { get; set; }
            public string description { get; set; }
            public string created_at { get; set; }
        }
        #endregion

        #region BALANSE_JSON__GET_BALANCE
        public class BalanceClass
        {
            public Balance data { get; set; }
        }

        public class Balance
        {
            public int balance { get; set; }
            public int frozen { get; set; }
        }
        #endregion
    }
}