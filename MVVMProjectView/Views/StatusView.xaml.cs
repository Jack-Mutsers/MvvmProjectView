using MVVMProjectView.Resources;
using MVVMProjectView.Connection;
using MVVMProjectView.Models;
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
using System.Windows.Threading;

namespace MVVMProjectView.Views
{
    /// <summary>
    /// Interaction logic for StatusView.xaml
    /// </summary>
    public partial class StatusView : UserControl
    {
        DispatcherTimer refresher = new DispatcherTimer();
        ApiConnector connector = new ApiConnector();
        List<Category> CategorieList;
        List<Component> components = new List<Component>();
        List<string> sortingLst = new List<string>() { "open", "closed" };

        public StatusView()
        {
            var win = Application.Current.MainWindow;

            InitializeComponent();
            DataContext = this;
            cbStatus.ItemsSource = sortingLst;
            cbStatus.SelectedIndex = 0;

            UpdateContent();

            refresher.Interval = TimeSpan.FromMilliseconds(3000);
            refresher.Tick += timer_Tick;
            refresher.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private void UpdateContent()
        {
            int index = cbCategory.SelectedIndex;
            CategorieList = new List<Category>();

            if (GetDataContext())
            {
                components = new List<Component>(); ;
                cbCategory.ItemsSource = CategorieList;
                int selectedIndex = index >= 0 ? index : 0;
                cbCategory.SelectedIndex = selectedIndex;

                SetContent();
            }
        }

        private void SetContent()
        {
            int index = cbCategory.SelectedIndex;
            int statusIndex = cbStatus.SelectedIndex;

            if (CategorieList != null && CategorieList.Count > 0)
            {
                components = CategorieList[index].Components.ToList();

                if (statusIndex == 1)
                {
                    components = components.OrderBy(comp => comp.status).ThenBy(n => n.name).ToList();
                }
                else
                {
                    components = components.OrderByDescending(comp => comp.status).ToList();
                }

                lv.ItemsSource = components;
            }
        }

        public bool GetDataContext()
        {
            try
            {
                CategorieList = connector.Get_categories();
                return true;
            }
            catch (Exception ex)
            {

                var exeption = ex;
                return false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (components.Count != 0)
            {
                SetContent();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            UpdateContent();
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            StaticResources.mainWindow.DataContext = new NewComponentsView();
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            string identifier = (sender as Button).Tag.ToString();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            connector.ExtendLoginTime();
            string identifier = (sender as Button).Tag.ToString();
        }
    }
}
