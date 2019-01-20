﻿using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Logger;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using InstaSharper.Classes.Models;

namespace Instagram
{
<<<<<<< HEAD
    public class HTTPBrowser
=======
    public class HTTPBrowser:IInstagram
>>>>>>> 075896b... Creating smsOnline class  selenium changing number(uncorrect)
    {
        private UserSessionData _user;
        private IInstaApi _api;

        public HTTPBrowser()
        {
            _user = new UserSessionData();
        }

<<<<<<< HEAD
        public async void Login(string username, string password, string ip, int port, string proxy_userName, string proxy_pass)
=======
        public IInstaApi InstaApi { get { return _api; } }

        #region PIZ
        private string _ip;

        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private int _port;

        public int port
>>>>>>> 075896b... Creating smsOnline class  selenium changing number(uncorrect)
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.Proxy = new WebProxy(ip, port)
            {
                Credentials = new NetworkCredential(proxy_userName, proxy_pass)
            };

            _user.UserName = username;
            _user.Password = password;
            _user.CsrfToken = "LQKVEEt9LEtmZz36IYa4vJzLxLGjUv3G";
            _user.RankToken = "8286475698_8afad275-4fca-49e6-a5e0-3b2bbfe6e9f2";

<<<<<<< HEAD
            var delay = RequestDelay.FromSeconds(1, 1); //TODO: numeric_up_down delay
            _api = InstaApiBuilder.CreateBuilder()
                .SetUser(_user)
                .UseLogger(new DebugLogger(LogLevel.All))
                .UseHttpClientHandler(clientHandler)
                .SetRequestDelay(delay)
                .Build();


            var loginRequest = await _api.LoginAsync();
            //var re = (await _api.ResetChallenge()).Value.StepData.Email = "adiska143@mail.ru";

            var re2 = await _api.ResetChallenge();

            var verify_result = await _api.ChooseVerifyMethod(1); //0 - mobile/phone, 1 - email
            //var req =   System.Net.HttpWebRequest.Create("https://www.instagram.com/accounts/edit/");
        }

        SelenInst selen;
        public async void LoginAndResetPhone(string username, string password, string ip, int port, string proxy_userName, string proxy_pass)
=======
        public string ProxyPassword
        {
            get { return _proxyPassword; }
            set { _proxyPassword = value; }
        }
        #endregion

        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        private Dictionary<string, string> _proxtDict;
        public Dictionary<string, string> ProxyDictionary
        {
            get { return _proxtDict; }
            set { _proxtDict = value; }
        }


        public async Task<IResult<InstaLoginResult>> Login()
>>>>>>> 075896b... Creating smsOnline class  selenium changing number(uncorrect)
        {
            selen = new SelenInst();
            var clientHandler = new HttpClientHandler();
            clientHandler.Proxy = new WebProxy(_proxtDict["ip"], Int32.Parse(_proxtDict["port"]))
            {
<<<<<<< HEAD
                Credentials = new NetworkCredential(proxy_userName, proxy_pass)
=======
                Credentials = new NetworkCredential(_proxtDict["username"], _proxtDict["password"])
>>>>>>> 075896b... Creating smsOnline class  selenium changing number(uncorrect)
            };

            _user.UserName = username;
            _user.Password = password;

            var delay = RequestDelay.FromSeconds(1, 1); //TODO: numeric_up_down delay

            #region ChangeNumber
            selen.AddNewInstagramNumber("375297807147", username, password);
            #endregion

            _api = InstaApiBuilder.CreateBuilder()
                .SetUser(_user)
                .UseLogger(new DebugLogger(LogLevel.All))
                .UseHttpClientHandler(clientHandler)
                .SetRequestDelay(delay)
                .Build();


            var loginRequest = await _api.LoginAsync();
<<<<<<< HEAD
=======
            var verify_result = await _api.ChooseVerifyMethod(0);

            return loginRequest;
>>>>>>> 075896b... Creating smsOnline class  selenium changing number(uncorrect)
            //var re = (await _api.ResetChallenge()).Value.StepData.Email = "adiska143@mail.ru";

            var re2 = await _api.ResetChallenge();

<<<<<<< HEAD
            var verify_result = await _api.ChooseVerifyMethod(1); //0 - mobile/phone, 1 - email
            //var req =   System.Net.HttpWebRequest.Create("https://www.instagram.com/accounts/edit/");
=======
>>>>>>> 075896b... Creating smsOnline class  selenium changing number(uncorrect)
        }

        public async Task<IResult<InstaUser>> Verify(string code)
        {
            var verifyResult = await _api.SendVerifyCode(code); //verify from sms-online and other...
            //selen.RemoveInstagramNumber();
            var res = await _api.ResetChallenge();
            return await _api.GetUserAsync("_sit.com_"); //TODO: log
        }
    }
}