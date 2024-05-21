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

namespace DEMO2
{
    /// <summary>
    /// Логика взаимодействия для CLient.xaml
    /// </summary>
    public partial class CLient : Window
    {
        public CLient(int ID)
        {
            InitializeComponent();
            try
            {
                UserObj.ID = ID;
                UpdateTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            TableOrder.Items.Clear();
            var updateOrders = DBCon.DB.Заявка.Include("Пользователь").Where(user => user.ID_Пользователя == UserObj.ID);
            if (updateOrders != null) 
            {
                TableOrder.ItemsSource = updateOrders.ToList();
            }
            
        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Заявка заявка = new Заявка();
                заявка.Дата = DateTime.Now.ToString();
                заявка.Оборудование = TxtEq.Text;
                заявка.ID_Пользователя = UserObj.ID;
                DBCon.DB.Заявка.Add(заявка);
                DBCon.DB.SaveChanges();
                MessageBox.Show("Заявка дбавлена");
                UpdateTable();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
