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
    /// Interaction logic for DeleteClientDialog.xaml
    /// </summary>
    public partial class DeleteClientDialog : Window
    {
        public DeleteClientDialog()
        {
            InitializeComponent();
        }

        private void CancelDeletion_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void ConfirmCliDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow obj = new MainWindow();
                string query = "Delete * from master, detail join master on master.id=detail.id " +
                               "where master.Name = '" + obj.GetCurrentName() + "'";
                string connectionString = "server=localhost;database=logrocon;username=root;password=0000;";

                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();
                MySqlCommand addCmd = new MySqlCommand(query, connection);
                connection.Close();
                MessageBox.Show("Deletion succesful");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Deletion failed");
            }
        }
    }
}
