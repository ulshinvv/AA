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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.model;

namespace WpfApp5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadRequests();
        }
        public void LoadRequests()
        {
            MyDbContext db = new MyDbContext();
            using (SqlConnection connection = new SqlConnection(db.connetionString))
            using (SqlCommand command = new SqlCommand("Select requestID, startDate, orgTechType, orgTechModel, problemDescryption, requestStatus, completionDate from Reqiests", connection))
            {
                connection.Open();
                List<Reqiests> reqiests = new List<Reqiests>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reqiests.Add(new Reqiests
                        {
                            requestID = reader.GetInt32(0),
                            startDate = reader.GetDateTime(1),
                            orgTechType = reader.GetString(2),
                            orgTechModel = reader.GetString(3),
                            problemDescryption = reader.GetString(4),
                            requestStatus = reader.GetString(5),
                            //completionDate = reader.GetDateTime(6),

                        });
                    }

                   // ldd.Items.Clear();

                    ldd.ItemsSource = reqiests;
                }
            }
        }
    }
}
