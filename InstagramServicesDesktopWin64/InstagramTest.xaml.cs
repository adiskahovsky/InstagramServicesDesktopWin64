using System;
using System.Collections.Generic;
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
using SmsLibrary;

namespace InstagramServicesDesktopWin64
{
    /// <summary>
    /// Логика взаимодействия для InstagramTest.xaml
    /// </summary>
    public partial class InstagramTest : Window
    {
        List<IInstagram> users;
        SmsOnline sms;
        public InstagramTest()
        {
            users = new List<IInstagram>();
            InitializeComponent();
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            if (rbBrowser.IsChecked == true)
            {
                users.Add(new HTTPBrowser()
                {
                    UserName = "KajigisMarlowe",
                    Password = "ayOaKoTc336Q",
                    ProxyDictionary = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951")
                });
            }
            var result = await users[0].Login();


            sms = new SmsOnline();
            string number = sms.GetNumber(new List<string>() { "24", "68" });

            //changeNumber request

        }

        private async void Like_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void Comment_Click(object sender, RoutedEventArgs e)
        {
            //CheapSms sms = new CheapSms() { Proxy = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951") };
            //if (sms.GetNumberCount() > 0)
            //{
            //    string number = sms.GetNumber();
            //}


            users.Add(new HTTPBrowser()
            {
                UserName = "KajigisMarlowe",
                Password = "ayOaKoTc336Q",
                ProxyDictionary = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951")
            });

            sms = new SmsOnline() { Proxy = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951") };
            string number = sms.GetNumber(new List<string>() { "24", "68" });

            await users[0].Login();
            
        }

        private async void Subscribe_Click(object sender, RoutedEventArgs e)
        {

            //var result = await users[0].Verify(sms.GetSms());
        }

        private void RequestSms(object sender, RoutedEventArgs e)
        {
            SmsOnline sms = new SmsOnline();

            string number = sms.GetNumber(new List<string>());
        }
    }
}

