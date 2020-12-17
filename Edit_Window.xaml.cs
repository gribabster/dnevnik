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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace dnevnik
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//Добавление данных
        {
            
            string fio = tbfio.Text;
            string group = tbgroup.Text;
            string data = tbdata.Text;
            string dataz = tbdataz.Text;
            string tema = tbtema.Text;
            int osenka = 0;
            if (tbosenka.Text != "")
            { 
               osenka = Convert.ToInt32(tbosenka.Text);
            }
            string ssql = $"INSERT INTO student_tabl  VALUES ( '{fio}','{group}','{data}')"; //Запрос вставить данные в таблицу Table_1 - имя таблици
            string ssql2 = $"INSERT INTO tema_tabl2 VALUES ( '{dataz}','{tema}','{osenka}')";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnev;Integrated Security=True"; //prak - имя базы данных(Поменять на свою)
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            int number = command.ExecuteNonQuery();
            
            SqlConnection conn2 = new SqlConnection(connectionString); // Подключение к БД
            conn2.Open();// Открытие Соединения
            SqlCommand command2 = new SqlCommand(ssql2, conn2);
            int number2 = command2.ExecuteNonQuery();
            
            MessageBox.Show("Данные добавлены!");
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string data = tbdataz.Text;
            string tema = tbtema.Text;
            string osenka = tbosenka.Text;
            
            string ssql = $"UPDATE tema_tabl2 SET tema = '{tema}', osenka = '{osenka}' WHERE data_zanyati = '{data}'"; //Запрос
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=dnev;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выаолнение запроса вывод информации
            reader.Close();
            
            MessageBox.Show("Данные изменены!");
        }
    }
}
