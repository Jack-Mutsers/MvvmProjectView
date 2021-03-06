﻿using Microsoft.Win32;
using MVVMProjectView.Connection;
using MVVMProjectView.Models;
using MVVMProjectView.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for NewCategoryView.xaml
    /// </summary>
    public partial class NewCategoryView : UserControl
    {
        ApiConnector connector = new ApiConnector();

        public NewCategoryView()
        {
            default_statup();
            StaticResources.resources.newCategoryHeader = "Add new category";
            StaticResources.resources.updateCreateName = "Create";
        }

        public NewCategoryView(Category cat)
        {
            default_statup();
            StaticResources.resources.category = cat;

            StaticResources.resources.newCategoryHeader = "Update category";
            StaticResources.resources.updateCreateName = "Update";

        }

        private void default_statup()
        {
            InitializeComponent();
            tbNewCat.DataContext = StaticResources.resources;
            CatError.DataContext = StaticResources.resources;
            CatMessage.DataContext = StaticResources.resources;
            imgIcon.DataContext = StaticResources.resources;
            lblTitle.DataContext = StaticResources.resources;
            btnSet.DataContext = StaticResources.resources;
        }

        private void Add_New_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            // your event handler here
            e.Handled = true;
            AddNewCategory();
        }

        private void Add_New_Click(object sender, RoutedEventArgs e)
        {
            AddNewCategory();
        }

        private void AddNewCategory()
        {
            bool succes;
            if (StaticResources.resources.category.id > 0)
            {
                succes = connector.UpdateCategory(StaticResources.resources.category);
                if (succes)
                {
                    StaticResources.resources.NewCatError = "";
                    StaticResources.resources.NewCatMessage = "Category has been succesfully updated";
                }
                else
                {
                    StaticResources.resources.NewCatMessage = "";
                    StaticResources.resources.NewCatError = "An error occured, Category has not been updated";
                }
            }
            else
            {
                succes = connector.NewCategory(StaticResources.resources.category);
                if (succes)
                {
                    StaticResources.resources.NewCatError = "";
                    StaticResources.resources.NewCatMessage = "Category has been succesfully added";
                    StaticResources.resources.category = new Category();
                    StaticResources.resources.ConvertedImage = null;
                }
                else
                {
                    StaticResources.resources.NewCatMessage = "";
                    StaticResources.resources.NewCatError = "An error occured, Category has not been added";
                }
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                StaticResources.resources.ConvertedImage = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
