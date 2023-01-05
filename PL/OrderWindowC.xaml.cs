using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for OrderWindowC.xaml
    /// </summary>
    public partial class OrderWindowC : Window
    {
        public OrderWindowC(BO.Cart c)
        {
            InitializeComponent();
            OrderStatusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
            BO.Order o = new BO.Order();
            o.CustomerName = c.CustomerName;
            o.CustomerAdress = c.CustomerAdress;
            o.CustomerEmail = c.CustomerEmail;
            o.Items = c.Items.ToList();
            o.OrderDate = DateTime.Today;
            o.ShipDate = null;
            o.DeliveryDate = null;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
