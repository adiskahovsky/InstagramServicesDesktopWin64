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
        public InstagramTest()
        {
            users = new List<IInstagram>();
            InitializeComponent();

            NumberChangeClass numberChanger = new NumberChangeClass();
            numberChanger.AddNewInstagramNumber("35522342", "KajigisMarlowe", "ayOaKoTc336Q");
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
            
            SmsOnline sms = new SmsOnline();
            string number = sms.GetNumber(new List<string>(), "91.227.155.166", 7951, "17t3080724", "KJLDdrcde9");

            NumberChangeClass numberChanger = new NumberChangeClass();
            numberChanger.AddNewInstagramNumber(number, "KajigisMarlowe", "ayOaKoTc336Q");
            
            await users[0].Verify(sms.GetSms());

            numberChanger.RemoveInstagramNumber();
            //request = new HTTPBrowser();
            //Dictionary<string, string> parsed = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951");
            //request.Login("KalkisVienna", "PULUFLbxArbR", parsed["ip"], Int32.Parse(parsed["port"]), parsed["username"], parsed["password"]);
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Comment_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RequestSms(object sender, RoutedEventArgs e)
        {
            SmsOnline sms = new SmsOnline();

            string number = sms.GetNumber(new List<string>(), "91.227.155.166", 7951, "17t3080724", "KJLDdrcde9");
        }
    }
}

