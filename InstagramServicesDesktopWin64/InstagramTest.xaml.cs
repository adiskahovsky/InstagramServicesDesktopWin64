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

            


            HTTPAndroid android = new HTTPAndroid("KajigisMarlowe", "ayOaKoTc336Q", "",123);
            var res=   await android.Login();
            var api = android.InstaApi;

            await api.ChooseVerifyMethod(1);
            await api.ChooseVerifyMethod(1);
            Mail mail = new Mail();
           string code =  mail.GetMailText();



            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
      
           
            var res3 =  await api.SendVerifyCode(code);
            var media = await  api.GetMediaIdFromUrlAsync(new Uri("https://www.instagram.com/p/Bml63cMHODq/"));
        }
    }
}
