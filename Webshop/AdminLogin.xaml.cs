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
using Webshop.Models;

namespace Webshop
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            // User inputted
            string inputUsername = InputUsername.Text;
            string inputPassword = InputPassword.Password;

            // From database
            int userId;
            string name;
            string username;
            string password;
            string salt;


            using (var db = new webshopContext())
            {
                // Select in users where Username = inputUsername
                try
                {
                    // Single method will only find one row, in any other case, an exception is thrown
                    var user = db.Users.Single(u => u.Username == inputUsername);

                    userId = user.UserId;
                    name = user.Name;
                    username = user.Username;
                    password = user.Password;
                    salt = user.Salt;
                    

                } catch(Exception)
                {
                    TextError.Text = "Fel inloggningsuppgifter";
                    return;
                }
            }

            // Password check
            if (!password.Equals(Hash.CreateMd5(inputPassword + salt)))
            {
                TextError.Text = "Fel inloggningsuppgifter";
                return;
            }

            // Set current logged in user to admin
            Admin.getInstance().setUser(userId);

            AdminHome ah = new AdminHome();
            ah.Show();
            this.Close();
        }
    }
}
