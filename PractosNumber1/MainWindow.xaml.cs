using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PractosNumber1.SHOPDataSetTableAdapters;
using Wpf.Ui.Controls;

namespace PractosNumber1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public static Category category = new Category();
        public static Toys toys = new Toys();
        public static Reviews reviews = new Reviews();
        public static int ID;
        CategoriesTableAdapter categories = new CategoriesTableAdapter();
        ToysTableAdapter toysTable = new ToysTableAdapter();
        ReviewsTableAdapter reviewsTable = new ReviewsTableAdapter();
        PageForCreateCategory _pageForCreateCategory = new PageForCreateCategory();
        PageForCreateReview _pageForCreateReview = new PageForCreateReview();
        PageForCreateToy _pageForCreateToy = new PageForCreateToy();


        public int dataBaseNumber;
        private static MainWindow win;

        public MainWindow()
        {
            InitializeComponent();
            MainWindow window = this;
            win = window;
        }

        private void CategoryPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = category;
            dataBaseNumber = 1;
            IsVisible(true);
        }

        private void ToysPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = toys;
            dataBaseNumber = 2;
            IsVisible(true);
        }

        private void ReviewsPage_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = reviews;
            dataBaseNumber = 3;
            IsVisible(true);
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = null;
            dataBaseNumber = 0;
            IsVisible(false);
        }

        private void CreateWinOpenBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (dataBaseNumber)
            {
                case 1:
                    FramePage.Content = _pageForCreateCategory;
                    Animation();
                    break;
                case 2:
                    FramePage.Content = _pageForCreateToy;
                    Animation();
                    break;
                case 3:
                    FramePage.Content = _pageForCreateReview;
                    Animation();
                    break;
            }
        }

        public static void ClosePage()
        {
            win.CloseAnimation();
            win.UpdateData();
        }

        private void UpdateData()
        {
            category.Start();
            toys.Start();
            reviews.Start();
            _pageForCreateToy.Start();
            _pageForCreateReview.Start();
        }

        private void CloseAnimation()
        {
            var storyboard1 = (Storyboard)Resources["SlideAnimationRight"];
            storyboard1.Begin(Border);
        }

        private void DeleteRow_Click(object sender, RoutedEventArgs e)
        {
            int id;
            switch (dataBaseNumber)
            {
                case 1:
                    if (category.CategoryDataGrid.SelectedIndex != -1)
                    {
                        id = (int)category.CategoryDataGrid.SelectedValue;
                        categories.DeleteQuery(id);
                        UpdateData();
                    }
                    break;
                case 2:
                    if (toys.ToysDataGrid.SelectedIndex != -1)
                    {
                        id = (int)toys.ToysDataGrid.SelectedValue;
                        toysTable.DeleteQuery(id);
                        UpdateData();
                    }
                    break;
                case 3:
                    if (reviews.ReviewsDataGrid.SelectedIndex != -1)
                    {
                        id = (int)reviews.ReviewsDataGrid.SelectedValue;
                        reviewsTable.DeleteQuery(id);
                        UpdateData();
                    }
                    break;
            }
        }

        private void Animation()
        {
            Border.Visibility = Visibility.Visible;
            Border.RenderTransform = new TranslateTransform();
            var storyboard1 = (Storyboard)Resources["SlideAnimation"];
            storyboard1.Begin(Border);
        }

        private void UpdateRow_Click(object sender, RoutedEventArgs e)
        {
            switch (dataBaseNumber)
            {
                case 1:
                    if (category.CategoryDataGrid.SelectedItem != null)
                    {
                        ID = (int)category.CategoryDataGrid.SelectedValue;
                        DataRowView row = (DataRowView)category.CategoryDataGrid.SelectedItem;
                        FramePage.Content = _pageForCreateCategory;
                        _pageForCreateCategory.CategoryDescription_TextBox.Text = $"{(string)row["CategoryDescription"]}";
                        _pageForCreateCategory.CategoryName_TextBox.Text = $"{(string)row["CategoryName"]}";
                        Animation();
                    }
                    break;
                case 2:
                    if (toys.ToysDataGrid.SelectedItem != null)
                    {
                        ID = (int)toys.ToysDataGrid.SelectedValue;
                        DataRowView row = (DataRowView)toys.ToysDataGrid.SelectedItem;
                        FramePage.Content = _pageForCreateToy;
                        _pageForCreateToy.Category_ComboBox.Text = $"{(string)row["CategoryName"]}";
                        _pageForCreateToy.ToyName_TextBox.Text = $"{(string)row["ToyName"]}";
                        _pageForCreateToy.ToyPrice_TextBox.Text = $"{Convert.ToString(row["ToyPrice"])}";
                        Animation();
                    }
                    break;
                case 3:
                    if (reviews.ReviewsDataGrid.SelectedItem != null)
                    {
                        ID = (int)reviews.ReviewsDataGrid.SelectedValue;
                        DataRowView row = (DataRowView)reviews.ReviewsDataGrid.SelectedItem;
                        FramePage.Content = _pageForCreateReview;
                        _pageForCreateReview.Toy_ComboBox.Text = $"{(string)row["ToyName"]}";
                        _pageForCreateReview.UserName_TextBox.Text = $"{(string)row["UserName"]}";
                        _pageForCreateReview.Rating_TextBox.Text = $"{Convert.ToString(row["Rating"])}";
                        _pageForCreateReview.Review_TextBox.Text = $"{(string)row["ReviewText"]}";
                        Animation();
                    }
                    break;
            }
        }

        private void IsVisible(bool visible)
        {
            if (visible)
            {
                Main.Visibility = Visibility.Visible;
                CreateWinOpenBtn.Visibility = Visibility.Visible;
                DeleteRow.Visibility = Visibility.Visible;
                UpdateRow.Visibility = Visibility.Visible;
            }
            else
            {
                Main.Visibility = Visibility.Hidden;
                CreateWinOpenBtn.Visibility = Visibility.Hidden;
                DeleteRow.Visibility = Visibility.Hidden;
                UpdateRow.Visibility = Visibility.Hidden;
            }
        }
    }
}
