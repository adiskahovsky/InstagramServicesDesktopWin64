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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LikeProg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private List<string> GetSmsOnlineCountries()
        {
            List<string> tags = new List<string>();
            var children = LogicalTreeHelper.GetChildren(smsOnline_StackPanel);

            foreach (var box in children)
            {
                var chkBox = box as CheckBox;
                if (chkBox.IsEnabled == true)                
                    tags.Add(chkBox.Tag.ToString());                
            }

            return tags;
        }

        private void ScrollBar_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }
    }
}
