using Instagram;
using System;
using System.Collections.Generic;
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

namespace InstagramServicesDesktopWin64
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        HTTPBrowser request;

        public TestWindow()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            request = new HTTPBrowser();
            Dictionary<string, string> parsed = ProxyParse.Parse("17t3080724:KJLDdrcde9@91.227.155.166:7951");
            request.Login("KalkisVienna", "PULUFLbxArbR", parsed["ip"], Int32.Parse(parsed["port"]), parsed["username"], parsed["password"]);
        }

        private async void Verify(object sender, RoutedEventArgs e)
        {
            var result = await request.Verify(tbVerifyCode.Text);
            MessageBox.Show($"Authorized: {result.Succeeded}\n{result.Info.Message}");
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
    }
}
