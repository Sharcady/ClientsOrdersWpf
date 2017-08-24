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
    /// Interaction logic for InsertClientInfo.xaml
    /// </summary>
    public partial class InsertClientInfo : Window
    {
        public long Id;
        
        public InsertClientInfo()
        {
            InitializeComponent();
            _GetLastId();
        }

        private long _GetLastId()
        {
            string connectionString = "server=localhost;user=root;database=logrocon;password=0000;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            
            connection.Open();
            string query = "select max(id) from master";
            MySqlCommand cmd = new MySqlCommand(query,connection);
            
            connection.Close();

            return Id = cmd.LastInsertedId;
          
        }

        

        private void SaveNewClient_Button_Click(object sender, RoutedEventArgs e)
        {
            string customerName = nameBox.Text.ToString();
            string customerAddress = addressBox.Text.ToString();
            
            Id += 1;
            //MySQL 
            string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";
            string query = "insert into master (id,Name,Address,VIP) " +
                            "values ('"+ Id + "','" + nameBox.Text + "','" + addressBox.Text + "','" + vip.IsChecked+"')";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand addCmd = new MySqlCommand(query, connection);

            /*addCmd.Parameters.AddWithValue("@Id", Id += 1);
            addCmd.Parameters.AddWithValue("@Name", nameBox.Text);
            addCmd.Parameters.AddWithValue("@Address", addressBox.Text);
            addCmd.Parameters.AddWithValue("@VIP", vip.IsChecked);
            */
          
            connection.Close();
            this.Close();
             
        }

        private void CloseCliInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
