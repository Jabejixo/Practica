using PractosNumber1.SHOPDataSetTableAdapters;
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

namespace PractosNumber1
{
    /// <summary>
    /// Логика взаимодействия для PageForCreateCategory.xaml
    /// </summary>
    public partial class PageForCreateCategory : Page
    {
        private CategoriesTableAdapter categories = new CategoriesTableAdapter();
        public PageForCreateCategory()
        {
            InitializeComponent();
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            CreateNewRow();
            Close();
        }


        private void Close()
        {
            MainWindow.ClosePage();
        }

        private void CreateNewRow()
        {
            categories.GetData();
            int a = categories.GetData().Count;
            categories.InsertQuery(a + 1, CategoryName_TextBox.Text, CategoryDescription_TextBox.Text);
            MainWindow.category.Start();

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            categories.GetData();
            categories.UpdateQuery(CategoryName_TextBox.Text, CategoryDescription_TextBox.Text,
                MainWindow.ID);
            MainWindow.category.Start();
        }
    }
}
