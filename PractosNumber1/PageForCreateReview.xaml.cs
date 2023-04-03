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
    /// Логика взаимодействия для PageForCreateReview.xaml
    /// </summary>
    public partial class PageForCreateReview : Page
    {
        private static ReviewsTableAdapter reviews = new ReviewsTableAdapter();
        private int b;
        public PageForCreateReview()
        {
            InitializeComponent();
            Start();
        }

        private void CreateBTN_Click(object sender, RoutedEventArgs e)
        {
            CreateNewRow();
            Close();
        }

        public void Start()
        {
            Toy_ComboBox.ItemsSource = null;
            ToysTableAdapter toy = new ToysTableAdapter();
            Toy_ComboBox.ItemsSource = toy.GetData();
            Toy_ComboBox.DisplayMemberPath = "ToyName";
            Toy_ComboBox.SelectedValuePath = "ToyID";
        }

        private void Close()
        {
            MainWindow.ClosePage();
        }

        private void CreateNewRow()
        {
            reviews.GetData();
            int a = reviews.GetData().Count;
            reviews.InsertQuery(a + 1, b, UserName_TextBox.Text,
                Convert.ToInt32(Rating_TextBox.Text), Review_TextBox.Text);
            MainWindow.reviews.Start();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex($"[^1-5]+"); // регулярное выражение для проверки вводимых данных
            e.Handled = regex.IsMatch(e.Text);
            if (!e.Handled)
            {
                var text = ((TextBox)sender).Text.Insert(((TextBox)sender).CaretIndex, e.Text);
                var count = text.Count();
                if (count > 1)
                {
                    e.Handled = true;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Toy_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Toy_ComboBox.SelectedIndex != -1)
            {
                b = (int)Toy_ComboBox.SelectedValue;
            }
        }

        private void UpdateBTN_Click(object sender, RoutedEventArgs e)
        {
            reviews.GetData();
            reviews.UpdateQuery(b, UserName_TextBox.Text, Convert.ToInt32(Rating_TextBox.Text), Review_TextBox.Text,
                MainWindow.ID);
            MainWindow.reviews.Start();
        }
    }
}
