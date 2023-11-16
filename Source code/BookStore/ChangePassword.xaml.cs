using BookStore.View;
using MahApps.Metro.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChangePassword : MetroWindow
    {
        public static SqlConnection _connection = MainWindow._connection;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void productOKButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (isValidated())
            {
                string sql =
                "Update Account set password = @new_password, entropy = @entropy where username = @username";

                string encodedSalt, encodedKey;

                using (var deriveBytes = new Rfc2898DeriveBytes(newPassword.Password, 20)) // 20-byte salt
                {
                    byte[] salt = deriveBytes.Salt;
                    byte[] key = deriveBytes.GetBytes(20); // 20-byte key

                    encodedSalt = Convert.ToBase64String(salt);
                    encodedKey = Convert.ToBase64String(key);

                    // store encodedSalt and encodedKey in database
                    // you could optionally skip the encoding and store the byte arrays directly
                }
                Properties.Settings.Default.RememberMe = "0";
                Properties.Settings.Default.Save();

                var command = new SqlCommand(sql, MainWindow._connection);

                command.Parameters.Add("@new_password", SqlDbType.NVarChar).Value = encodedKey;
                command.Parameters.Add("@entropy", SqlDbType.NVarChar).Value = encodedSalt;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = currentUsername.Text;        
                command.ExecuteNonQuery();
                DialogResult = true;
            }
        
        }

        private bool isValidated()
        {
            if(newPassword.Password != confirmPassword.Password)
            {
                return false;
            }
            if (newPassword.Password == "")
                return false;
            if (confirmPassword.Password == "")
                return false;
            return true;
        }

        private Boolean checkPassword(string username)
        {
            string sql =
                "select password,entropy from ACCOUNT where username = @username";

            var command = new SqlCommand(sql, MainWindow._connection);
            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;

            var reader = command.ExecuteReader();

            string password = oldPassword.Password;
            bool flag = false;
            while (reader.Read())
            {

                string encodedSalt = (string)reader["entropy"];
                string encodedKey = (string)reader["password"];

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

        private void authenButton_Click(object sender, RoutedEventArgs e)
        {
            string oldPass = oldPassword.Password;
            if (currentUsername.Text != "" && oldPass != "")
            {

                if (checkPassword(currentUsername.Text))
                {
                    currentUsername.IsEnabled = false;
                    oldPassword.IsEnabled = false;

                    newPassword.IsEnabled = true;
                    confirmPassword.IsEnabled = true;
                    OKButton.IsEnabled = true;
                }
            }
        }

        private void changePasswordLoaded(object sender, RoutedEventArgs e)
        {
            currentUsername.Text = MainWindow.username;
            currentUsername.IsEnabled = false;
            newPassword.IsEnabled = false;
            confirmPassword.IsEnabled = false;
            OKButton.IsEnabled = false;
        }
    }
}
