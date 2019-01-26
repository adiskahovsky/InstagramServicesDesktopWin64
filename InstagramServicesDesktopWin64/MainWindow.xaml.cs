using Instagram;
using LikeProg;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace InstagramServicesDesktopWin64
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ShowCollection> _grid;
        private Color _color;

        public MainWindow()
        {
            InitializeComponent();
<<<<<<< HEAD
        }        
=======
            _grid = new ObservableCollection<ShowCollection>();
            dgMain.ItemsSource = _grid;
            _color = Colors.White;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _grid.Add
                (
                new ShowCollection()
                {
                    Balance = "12",
                    Photo = "C;\\back",
                    Login = "Mishura",
                    LikesRecieved = "12"
                });
            _color = Colors.LightBlue;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _grid.Add
                (new ShowCollection()
                {
                    Login = "something"
                });
            _color = Colors.Red;
        }


        private void dgMain_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow item = e.Row as DataGridRow;
            var col = e.Row.Item as ShowCollection;
            if (item != null && col != null)
            {

                item.Background = new SolidColorBrush(_color);
                //DataRow row = item.Row;

            }
            else
                item.Background = new SolidColorBrush(Colors.White);
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable<DataGridRow>;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Show();
        }
>>>>>>> d6f5b8f... settings class
    }
}