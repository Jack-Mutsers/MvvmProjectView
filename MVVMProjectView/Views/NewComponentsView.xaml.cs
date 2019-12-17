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
    /// Interaction logic for NewComponentsView.xaml
    /// </summary>
    public partial class NewComponentsView : UserControl
    {
        ApiConnector connector = new ApiConnector();
        List<Category> CategoryList;
        public NewComponentsView()
        {
            InitializeComponent();
            UpdateContent();
            tbNewComp.DataContext = StaticResources.resources;
            CompError.DataContext = StaticResources.resources;
            CompMessage.DataContext = StaticResources.resources;
        }

        private void UpdateContent()
        {
            int index = cbCategory.SelectedIndex;
            CategoryList = new List<Category>();

            if (GetDataContext())
            {
                cbCategory.ItemsSource = CategoryList;
                int selectedIndex = index >= 0 ? index : 0;
                cbCategory.SelectedIndex = selectedIndex;
            }
        }

        public bool GetDataContext()
        {
            try
            {
                CategoryList = connector.Get_categories();
                return true;
            }
            catch (Exception ex)
            {
                var exeption = ex;
                return false;
            }
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            AddNewComponent();
        }

        private void AddNewComponent()
        {
            int index = cbCategory.SelectedIndex;
            Category cat = CategoryList[index];

            if (connector.NewComponent(cat.id))
            {
                StaticResources.resources.NewCompError = "";
                StaticResources.resources.NewCompMessage = "Component has been succesfully added";
                StaticResources.resources.ComponentName = "";
            }
            else
            {
                StaticResources.resources.NewCompMessage = "";
                StaticResources.resources.NewCompError = "An error occured, Component has not been added";
            }
        }

    }
}
