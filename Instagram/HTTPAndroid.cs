using InstaSharper.API;
using InstaSharper.API.Builder;
using InstaSharper.Classes;
using InstaSharper.Classes.Models;
using InstaSharper.Classes.ResponseWrappers;
using InstaSharper.Logger;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace InstagramServicesDesktopWin64
{
    public class HTTPAndroid
    {

        string _login;string _password;string _ip;int _port;
        
        private IInstaApi _instaApi;
        public IInstaApi InstaApi
        { get { return _instaApi; } }
        private IResult<InstaResetChallenge> result2;

        public HTTPAndroid(string login,string password,string ip,int port)
        {
            _login = login;
            _password = password;
            _ip = ip;
            _port = port;
        }
        public async Task<IResult<InstaLoginResult>> Login()
        {

            var userSession = new UserSessionData
            {
                
                UserName = _login,
                Password = _password
               
            };
            var httpHandler = new HttpClientHandler();
            //test125:As158233@185.195.25.241:42343
            WebProxy wp = new WebProxy("91.227.155.166", 7951);
            wp.Credentials = new NetworkCredential("17t3080724", "KJLDdrcde9");
            httpHandler.Proxy = wp; //"178.124.152.84", 46854 17t3080724:KJLDdrcde9@91.227.155.166:7951
            var delay = RequestDelay.FromSeconds(1, 1);
            
            _instaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.Exceptions)) 
                .SetRequestDelay(delay)
                .UseHttpClientHandler(httpHandler)
                .Build();


             
            return await  _instaApi.LoginAsync();







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
