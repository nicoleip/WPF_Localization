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
   
    public partial class UpdatePage : Page
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        private MainWindow w;
        

        public UpdatePage()
        {
            InitializeComponent();
        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("SELECT * from customers where id = '" + this.txt_id.Text + "'", conn);        

                MySqlDataReader dr = cmd.ExecuteReader();

                if (!(dr.HasRows))
                {
                    MessageBox.Show("No record found!");
                }
                else
                {
                    
                    while (dr.Read())
                    {
                        this.txt_name.Text = dr.GetString(1);
                        this.txt_address.Text = dr.GetString(2);
                        this.txt_city.Text = dr.GetString(3);
                        this.txt_phone.Text = dr.GetString(4);
                        this.txt_email.Text = dr.GetString(5);
                        
                    }

                    dr.Close();
                    ((IDisposable)dr).Dispose();
                }
            }      

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
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
                
                MySqlCommand cmd = new MySqlCommand("UPDATE customers SET name='" + this.txt_name.Text + "', address = '" + this.txt_address.Text + "', city = '" + this.txt_city.Text + "', phone = '" + this.txt_phone.Text + "', email = '" + this.txt_email.Text + "' where id = '"+ this.txt_id.Text +"'", conn);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved successfully!");
               
                
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
