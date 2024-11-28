using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для AutoWindow.xaml
    /// </summary>
    public partial class AutoWindow : Window
    {
        public AutoWindow()
        {
            InitializeComponent();
        }


        public bool LogPass(string connectionString, string login, string password)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("Select count(*) from [User] where [login] = @login and [password] = @password;", connection))
            {
                command.Parameters.AddWithValue("@login",login);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                return (int)command.ExecuteScalar() > 0;


            }

        }
        public bool LogPassClient(string connectionString, string login, string password)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("Select count(*) from [Client] where [login] = @login and [password] = @password;", connection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                return (int)command.ExecuteScalar() > 0;


            }

        }

        public string IsType(string connectionString, string login, string password)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT type FROM [User] WHERE [login] = @login AND [password] = @password", connection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToString(result); 
                }
                else
                {
                    return null;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = logintxt.Text;
            string password = passwordtxt.Password;

            MyDbContext db = new MyDbContext();

            if(LogPass(db.connetionString, login, password))
            {
                string type = IsType(db.connetionString, login, password);
                if (type != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            } else if (LogPassClient(db.connetionString, login, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
