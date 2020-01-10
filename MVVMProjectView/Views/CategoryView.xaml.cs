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
    /// Interaction logic for CategoryView.xaml
    /// </summary>
    public partial class CategoryView : UserControl
    {
        ApiConnector connector = new ApiConnector();
        List<Category> category = new List<Category>();

        public CategoryView()
        {
            InitializeComponent();

            GetCategories();
        }

        private void GetCategories()
        {
            connector.ExtendLoginTime();
            category = connector.Get_categories();
            lv.ItemsSource = category;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            string identifier = (sender as Button).Tag.ToString();

            if (connector.DeleteCategory(int.Parse(identifier)))
            {
                StaticResources.mainWindow.DataContext = new CategoryView();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            string identifier = (sender as Button).Tag.ToString();

            Category cat = category.Find(c => c.id == int.Parse(identifier));
            StaticResources.mainWindow.DataContext = new NewCategoryView(cat);
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            StaticResources.mainWindow.DataContext = new NewCategoryView();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetCategories();
        }
    }
}
