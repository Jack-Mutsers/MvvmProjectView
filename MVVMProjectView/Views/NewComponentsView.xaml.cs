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
            default_statup();

            StaticResources.resources.deleteButtonVisibility = Visibility.Hidden;
            StaticResources.resources.newComponentHeader = "Add new component";
            StaticResources.resources.updateCreateName = "Create";
        }
        
        public NewComponentsView(Component comp)
        {
            default_statup();
            StaticResources.resources.component = comp;
            StaticResources.resources.deleteButtonVisibility = Visibility.Visible;

            StaticResources.resources.newComponentHeader = "Update component";
            StaticResources.resources.updateCreateName = "Update";

            Category selected = CategoryList.Find(cat => cat.id == comp.categoryid);
            cbCategory.SelectedIndex = CategoryList.FindIndex(cat => cat.id == selected.id);
        }

        private void default_statup()
        {
            InitializeComponent();
            UpdateContent();
            tbNewComp.DataContext = StaticResources.resources;
            tbNewCompIp.DataContext = StaticResources.resources;
            CompError.DataContext = StaticResources.resources;
            CompMessage.DataContext = StaticResources.resources;
            lblTitle.DataContext = StaticResources.resources;
            btnSet.DataContext = StaticResources.resources;
            btnDel.DataContext = StaticResources.resources;
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

            StaticResources.resources.component.categoryid = cat.id;

            bool succes = false;
            if (StaticResources.resources.component.id > 0)
            {
                succes = connector.UpdateComponent(StaticResources.resources.component);
                if (succes)
                {
                    StaticResources.resources.NewCompError = "";
                    StaticResources.resources.NewCompMessage = "Component has been succesfully updated";
                    StaticResources.resources.component = new Component();
                    StaticResources.mainWindow.DataContext = new StatusView();
                }
                else
                {
                    StaticResources.resources.NewCompMessage = "";
                    StaticResources.resources.NewCompError = "An error occured, Component has not been updated";
                }
            }
            else
            {
                succes = connector.NewComponent(StaticResources.resources.component);
                if (succes)
                {
                    StaticResources.resources.NewCompError = "";
                    StaticResources.resources.NewCompMessage = "Component has been succesfully added";
                    StaticResources.resources.component = new Component();
                }
                else
                {
                    StaticResources.resources.NewCompMessage = "";
                    StaticResources.resources.NewCompError = "An error occured, Component has not been added";
                }
            }

            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (connector.DeleteComponent(StaticResources.resources.component))
            {
                StaticResources.mainWindow.DataContext = new StatusView();
            }
        }
    }
}
