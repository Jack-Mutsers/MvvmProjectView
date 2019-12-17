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
                    MessageBox.Show("user has been created", "creation status: succesfull", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("an error occured while trying to create a new user", "creation status: failure", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                string useless = ex.ToString();
                MessageBox.Show("an error occured while trying to create a new user", "creation status: failure", MessageBoxButton.OK);
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
