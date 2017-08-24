using MySql.Data.MySqlClient;
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

namespace withoutMVVM
{
    /// <summary>
    /// Interaction logic for AddOrderInfo.xaml
    /// </summary>
    public partial class AddOrderInfo : Window
    {
        public AddOrderInfo()
        {
            InitializeComponent();
        }

        //Получаем последний номер заказа клиента
        //ArgumentException - по какой-то причине нужный столбец не находится (его индекс - 1, так как индекс id - 0)
        private int GetLastOrderNumber()
        {
            int number = 0;

            string connectionString = "server=localhost;user=root;database=logrocon;password=0000;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();
            string query = "select max(Number) from detail";
            MySqlCommand cmd = new MySqlCommand(query,connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                number = dr.GetInt32(1);
            }
            connection.Close();
            return number;

        }
        //Получаем информацию о заказах клиента
        //Из-за желания присвоить несколько заказов одному клиенту были созданы таблицы
        //отдельно для клиента и отдельно для заказов(соответствено джойнились они через id-клиента), однако
        //при создании нового заказа с тем же Id возникает ошибка дублирования первичного ключа,
        //которая делает этот метод абсолютно бесполезным
        private int GetClientsOrders()
        {
            MainWindow obj = new MainWindow();
            string query = "select count(*) from detail join master on master.id=detail.id " +
                            "where master.Name = '" + obj.GetCurrentName() + "'";
            string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            int amountOfRows = Convert.ToInt32(cmd.ExecuteScalar());
            
            return amountOfRows;
        }

        //Так как присвоить несколько заказов клиенту на основании одного id не получается, придется дать уникальный 
        //номер каждому заказу базы, вместо каждого заказа клиента
        private void SetNewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string description = OrderDescription.Text.ToString();
            int number = GetLastOrderNumber() + 1;
            
            string connectionString = "server=localhost;port=3306;username=root;password=0000;";
            string query = "insert into logrocon.detail (Number,Description) " +
                            "values ('" + number + "','" + OrderDescription.Text + "')";
            
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand addCmd = new MySqlCommand(query, connection);

            
            connection.Close();

        }

        private void CancelNewOrder_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
