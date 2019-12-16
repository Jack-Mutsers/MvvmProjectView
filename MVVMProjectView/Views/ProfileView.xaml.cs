using MVVMProjectView.Connection;
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


        public Profile()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
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
            if (password == repassword)
            {
                int testc = 1;
            }
        }

        private void Delete_Account_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
