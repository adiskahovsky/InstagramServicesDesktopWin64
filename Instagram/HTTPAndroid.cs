using Instagram;
using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;
using InstaSharper.Classes.ResponseWrappers;
using InstaSharper.Logger;
using MailWorker;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramServicesDesktopWin64
{
    public class HTTPAndroid : IInstagram
    {

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


        private IInstaApi _instaApi;
        public IInstaApi InstaApi
        { get { return _instaApi; } }
        private Mail _mail;
        public Mail mail { get { return _mail; } set { _mail = value; } }

        public HTTPAndroid()
        {        }

        public async Task<IResult<InstaLoginResult>> Login()
        {
            var userSession = new UserSessionData
            {
                UserName = _username,
                Password = _password
            };
            var httpHandler = new HttpClientHandler();
            //test125:As158233@185.195.25.241:42343
            WebProxy wp = new WebProxy(_ip, _port);
            wp.Credentials = new NetworkCredential(_proxyUserName, _proxyPassword);
            httpHandler.Proxy = wp; //"178.124.152.84", 46854 17t3080724:KJLDdrcde9@91.227.155.166:7951
            var delay = RequestDelay.FromSeconds(1, 1);

            _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Exceptions))
                .SetRequestDelay(delay)
                .UseHttpClientHandler(httpHandler)
                .Build();
            
            return await _instaApi.LoginAsync();
        }
    }
}