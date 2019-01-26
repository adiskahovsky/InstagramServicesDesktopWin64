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
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
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


        private List<string> GetSimSmsCountries()
        {
            List<string> tags = new List<string>();
            var children = LogicalTreeHelper.GetChildren(stackPanel_SimSms__1);

            foreach (var box in children)
            {
                var chkBox = box as CheckBox;
                if (chkBox.IsEnabled == true)
                    tags.Add(chkBox.Tag.ToString());
            }


            var children1 = LogicalTreeHelper.GetChildren(stackPanel_SimSms__1);

            foreach (var box in children1)
            {
                var chkBox = box as CheckBox;
                if (chkBox.IsEnabled == true)
                    tags.Add(chkBox.Tag.ToString());
            }


            var children2 = LogicalTreeHelper.GetChildren(stackPanel_SimSms__3);

            foreach (var box in children2)
            {
                var chkBox = box as CheckBox;
                if (chkBox.IsEnabled == true)
                    tags.Add(chkBox.Tag.ToString());
            }

            return tags;
        }

<<<<<<< HEAD
        private void ScrollBar_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }
=======
        private void btnSaveSetingsChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelSetingsChanges_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
>>>>>>> d6f5b8f... settings class
    }
}
