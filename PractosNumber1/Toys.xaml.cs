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
using PractosNumber1.SHOPDataSetTableAdapters;

namespace PractosNumber1
{
    /// <summary>
    /// Логика взаимодействия для Toys.xaml
    /// </summary>
    public partial class Toys : Page
    {
        public Toys()
        {
            InitializeComponent();
            Start();
        }

        public void Start()
        {
            ToysDataGrid.ItemsSource = null;
            ToysDataGrid.ItemsSource = GetReviewsData().DefaultView;
            ToysDataGrid.SelectedValuePath = "ToyID";
        }

        private DataTable GetReviewsData()
        {
            // Определяем строку соединения с базой данных
            string connStr = @"Data Source=DESKTOP-03E8LU6;Initial Catalog=SHOP;Integrated Security=True";

            // Создаем объект соединения
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Создаем объект команды с запросом на выборку данных с соединением двух таблиц
                SqlCommand cmd = new SqlCommand("SELECT Toys.ToyName, Toys.ToyID, Categories.CategoryName, Toys.ToyPrice FROM Toys INNER JOIN Categories ON Toys.CategoryID = Categories.CategoryID", conn);
                // Создаем адаптер данных, используя команду
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                // Создаем объект таблицы данных
                DataTable table = new DataTable();
                // Заполняем таблицу данными из адаптера
                adapter.Fill(table);
                // Возвращаем таблицу данных
                return table;
            }
        }
    }
}
