using PractosNumber1.SHOPDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PageForCreateToy.xaml
    /// </summary>
    public partial class PageForCreateToy : Page
    {
        private ToysTableAdapter toys = new ToysTableAdapter();
        private int b;
        public PageForCreateToy()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            Category_ComboBox.ItemsSource = null;
            CategoriesTableAdapter categori = new CategoriesTableAdapter();
            Category_ComboBox.ItemsSource = categori.GetData();
            Category_ComboBox.DisplayMemberPath = "CategoryName";
            Category_ComboBox.SelectedValuePath = "CategoryID";
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            CreateNewRow();
            Close();
        }
        private void CreateNewRow()
        {
            toys.GetData();
            int a = toys.GetData().Count;
            toys.InsertQuery(a + 1, b, ToyName_TextBox.Text, Convert.ToInt32(ToyPrice_TextBox.Text));
            MainWindow.toys.Start();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+"); // регулярное выражение для проверки вводимых данных
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Close()
        {
            MainWindow.ClosePage();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Category_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Category_ComboBox.SelectedIndex != -1)
            {
                b = (int)Category_ComboBox.SelectedValue;
            }
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            toys.GetData();
            toys.UpdateQuery(b, ToyName_TextBox.Text, Convert.ToDecimal(ToyPrice_TextBox.Text),
                MainWindow.ID);
            MainWindow.toys.Start();
        }
    }
}
