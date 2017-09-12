using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

namespace withoutMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public string customerName, customerAddress;

        public bool isVip { get; set; }
        
            
            
        
        public MainWindow()
        {
            InitializeComponent();
            UpdateMasterGrid();
            
        }


#region обновления гридов
        //метод выкачивания свежей бд по заказам
        public void UpdateDetailGrid()
        {
            if (GetCurrentName() == null)
            {
                UpdateMasterGrid();
                MessageBox.Show("Master table updated");
            }
            else {
                try
                {
                    string query = "select Number,Description from detail join master on master.id=detail.id " +
                              "where master.Name = '" + GetCurrentName() + "'";
                    string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";

                    MySqlConnection connection = new MySqlConnection(connectionString);
                    MySqlCommand addCmd = new MySqlCommand(query, connection);

                    connection.Open();
                    DataTable dt = new DataTable("detail");
                    MySqlDataAdapter da = new MySqlDataAdapter(addCmd);

                    da.Fill(dt);
                    detailGrid.ItemsSource = dt.DefaultView;
                    da.Update(dt);
                    connection.Close();

                    detailGrid.DataContext = dt;
                    MessageBox.Show("Update successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed");
                }
            }

            /*string query = "select Number,Description from detail;";
            string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, connection);

            connection.Open();
            DataTable dt = new DataTable("detail");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            detailGrid.ItemsSource = dt.DefaultView;
            da.Update(dt);
            connection.Close();

            detailGrid.DataContext = dt;*/
        }

        //метод выкачивания свежей бд по клиентам
        public void UpdateMasterGrid()
        {
            
            string query = "select Name,Address,VIP from master;";
            string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, connection);

            connection.Open();
            DataTable dt = new DataTable("master");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);
            masterGrid.ItemsSource = dt.DefaultView;
            da.Update(dt);
            connection.Close();

            masterGrid.DataContext = dt;
            
            
        }
        #endregion
#region Методы определения нажатого имени и проверки клиентов на VIP статус
        //метод для определения кликнутого имени для вывода определенного списка заказов
        public string GetCurrentName()
        {
            string currentName = null;

            foreach(DataRowView row in masterGrid.SelectedItems)
            {
                currentName = row.Row.ItemArray[0].ToString();

            }
            return currentName;
        }

        //метод для проверки на VIP статус и перекрашивание строчек
       /* public bool ClientVIP()
        {
            bool vip = false;
            string vipString = string.Empty;
            int indexOfColumn = 3;
            
            foreach (DataGridRow row in masterGrid)
        }*/

#endregion
#region Обработчики кнопок
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetCurrentName() == null)
            {
                MessageBox.Show("Choose client fisrt");
            }
            else
            {
                AddOrderInfo orderInfo = new AddOrderInfo();
                orderInfo.Show();
            }
        }

        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteClientDialog delCli = new DeleteClientDialog();
            delCli.Show();
        }

        private void UpdateTableButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDetailGrid();
            UpdateMasterGrid();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            InsertClientInfo cliInfo = new InsertClientInfo();
            cliInfo.Show();

        }


        //обработчик нажатия на имя клиента
        private void masterGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string query = "select Number,Description from detail join master on master.id=detail.id " +
                            "where master.Name = '" + GetCurrentName()+ "'";
            string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand addCmd = new MySqlCommand(query, connection);

            connection.Open();
            DataTable dt = new DataTable("detail");
            MySqlDataAdapter da = new MySqlDataAdapter(addCmd);

            da.Fill(dt);
            detailGrid.ItemsSource = dt.DefaultView;
            da.Update(dt);
            connection.Close();

            detailGrid.DataContext = dt;
            
            
        }
#endregion

    }
}
