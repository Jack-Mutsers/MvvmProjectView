using MVVMProjectView.Connection;
using MVVMProjectView.Models;
using System;
using MVVMProjectView.Resources;
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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : UserControl
    {
        User user = new User();

        public NewUser()
        {
            InitializeComponent();
            DataContext = user;
            UserError.DataContext = StaticResources.resources;
            UserMessage.DataContext = StaticResources.resources;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).password = ((PasswordBox)sender).Password; }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool succes = false;
                if (user.username != null && user.username.Length > 2 && user.password.Length > 4)
                {
                    ApiConnector connector = new ApiConnector();
                    user.password = StaticResources.Encryptor(user.password);
                    succes = connector.NewUser(user);
                }

                if (succes)
                {
                    StaticResources.resources.NewUserError = "";
                    StaticResources.resources.NewUserMessage = "user has been created";
                }
                else
                {
                    StaticResources.resources.NewUserMessage = "";
                    StaticResources.resources.NewUserError = "an error occured while trying to create a new user";
                }
            }
            catch (Exception ex)
            {
                string useless = ex.ToString();
                StaticResources.resources.NewUserMessage = "";
                StaticResources.resources.NewUserError = "an error occured while trying to create a new user";
            }
        }

        private void reset_values()
        {
            pwBox.Clear();
            tbBox.Clear();
            user = new User();
        }

    }
}
