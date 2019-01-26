using Instagram;
using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Classes.Android;
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
    public class HTTPAndroid:IInstagram 
    {

        private string _ip;

        public string ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private int _port;

        private string _CsrfToken;

        public string CsrfToken
        {
            get { return _CsrfToken; }
            set { _CsrfToken = value; }
        }


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






       // private IResult<InstaResetChallenge> result2;
        /*
        public HTTPAndroid(string login,string password,string ip,int port,string proxyLogin,string proxyPassword)
        {
            _login = login;
            _password = password;
            _ip = ip;
            _port = port;
            _proxyLogin = proxyLogin;
            _proxyPassword = proxyPassword;
        }
        */
        public HTTPAndroid()
        {
            
        }


        //public async  Task<IResult<InstaLoginResult>> LoginWithNumber()
        //{
        //  //await   _instaApi.lo

        //}


        public async Task<IResult<bool>> LikePost(string uri)
        {
            var mediaId = await _instaApi.GetMediaIdFromUrlAsync(new Uri(uri));
           

            return await _instaApi.LikeMediaAsync(mediaId.Value);
        }


        public async Task<IResult<bool>> UnLikePost(string uri)
        {
            var mediaId = await _instaApi.GetMediaIdFromUrlAsync(new Uri(uri));
            return await _instaApi.UnLikeMediaAsync(mediaId.Value);
        }

        public async Task<IResult<InstaComment>> CommentPost(string uri)
        {
            var mediaId = await _instaApi.GetMediaIdFromUrlAsync(new Uri(uri));
            return await _instaApi.CommentMediaAsync(mediaId.Value,"Круто");


        }

        public async Task<IResult<bool>> UnCommentPost(string uri)
        {
            var mediaId = await _instaApi.GetMediaIdFromUrlAsync(new Uri(uri));
            return await _instaApi.DeleteCommentAsync(mediaId.Value,"Hello");
        }

        public async  Task<IResult<InstaFriendshipStatus >> Subscribe(string uri)
        {
           var userInfo =  await _instaApi.GetUserInfoByUsernameAsync("uri");
            return await _instaApi.FollowUserAsync(userInfo.Value.Pk);
        }

        public async Task<IResult<InstaFriendshipStatus>> UnSubscribe(string uri)
        {
            var userInfo = await _instaApi.GetUserInfoByUsernameAsync(uri);

            return await _instaApi.UnFollowUserAsync(userInfo.Value.Pk);
        }


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
            wp.Credentials = new NetworkCredential(_proxyUserName,_proxyPassword);
            httpHandler.Proxy = wp; //"178.124.152.84", 46854 17t3080724:KJLDdrcde9@91.227.155.166:7951
            var delay = RequestDelay.FromSeconds(1, 1);
            
            _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Exceptions)) 
                .SetRequestDelay(delay)
                .UseHttpClientHandler(httpHandler)
                .Build();

            var res = await _instaApi.LoginAsync();
            _CsrfToken = userSession.CsrfToken;
            return res;







          //  var res = await _instaApi.ChooseVerifyMethod(0);

            //result2 = await _instaApi.ResetChallenge();

           // var res2 = await _instaApi.SendVerifyCode("384296");

            //  result2.Value.StepData.FbAccessToken = "1474196902.65cde3b.a64eb27a579a49258b237afd6343e749";
            //result2.Value.StepData.Email = "micklewillwill911@gmail.com";
            //result2.Value.StepData.PhoneNumber = "+375297807148";



           // return await _instaApi.GetUserAsync("_sit.com_");
        }


    }
}
