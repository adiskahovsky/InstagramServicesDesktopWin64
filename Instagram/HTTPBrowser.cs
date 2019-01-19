using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;
using InstaSharper.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    class HTTPBrowser:IInstagram
    {
        private UserSessionData _user;
        private IInstaApi _api;

        public HTTPBrowser()
        {
            _user = new UserSessionData();
        }

        public IInstaApi InstaApi { get { return _api; } }

        private string _ip;

        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private int _port;

        public int port
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _proxyUserName;

        public string ProxyUserName
        {
            get { return _proxyUserName; }
            set { _proxyUserName = value; }
        }

        private string _proxyPassword;

        public string ProxyPassword
        {
            get { return _proxyPassword; }
            set { _proxyPassword = value; }
        }

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



        public async Task<IResult<InstaLoginResult>> Login()
        {
            var clientHandler = new HttpClientHandler();
            clientHandler.Proxy = new WebProxy(ip, port)
            {
                Credentials = new NetworkCredential(_proxyUserName, _proxyPassword)
            };

            _user.UserName = _username;
            _user.Password = _password;
            _user.CsrfToken = "LQKVEEt9LEtmZz36IYa4vJzLxLGjUv3G";
            _user.RankToken = "8286475698_8afad275-4fca-49e6-a5e0-3b2bbfe6e9f2";

            var delay = RequestDelay.FromSeconds(1, 1); //TODO: numeric_up_down delay
            _api = InstaApiBuilder.CreateBuilder()
                .SetUser(_user)
                .UseLogger(new DebugLogger(LogLevel.All))
                .UseHttpClientHandler(clientHandler)
                .SetRequestDelay(delay)
                .Build();


            var loginRequest = await _api.LoginAsync();
            
            return loginRequest;
            //var re = (await _api.ResetChallenge()).Value.StepData.Email = "adiska143@mail.ru";

            //var re2 = await _api.ResetChallenge();

            //var verify_result = await _api.ChooseVerifyMethod(1);
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
