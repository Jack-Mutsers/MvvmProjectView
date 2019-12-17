using MVVMProjectView.Connection;
using MVVMProjectView.Models;
using MVVMProjectView.Resources;
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

namespace MVVMProjectView.Views
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        private string password { get; set;}
        private string repassword { get; set;}
        ApiConnector connector = new ApiConnector();
        User user;

        public Profile()
        {
            InitializeComponent();
            lblError.DataContext = StaticResources.resources;
            lblMessage.DataContext = StaticResources.resources;
            DelError.DataContext = StaticResources.resources;
            user = StaticResources.UserData;
        }

        private void onPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { password = ((PasswordBox)sender).Password; }
        }

        private void RePasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { repassword = ((PasswordBox)sender).Password; }
        }


        private void Update_Password_Click(object sender, RoutedEventArgs e)
        {
            UpdatePassword();
        }

        private void Update_Password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;
            UpdatePassword();
        }

        private void UpdatePassword()
        {
            connector.ExtendLoginTime(); 
            Keyboard.ClearFocus();
            if (password == repassword && !string.IsNullOrEmpty(password))
            {
                user.password = StaticResources.Encryptor(password);
                if(connector.UpdateUser(user)){
                    tbPassword.Password = "";
                    tbPasswordConf.Password = "";

                    StaticResources.resources.UpdateError = "";
                    StaticResources.resources.UpdateMessage = "Password had been updated";
                }
            }
            else
            {
                StaticResources.resources.UpdateMessage = "";

                if (string.IsNullOrEmpty(password))
                {
                    StaticResources.resources.UpdateError = "A password needs to be set!";
                }
                else if (password != repassword)
                {
                    StaticResources.resources.UpdateError = "Passwords do not match!";
                }
            }
        }

        private void Delete_Account_Click(object sender, RoutedEventArgs e)
        {
            if (connector.DeleteUser())
            {
                StaticResources.resources.DeleteMessage = "User has been deleted";
                StaticResources.resources.DeleteError = "";
            }
            else
            {
                StaticResources.resources.DeleteError = "Something went wrong during the delete action";
            }
        }
    }
}
