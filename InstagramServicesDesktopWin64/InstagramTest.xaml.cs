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


namespace InstagramServicesDesktopWin64
{
    /// <summary>
    /// Логика взаимодействия для InstagramTest.xaml
    /// </summary>
    public partial class InstagramTest : Window
    {
        public InstagramTest()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //_sit.com_ byflimix911

            // await api.SendVerifyCode("");

           
            
          
           // await api.LikeMediaAsync();

        }

        private async void  Button_Click_1(object sender, RoutedEventArgs e)
        {



            List<IInstagram> users = new List<IInstagram>();

            users.Add(  new HTTPAndroid("KaramarAbby", "3KmjlFDF9NGV", "91.227.155.179", 7951, "17t3080724", "KJLDdrcde9"));
            foreach (var user in users)
            {


                Mail mail = new Mail("shaelynja8y@mail.ru", "i37CeW8x");
                var res = await user.Login();
                var api = user.InstaApi;


                DateTime dt = DateTime.Now;
                await api.ChooseVerifyMethod(1);
               // await api.ChooseVerifyMethod(1);
                
                string code = mail.GetMailText(dt);






                var res3 = await api.SendVerifyCode(code);
                var media = await api.GetMediaIdFromUrlAsync(new Uri("https://www.instagram.com/p/Bml63cMHODq/"));
                var media_like = await api.LikeMediaAsync(media.Value);
                int i = 4;
                
            }
        }
    }
}
