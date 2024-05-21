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

namespace DEMO2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DBCon.DB = new DEMOEntities();
        }

        public void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var authorizquery = DBCon.DB.Пользователь.FirstOrDefault(user => user.Логин == TxtLogin.Text && user.Пароль == TxtPassword.Password);
                if (authorizquery != null)
                {
                    if(authorizquery.ID_Роли == 1)// Клиент
                    {
                        CLient cLient = new CLient(authorizquery.ID);
                        cLient.Show();
                        this.Hide();
                    }else if (authorizquery.ID_Роли == 2)// Админ
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }      
        }

        public class forTest
        {  
            public bool testc(string login, string pass)
            {
                if (login == "Client" && pass == "Client")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
