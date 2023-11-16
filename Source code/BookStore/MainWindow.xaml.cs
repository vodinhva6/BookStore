using BookStore.View;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore
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
        public static SqlConnection _connection;
        public static string username;
        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            // Lấy mã nguồn về cần làm 2 chuyện
            // 1. Chuẩn bị database và lấy username, password cần thiết.
            // 2. Xóa đi file config mặc định bởi vì nó lưu mật khẩu đã
            // // được mã hóa theo username trên máy thầy

            username = usernameTextBox.Text;
            string password = passwordBox.Password;

            var secret = new ConfigurationBuilder().AddUserSecrets<MainWindow>().Build();
            var connectionString = secret.GetSection("MyDB:ConnectionString").Value;
            connectionString = connectionString.Replace("@Catalog", "BookStore");
            _connection = new SqlConnection(connectionString);

            try
            {
                _connection.Open();
                //string temp_password = getPassword(username);

                if (checkPassword(username))
                {
                    if (rememberCheckBox.IsChecked == true)
                    {
                        // Lưu username và pass                     
                        //insert(username, passwordIn64, entropyIn64);                    
                        Properties.Settings.Default.Username = username;
                        Properties.Settings.Default.Password = password;
                        Properties.Settings.Default.RememberMe = "1";
                        Properties.Settings.Default.Save();
                    }

                    HomeWindow home = new HomeWindow();
                    home.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                    "Login Failed");
                }

                //if (rememberCheckBox.IsChecked == true)
                //{
                //    // Lưu username và pass
                //    var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(
                //        ConfigurationUserLevel.None);

                //    config.AppSettings.Settings["Password"].Value = password;
                //    //config.AppSettings.Settings["Entropy"].Value = entropyIn64;
                //    config.AppSettings.Settings["RememberMe"].Value = "1";
                //    using (var deriveBytes = new Rfc2898DeriveBytes(password, 20)) // 20-byte salt
                //    {
                //        byte[] salt = deriveBytes.Salt;
                //        byte[] key = deriveBytes.GetBytes(20); // 20-byte key

                //        string encodedSalt = Convert.ToBase64String(salt);
                //        string encodedKey = Convert.ToBase64String(key);

                //        // store encodedSalt and encodedKey in database
                //        // you could optionally skip the encoding and store the byte arrays directly
                //        insert(username, encodedKey, encodedSalt);

                //    }

                //    config.Save(ConfigurationSaveMode.Full);
                //    System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot connect to database. Reason: {ex.Message}");
            }
        }
        private void insert(string username, string password, string entropy)
        {
            string sql = "INSERT INTO ACCOUNT VALUES (@username, @password,@entropy)";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
            command.Parameters.Add("@entropy", SqlDbType.NVarChar).Value = entropy;

            command.ExecuteNonQuery();
        }

        private Boolean checkPassword(string username)
        {
            string sql =
                "select password,entropy from ACCOUNT where username = @username";

            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

            var reader = command.ExecuteReader();

            string password = passwordBox.Password;
            bool flag = false;
            while (reader.Read())
            {
                string encodedSalt = (string)reader["entropy"];
                string encodedKey = (string)reader["password"];

                // load encodedSalt and encodedKey from database for the given username
                byte[] salt = Convert.FromBase64String(encodedSalt);
                byte[] key = Convert.FromBase64String(encodedKey);

                using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
                {
                    byte[] testKey = deriveBytes.GetBytes(20); // 20-byte key
                    if (testKey.SequenceEqual(key))
                        flag = true;
                }             
            }
            reader.Close();
            return flag;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string rememberValue = Properties.Settings.Default.RememberMe;
             
            if (rememberValue.Equals("1"))
            {
                rememberCheckBox.IsChecked = true;
                string username = Properties.Settings.Default.Username;
                string passwordIn64 = Properties.Settings.Default.Password;
                //string entropyIn64 = System.Configuration.ConfigurationManager.AppSettings["Entropy"]!;

                if (passwordIn64.Length != 0)
                {
                    //byte[] entropyInBytes = Convert.FromBase64String(entropyIn64);
                    //byte[] cypherTextInBytes = Convert.FromBase64String(passwordIn64);

                    //byte[] passwordInBytes = ProtectedData.Unprotect(cypherTextInBytes,
                    //    entropyInBytes,
                    //    DataProtectionScope.LocalMachine
                    //);

                    //string password = Encoding.UTF8.GetString(passwordInBytes);

                    usernameTextBox.Text = username;
                    passwordBox.Password = passwordIn64;
                }
            }
            

        }

        private void RevenueProfitDashBoardWindow_Click(object sender, RoutedEventArgs e)
        {
            var p = new IncomeProfitDashBoard();
            p.Show();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void WindowStateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else Application.Current.MainWindow.WindowState = WindowState.Normal;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void rememberMe_Click(object sender, RoutedEventArgs e)
        {
            if (rememberCheckBox.IsChecked == false)
            {
                Properties.Settings.Default.RememberMe = "0";
                Properties.Settings.Default.Save();
            }
        }
    }
}

