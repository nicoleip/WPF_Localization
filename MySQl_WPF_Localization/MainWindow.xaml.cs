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
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySQL_WPF_Localization;
using EZLocalizeNS;




namespace MySQL_WPF_Localization

{
    
    public partial class MainWindow : Window
   {
    private string server;
    private string database;
    private string uid;
    private string password;      

        
       
        public MainWindow()
        {
             
            InitializeComponent();
            List<string> AllBaseFileName = MyEZLocalize.getFileBaseNames(MyEZLocalize.CurrentLggPath);
            if (AllBaseFileName.Count > 0)
            {
                string FirstLggFileName = AllBaseFileName[0];
                List<string> AllLgg = MyEZLocalize.LanguagesForFileBaseName(MyEZLocalize.CurrentLggPath, FirstLggFileName); 
                foreach (string lgg in AllLgg)
                LggChoiceLV.Items.Add(lgg);
                
            }

            MyEZLocalize.LanguageChanged += ShowCurrentLgg;
            currLgg.Content = MyEZLocalize.CurrentLanguage;                      
          
        }

        public EZLocalizeNS.EZLocalize MyEZLocalize = MySQL_WPF_Localization.App.MyEZLocalize;
       
        private void btnloaddata_Click(object sender, RoutedEventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("Select id,name,address,city,phone,email from customers", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds, "LoadDataBinding");
                dataGridCustomers.DataContext = ds;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new Uri("AddPage.xaml", UriKind.Relative));
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new Uri("UpdatePage.xaml", UriKind.Relative));
        }
        
        private void LggChoiceLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView LV = (ListView)sender;
            string item = (string)LV.SelectedItem;
            MyEZLocalize.ChangeLanguage(item);            
        }      
       

        private void ShowCurrentLgg(string newLgg)
        {
            currLgg.Content = newLgg;
        }
    }
}