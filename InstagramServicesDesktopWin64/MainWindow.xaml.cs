using Instagram;
using IronPython.Hosting;
using LikeProg;
using LogLibrary;
using MailWorker;
using Microsoft.Scripting.Hosting;
using SettingsLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        List<BackgroundWorker> workers;
        List<IInstagram> users;
        List<IInstagram> Login_Users;
        private Color _color;
        LogIO.Logging logging = new LogIO.Logging(LogIO.WriteLog);

        public MainWindow()
        {
            InitializeComponent();
            logging += ShowLog;
            workers = new List<BackgroundWorker>();
            users = new List<IInstagram>();
            Login_Users = new List<IInstagram>();
            _grid = new ObservableCollection<ShowCollection>();
            dgMain.ItemsSource = _grid;
            _color = Colors.White;
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



        private void ShowLog(string tmp, Log log)
        {
            this.Dispatcher.Invoke(() => tbLogs.Text = tbLogs.Text + log + '\n');
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // var browser = new HTTPBrowser();
            //MessageBox.Show(await browser.LoginAsync());



            // HTTPAndroid android = new HTTPAndroid("_sit.com", "byflimix911", "178.124.152.84", 46854);






        }

        private void Open_Settings(object sender, RoutedEventArgs e)
        {


            SettingsWindow SettingsWindow = new SettingsWindow();
            SettingsWindow.Show();

        }

        private async void Start(object sender, RoutedEventArgs e)
        {

            string[] Proxy = File.ReadAllLines(tbProxy.Text);

            string[] UsersString = File.ReadAllLines(tbUsers.Text);


            foreach (var userString in UsersString)
            {




                if (rbBrowser.IsChecked == true)
                {
                    Random random = new Random();
                    var UserDick = UsersParse.Parse(userString);
                    var ProxyDict = ProxyParse.Parse(Proxy[random.Next(0, Proxy.Length)]);
                    logging.Invoke(LogIO.path, new Log { Date = DateTime.Now, UserName = UserDick["username"], Method = "Loggining", Message = "Авторизация с браузера" });
                    Mail mail;
                    logging.Invoke(LogIO.path, new Log { Date = DateTime.Now, UserName = UserDick["username"], Method = "Выделение потоков", Message = "Выделение потоков" });
                    try
                    {
                        mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"]);
                    }
                    catch (Exception ex)
                    {
                        mail = null;
                        logging.Invoke(LogIO.path, new Log { Date = DateTime.Now, UserName = UserDick["username"], Method = "Loggining", Message = Options.IsSafeAllLogsEnabled ? $"Error: {ex.Message}" : "Неудалось залогиниться на почту" });
                    }
                    users.Add(new HTTPBrowser()
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
                else
                {
                    Random random = new Random();
                    var UserDick = UsersParse.Parse(userString);
                    var ProxyDict = ProxyParse.Parse(Proxy[random.Next(0, Proxy.Length)]);
                    Mail mail;
                    logging.Invoke(LogIO.path, new Log { Date = DateTime.Now, UserName = UserDick["username"], Method = "Выделение потоков", Message = "Выделение потоков" });
                    try
                    {
                        mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"]);
                    }
                    catch (Exception ex)
                    {
                        mail = null;
                        logging.Invoke(LogIO.path, new Log { Date = DateTime.Now, UserName = UserDick["username"], Method = "Loggining", Message = Options.IsSafeAllLogsEnabled ? $"Error: {ex.Message}" : "Неудалось залогиниться на почту" });
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


            for (var i = 0; i < users.Count; i++)
            {




                workers.Add(new BackgroundWorker());
                workers[i].DoWork += new DoWorkEventHandler(InstagramTest_DoWork);
                //  workers[i].RunWorkerCompleted += InstagramTest_RunWorkerCompleted;
                workers[i].WorkerReportsProgress = true;
                workers[i].ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
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



        ObservableCollection<ShowCollection> _showCollections = new ObservableCollection<ShowCollection>();
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


                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Авторизация", Message = "Авторизация с помощmю почты" });
                    var code = user.mail.GetMailText(dt);
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Авторизация", Message = "Отправка кода" });
                    var verify_result = await user.InstaApi.SendVerifyCode(code);

                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Отправка кода", Message = !Options.IsSafeAllLogsEnabled ? "" : verify_result.Info.Message });
                    if (verify_result.Succeeded == true)
                    {
                        logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Отправка кода", Message = !Options.IsSafeAllLogsEnabled ? "Код отправлен успешно" : verify_result.Info.Message });
                        Login_Users.Add(user);
                        logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Авторизация", Message = !Options.IsSafeAllLogsEnabled ? "Пользователь авторизирован " : Login_Result.Info.Message });
                        //dgmain.itemssource = _showcollections;
                        _color = Colors.Blue;
                        Dispatcher.Invoke(() =>
                        {
                            _showCollections.Add(new ShowCollection() { Login = user.UserName });
                            this.dgMain.ItemsSource = _showCollections;

                        });
                        //_showcollections.add(new showcollection()
                        //{
                        //    login = user.username


                        //});

                        //Dispatcher.Invoke(() =>
                        //{
                        //    _showCollections.Add(new ShowCollection() { Login = user.UserName });
                        //    this.dgMain.ItemsSource = _showCollections;

                        //});
                        //_color = Colors.Blue;



                    }
                }
                else
                {





                    _color = Colors.Red;
                    Dispatcher.Invoke(() =>
                    {
                        _showCollections.Add(new ShowCollection() { Login = user.UserName });
                        this.dgMain.ItemsSource = _showCollections;

                    });
                }

            }

        }


        //private void dgMain_LoadingRow(object sender, DataGridRowEventArgs e)
        //{
        //    DataRowView item = e.Row.Item as DataRowView;
        //    DataRow row = item.Row;

        //    e.Row.Background = new SolidColorBrush(_color);
        //}


        private async void Like_Click(object sender, RoutedEventArgs e)
        {
            var tmpLogin_Users = Login_Users;

            foreach (var user in tmpLogin_Users)
            {

                var media = await user.InstaApi.GetMediaIdFromUrlAsync(new Uri(tbLike.Text));
                if (media.Succeeded == true)
                {
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Получение MediaId", Message = !Options.IsSafeAllLogsEnabled ? "MeiaId получен успешно" : media.Info.Message });
                }
                else
                {
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Получение MediaId", Message = !Options.IsSafeAllLogsEnabled ? "MeiaId не получен " : media.Info.Message });
                }
                var like_result = await user.InstaApi.LikeMediaAsync(media.Value);
                if (like_result.Succeeded == true)
                {
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Лайкинг", Message = !Options.IsSafeAllLogsEnabled ? "Лайк поставлен" : like_result.Info.Message });
                }
                else
                {
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Лайкинг", Message = !Options.IsSafeAllLogsEnabled ? "Лайк не поставлен поставлен" : like_result.Info.Message });
                }


            }



        }

        private async void Comment_Click(object sender, RoutedEventArgs e)
        {

            var tmpLogin_Users = Login_Users;

            foreach (var user in tmpLogin_Users)
            {
                var res = await user.CommentPost(tbComment.Text);
                if (res.Succeeded == true)
                {

                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Комментинг", Message = !Options.IsSafeAllLogsEnabled ? "коммент  поставлен поставлен" : res.Info.Message });
                }
                else
                {
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Комментинг", Message = !Options.IsSafeAllLogsEnabled ? "коммент не  поставлен поставлен" : res.Info.Message });

                }

            }


            //Random random = new Random();
            //string[] Proxy = File.ReadAllLines(tbProxy.Text);
            //var ProxyDict = ProxyParse.Parse(Proxy[random.Next(0, Proxy.Length)]);
            //var user = new HTTPBrowser()
            //{
            //    UserName = "LukyMyky",
            //    Password = "asxc30071981",
            //    ProxyUserName = ProxyDict["username"],
            //    ProxyPassword = ProxyDict["password"],
            //    ip = ProxyDict["ip"],
            //    port = Int32.Parse(ProxyDict["port"]),
            //    //mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"])

            //};

            //var res = await user.Login();
            //var result = await user.InstaApi.ChooseVerifyMethod(0);



        }

        private async void Subscribe_Click(object sender, RoutedEventArgs e)
        {


            var tmpLogin_Users = Login_Users;

            foreach (var user in tmpLogin_Users)
            {
                var res = await user.Subscribe(tbSubscribe.Text);
                if (res.Succeeded == true)
                {

                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Подписка", Message = !Options.IsSafeAllLogsEnabled ? "Подписка выполнена успешно" : res.Info.Message });
                }
                else
                {
                    logging.Invoke(LogIO.path, new Log() { Date = DateTime.Now, UserName = user.UserName, Method = "Подписка", Message = !Options.IsSafeAllLogsEnabled ? "Подписка  выполнена неуспешно" : res.Info.Message });

                }

            }


            // var user = new HTTPAndroid()
            // {
            //     UserName = "kiara_sharpey",
            //     Password = "3HkgTSkj",
            //     ProxyUserName = "17t3080724",
            //     ProxyPassword = "KJLDdrcde9",
            //     ip = "91.227.155.166",
            //     port = 7951
            //     //mail = new Mail(UserDick["maillogin"], UserDick["mailpassword"])

            // };
            // var login_res = await user.Login();
            // var reset = await user.InstaApi.ResetChallenge();
            // var link = $@"https://www.instagram.com/challenge/{reset.Value.UserId}/{reset.Value.NonceCode}/";



            // var request = (HttpWebRequest)WebRequest.Create(link);
            // var headers = new WebHeaderCollection();
            //// headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            // headers.Add("x-csrftoken",user.CsrfToken);
            // request.Headers = headers;
            // request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
            // var postData = "phone_number=+375296693206";

            // var data = Encoding.ASCII.GetBytes(postData);

            // request.Method = "POST";
            // request.ContentType = "application/x-www-form-urlencoded";
            // request.ContentLength = data.Length;

            // using (var stream = request.GetRequestStream())
            // {
            //     stream.Write(data, 0, data.Length);
            // }

            // var response = (HttpWebResponse)request.GetResponse();

            // var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            //HttpClient client = new HttpClient();

            //var values = new Dictionary<string, string>
            //{
            //   { "phone_number", "+375296693206" },
            //  // { "thing2", "world" }
            //};
            //var content = new FormUrlEncodedContent(values);
            //var headers = new WebHeaderCollection();
            //headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            //headers.Add("phone_number", "+375296693206");


            //var response = await client.PostAsync()

            //var responseString = await response.Content.ReadAsStringAsync();


            //ScriptEngine engine = Python.CreateEngine();
            //ScriptScope scope = engine.CreateScope();
            //int x = 11;
            //engine.ExecuteFile(Environment.CurrentDirectory+ "\\" + "request.py", scope);
            //dynamic function = scope.GetVariable("main");
            //// вызываем функцию и получаем результат
            //dynamic result = function(x);


            //HttpWebRequest request = WebRequest.Create(link) as HttpWebRequest;
            //request.Method = "POST";

            //var headers = new WebHeaderCollection();
            //headers.Add("x-csrftoken",user.CsrfToken);
            //headers.Add("phone_number","+375296693206");
            ////headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
            //request.Headers = headers;
            ////request.
            //var res = await request.GetResponseAsync()

            //var values = new Dictionary<string, string>
            //{
            //   { "phone_number", "+375296693206" }

            //};
            //Encoding.
            //var content = new FormUrlEncodedContent(values);
            //HttpClient client = new HttpClient();
            //var response = await client.PostAsync(link, content);

            //var responseString = await response.Content.ReadAsStringAsync();

            //var method = await user.InstaApi.ChooseVerifyMethod(0);
            // HttpWebRequest request = WebRequest.Create(link) as HttpWebRequest;
            // request.Method = "POST";
            // WebHeaderCollection args = new WebHeaderCollection();
            // args.Add("phone_number=+375296693206");
            // request.Headers = args;

            // var res = await request.GetResponseAsync();

            //using (var webClient = new WebClient())
            //{

            //    var pars = new NameValueCollection();
            //    pars.Add("phone_number", "+375296693206");

            //    var response = webClient.UploadValues(link,"POST", pars);
            //    string str = System.Text.Encoding.UTF8.GetString(response);

            //}

            //var key = "1111";
            // var request = WebRequest.Create(link);
            // request.ContentType = "application/json";
            //// request.Headers["Authorization"] = "Basic " + key;

            // request.Method = "POST";

            // using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            // {
            //     string json = "{\"phone_number\":\"+375296693206\"}";
            //     streamWriter.Write(json);
            // }


            // HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            // using (Stream responseStream = response.GetResponseStream())
            // {
            //     StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            //     Console.WriteLine(reader.ReadToEnd());
            // }


        }



        /*
        var tmpLogin_Users = Login_Users;

        foreach (var user in tmpLogin_Users)
        {
          var res =   user.Subscribe(LinkConverter.ConvertToInstaUserName(tbSubscribe.Text));

        }
        */

        //var user =new HTTPAndroid()
        //{
        //    UserName = UserDick["username"],
        //    Password = UserDick["password"],
        //    ProxyUserName = ProxyDict["username"],
        //    ProxyPassword = ProxyDict["password"],
        //    ip = ProxyDict["ip"],
        //    port = Int32.Parse(ProxyDict["port"]),
        //    mail = mail

        //}

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
