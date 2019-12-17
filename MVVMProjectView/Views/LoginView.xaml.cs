using MVVMProjectView.Connection;
using MVVMProjectView.Models;
using MVVMProjectView.Resources;
using MVVMProjectView.ViewModels;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        User user = new User();

        public LoginView()
        {
            InitializeComponent();
            DataContext = user;
            lblMessages.DataContext = StaticResources.resources;
            DelMessage.DataContext = StaticResources.resources;
            lblNotification.DataContext = StaticResources.resources;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).password = ((PasswordBox)sender).Password; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void pwBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;
            login();
        }

        private void login()
        {
            StaticResources.resources.DeleteMessage = "";
            StaticResources.resources.NoteMessage = "";
            try
            {
                bool succes = false;
                if (user.username != null && user.username.Length > 2 && user.password.Length > 4)
                {
                    ApiConnector connector = new ApiConnector();
                    succes = connector.Login(user.username, user.password);
                }

                if (succes)
                {
                    StaticResources.resources.LoggedIn = true;
                    StaticResources.mainWindow.DataContext = new StatusViewModel();
                }
                else
                {
                    StaticResources.resources.LoginMessage = "The wrong username or password has been entered, please try again";
                    string testc = StaticResources.resources.LoginMessage;
                    user.password = string.Empty;
                    pwBox.Password = string.Empty;
                }
            }
            catch (Exception ex)
            {
                var exeption = ex;
                StaticResources.resources.LoginMessage = "Something went wrong, please try again";
            }
        }
    }
}
