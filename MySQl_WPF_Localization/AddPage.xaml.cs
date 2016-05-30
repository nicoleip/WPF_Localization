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
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySQL_WPF_Localization;

namespace MySQL_WPF_Localization
{
   
    public partial class AddPage : Page
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        private MainWindow w;

        public AddPage()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            server = "localhost";
            database = "testwpf";
            uid = "root";
            password = "";
            string connString;
            connString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                if (this.txt_name.Text == "" || this.txt_address.Text == "" || this.txt_city.Text == "" || this.txt_phone.Text == "" || this.txt_email.Text == "")
                {
                    MessageBox.Show("Please fill all the inputs");

                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT into customers VALUES(NULL, '" + this.txt_name.Text + "', '" + this.txt_address.Text + "', '" + this.txt_city.Text + "', '" + this.txt_phone.Text + "', '" + this.txt_email.Text + "')", conn);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data saved successfully!");
                   
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Please fill all the fields with appropriate data!");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(w);
        }                             
                          
       
    }
}
