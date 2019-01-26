using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HtmlAgilityPack;
using Instagram;
using MailWorker;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace InstagramServicesDesktopWin64
{
    /// <summary>
    /// Логика взаимодействия для InstagramTest.xaml
    /// </summary>
    public partial class InstagramTest : Window
    {

        List<BackgroundWorker> workers;

        List<IInstagram> users;
        List<IInstagram> Login_Users;
        int sum = 0;

        private delegate void Logging();

        public InstagramTest()
        {
            workers = new List<BackgroundWorker>();
            users = new List<IInstagram>();
            Login_Users = new List<IInstagram>();
            
            InitializeComponent();
           
        }



        

       

        private async void Start(object sender, RoutedEventArgs e)
        {

            string [] Proxy = File.ReadAllLines(tbProxy.Text);

            string[] UsersString = File.ReadAllLines(tbUsers.Text);


            foreach (var userString in UsersString)
            {

                if (rbBrowser.IsChecked == true)
                {
                    Random random = new Random();
                    var UserDick = UsersParse.Parse(userString);
                    var ProxyDict = ProxyParse.Parse(Proxy[random.Next(0, Proxy.Length)]);
                    users.Add(new HTTPBrowser()
                    {
                        UserName = UserDick["username"],
                        Password = UserDick["password"],
                        ProxyUserName = ProxyDict["username"],
                        ProxyPassword = ProxyDict["password"],
                        ip = ProxyDict["ip"],
                        port = Int32.Parse(ProxyDict["port"]),
                        mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"])

                    });
                    

                }
                else
                {
                    Random random = new Random();
                    var UserDick = UsersParse.Parse(userString);
                    var ProxyDict = ProxyParse.Parse(Proxy[random.Next(0, Proxy.Length)]);
                    Mail mail;
                    try
                    {
                        mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"]);
                    } catch (Exception ex)
                    {
                        mail = null;
                    }
                    users.Add(new HTTPAndroid()
                    {
                        UserName = UserDick["username"],
                        Password = UserDick["password"],
                        ProxyUserName = ProxyDict["username"],
                        ProxyPassword = ProxyDict["password"],
                        ip = ProxyDict["ip"],
                        port = Int32.Parse(ProxyDict["port"]),
                        mail = mail

                    });


                    
                }

            }


            for (var i = 0; i<users.Count;i++)
            {
                



                workers.Add(new BackgroundWorker());
                workers[i].DoWork += new DoWorkEventHandler( InstagramTest_DoWork);
                //  workers[i].RunWorkerCompleted += InstagramTest_RunWorkerCompleted;
                workers[i].WorkerReportsProgress = true;
                workers[i].ProgressChanged += new ProgressChangedEventHandler( bgw_ProgressChanged);
                List<Object> list = new List<object>();

                
                workers[i].RunWorkerAsync(users[i]);
                    
                
            }






            //request = new HTTPBrowser();
            //Dictionary<string, string> parsed = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951");
            //request.Login("KalkisVienna", "PULUFLbxArbR", parsed["ip"], Int32.Parse(parsed["port"]), parsed["username"], parsed["password"]);
        }

        private void InstagramTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            //labelLog.Content = $"Залогинены: {sum}";
            
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
    
        }

       

        private async void InstagramTest_DoWork(object sender, DoWorkEventArgs e)
        {


         

            var user = (IInstagram)e.Argument;
         
            var Login_Result = await user.Login();


            if (Login_Result.Info.Message == "Challenge is required")
            {
                DateTime dt = DateTime.Now;
                BackgroundWorker bgw = sender as BackgroundWorker;
                var verres = await user.InstaApi.ChooseVerifyMethod(1);
                if (user.mail != null)
                {



                    var code = user.mail.GetMailText(dt);
                    var verify_result = await user.InstaApi.SendVerifyCode(code);

                    if (verify_result.Succeeded == true)
                    {
                        Login_Users.Add(user);

                        MessageBox.Show("Пользователь залогинен");



                    }
                }
                else
                {
                    
                    ScriptEngine engine = Python.CreateEngine();
                    ScriptScope scope = engine.CreateScope();
                    engine.ExecuteFile(Environment.CurrentDirectory+ @"\" + "UpdateNumber.py" , scope);
                    dynamic UpdateNumber = scope.GetVariable("UpdateNumber");

                }
                
            }

        }

        private async void Verify(object sender, RoutedEventArgs e)
        {
           // var result = await request.Verify(tbVerifyCode.Text);
           // MessageBox.Show($"Authorized: {result.Succeeded}\n{result.Info.Message}");
        }

        private async void Like_Click(object sender, RoutedEventArgs e)
        {
            var tmpLogin_Users = Login_Users;
            
            foreach (var user in tmpLogin_Users)
            {
                var media = await user.InstaApi.GetMediaIdFromUrlAsync(new Uri(tbLike.Text));
                await  user.InstaApi.LikeMediaAsync(media.Value);
            }



        }

        private async void Comment_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string[] Proxy = File.ReadAllLines(tbProxy.Text);
            var ProxyDict = ProxyParse.Parse(Proxy[random.Next(0, Proxy.Length)]);
            var user = new HTTPBrowser()
            {
                UserName = "LukyMyky",
                Password = "asxc30071981",
                ProxyUserName = ProxyDict["username"],
                ProxyPassword = ProxyDict["password"],
                ip = ProxyDict["ip"],
                port = Int32.Parse(ProxyDict["port"]),
                //mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"])

            };
            
          var res = await user.Login();
          var result =   await user.InstaApi.ChooseVerifyMethod(0);
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {

        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //_sit.com_ byflimix911

        //    // await api.SendVerifyCode("");




        //   // await api.LikeMediaAsync();

        //}

        //private async void  Button_Click_1(object sender, RoutedEventArgs e)
        //{



        //    List<IInstagram> users = new List<IInstagram>();

        //    users.Add(  new HTTPAndroid("KaramarAbby", "3KmjlFDF9NGV", "91.227.155.179", 7951, "17t3080724", "KJLDdrcde9"));
        //    foreach (var user in users)
        //    {


        //        Mail mail = new Mail("shaelynja8y@mail.ru", "i37CeW8x");
        //        var res = await user.Login();
        //        var api = user.InstaApi;


        //        DateTime dt = DateTime.Now;
        //        await api.ChooseVerifyMethod(1);
        //       // await api.ChooseVerifyMethod(1);

        //        string code = mail.GetMailText(dt);






        //        var res3 = await api.SendVerifyCode(code);
        //        if(res3.Succeeded == true)
        //        {
        //            var cookie = api.ResetChallenge();

        //            var media = await api.GetMediaIdFromUrlAsync(new Uri("https://www.instagram.com/p/Bml63cMHODq/"));
        //            var media_like = await api.LikeMediaAsync(media.Value);
        //            int i = 4;
        //        }
        //    }
    }
}

