using PractosNumber1.SHOPDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Логика взаимодействия для Category.xaml
    /// </summary>
    public partial class Category : Page
    {
        private CategoriesTableAdapter categories = new CategoriesTableAdapter();

        public Category()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            CategoryDataGrid.ItemsSource = null;
            CategoryDataGrid.ItemsSource = categories.GetData();
            CategoryDataGrid.SelectedValuePath = "CategoryID";
        }
    }
}
