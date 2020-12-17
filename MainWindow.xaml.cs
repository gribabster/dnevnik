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
using static System.Console;
using static System.Convert;
using System.Collections;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace dnevnik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Вывод данных
            string table = "student_tabl"; //Имя таблицы
            string table2 = "tema_tabl2";
            string ssql = $"SELECT * FROM {table} "; //Запрос 
            string ssql2 = $"SELECT * FROM {table2} ";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnev;Integrated Security=True"; //prak - имя базы данных(Поменять на свою)
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к Базе данных
            conn.Open();// Открытие Соединения
            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            
            SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса вывод информации
            

            SqlConnection conn2 = new SqlConnection(connectionString); // Подключение к Базе данных
            conn2.Open();// Открытие Соединения
            SqlCommand command2 = new SqlCommand(ssql2, conn2);// Объект вывода запросов

            SqlDataReader reader2 = command2.ExecuteReader();

            lfio.Items.Clear();
            lgroup.Items.Clear();
            ldata.Items.Clear();
            ltema.Items.Clear();
            losenka.Items.Clear();
            while (reader.Read() && reader2.Read()) //В цикле вывести всю информацию из таблицы
            {
                
                lfio.Items.Add(reader[0]);
                lgroup.Items.Add(reader[1]);
                ldata.Items.Add(reader2[1]);
                ltema.Items.Add(reader2[2]);
                losenka.Items.Add(reader2[3]);
            }
            
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window Edit_Window = new Window1();
            Edit_Window.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//Удаление
        {
            
                string data = ldata.ToString();
                string ssql = $"DELETE FROM tema_tabl2 WHERE data_zanyati = '{data}'"; //Запрос
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnev;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString); // Подключение к Базе данных
                conn.Open();// Открытие Соединения

                SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
                SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса и вывод информации

            
                ldata.Items.Clear();
                ltema.Items.Clear();
                losenka.Items.Clear();
                while (reader.Read()) //В цикле вывести всю информацию из таблицы
                {
                ldata.Items.Add(reader[1]);
                ltema.Items.Add(reader[2]);
                losenka.Items.Add(reader[3]);
                }

            reader.Close();
                MessageBox.Show("Изменения применены!");
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//Вызов для изменений
        {
            Window Edit_Window = new Window1();
            Edit_Window.Show();
        }
    }

}
