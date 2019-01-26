using SettingsLibrary;
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
            Options.IsSmsWithoutProxyEnabled = (bool)cbSmsWithoutProxy.IsChecked;
            Options.SmsRequestDelay = updownRequestSmsDelay.Value;

            Options.IsCheapSms_UsingEnabled = (bool)cbActiveLicenseKey_CheapSms.IsChecked;
            Options.IsSimSms_UsingEnabled = (bool)cbActiveLicenseKey_SimSms.IsChecked;
            Options.IsSmsActivate_UsingEnabled = (bool)cbActiveLicenseKey_SmsActivate.IsChecked;
            Options.IsSmsOnline_UsingEnabled = (bool)cbActiveLicenseKey_SmsOnline.IsChecked;
            Options.IsVakSms_UsingEnabled = (bool)cbActiveLicenseKey_VakSms.IsChecked;

            if ((bool)cbActiveLicenseKey_CheapSms.IsChecked)
                Options.CheapSms_LicenseKey = tbLicenseKey_CheapSms?.Text;
            if ((bool)cbActiveLicenseKey_SimSms.IsChecked)
                Options.SimSms_LicenseKey = tbLicenseKey_CheapSms?.Text;
            if ((bool)cbActiveLicenseKey_SmsActivate.IsChecked)
                Options.SmsActivate_LicenseKey = tbLicenseKey_CheapSms?.Text;
            if ((bool)cbActiveLicenseKey_SmsOnline.IsChecked)
                Options.SmsOnline_LicenseKey = tbLicenseKey_CheapSms?.Text;
            if ((bool)cbActiveLicenseKey_VakSms.IsChecked)
                Options.VakSms_LicenseKey = tbLicenseKey_CheapSms?.Text;

            List<string> smsOnlineCountries = GetSmsOnlineCountries();
            List<string> simSmsCountries = GetSimSmsCountries();
            Options.SmsOnlineCountries = smsOnlineCountries;
            Options.SimSmsCountries = simSmsCountries;


            Dictionary<string, int> requestDelayForUnsub = new Dictionary<string, int>();
            requestDelayForUnsub.Add("from", numdownInstUnsub_RequestDelayFrom.Value);
            requestDelayForUnsub.Add("to", numdownInstUnsub_RequestDelayTO.Value);

            Options.InstUnsubDeleteCount = numdownInstUnsub_DeletedCount.Value;
            Options.InstUnsub_WorkDelay = requestDelayForUnsub;

            if ((bool)cbInstUnsubRandomSleep_WhileRequest.IsChecked)
            {
                Options.IsRandomUnsubDelay_InstLoginEnabled = (bool)cbInstUnsubRandomSleep_WhileRequest.IsChecked;
                Dictionary<string, int> requestCount = new Dictionary<string, int>();
                requestCount.Add("from", numdownInstUnsub_RequestCountFrom.Value);
                requestCount.Add("to", numdownInstUnsub_RequestCountTo.Value);
                Options.InstUnsub_RequestCount = requestCount;

                Dictionary<string, int> requestDelay_inMinutes = new Dictionary<string, int>();
                requestDelay_inMinutes.Add("from", numdownInstUnsub_DelayCountInMinutesFrom.Value);
                requestDelay_inMinutes.Add("to", numdownInstUnsub_DelayCountInMinutesTo.Value);
                Options.InstUnsub_RequestDelay_InMinutes = requestDelay_inMinutes;

                Options.InstUnsubLoadAccount_InMinutes = numdownInstUnsub_DelayLoginRequestInMinutes.Value;
            }
            else Options.IsRandomUnsubDelay_InstLoginEnabled = false;


            Options.IsSafeAllLogsEnabled = (bool)cbSaveAllLogs.IsChecked;
            Options.IsSafeTokenEnabled = (bool)cbSaveTokenToFiles.IsChecked;
            Options.IsNoShowLogEnabled = (bool)cbDisableLogShow.IsChecked;
            Options.IsDetailedLogEnabled = (bool)cbDetailedLog.IsChecked;
            Options.LoginAccountDelay_InSeconds = updownAccountLoginDelay.Value;

            Options.InstagramAuthorisationReinitCount = updownAutorizateTry.Value;
        }

        private void btnCancelSetingsChanges_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
>>>>>>> d6f5b8f... settings class
    }
}
