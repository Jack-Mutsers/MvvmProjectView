using MVVMProjectView.ViewModels;
using MVVMProjectView.Resources;
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

namespace MVVMProjectView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApiConnector connection = new ApiConnector();

        public MainWindow()
        {
            InitializeComponent();
            StaticResources.mainWindow = this;
            DataContext = new LoginViewModel();
            menu.DataContext = StaticResources.resources;
        }

        private void StatusView_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new StatusViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void CategorieView_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new CategoryViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void ComponentView_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new ComponentsViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void NewCategorie_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new NewCategoryViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void NewComponent_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new NewComponentsViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void NewUserView_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new NewUserViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void ProfileView_Clicked(object sender, MouseButtonEventArgs e)
            {
            if (StaticResources.resources.LoggedIn)
            {
                DataContext = new ProfileViewModel();
                connection.ExtendLoginTime();
            }
        }

        private void Logout_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (StaticResources.resources.LoggedIn)
            {
            }
        }

    }
}
