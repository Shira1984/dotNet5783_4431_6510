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
        DateTime mydate = DateTime.Today;
        double d = 3.0;
        public OrderWindowC(BO.Cart c)
        {
            InitializeComponent();
            OrderStatusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
            BO.Order o = new BO.Order();
            o.Items = c.Items;
            ItemsLSTBX.DataContext = o.Items.ToList();
            IdTextBox.Text=o.ID.ToString();
            CstNameTextBox.Text=c.CustomerName;
            CstEmailTextBox.Text=c.CustomerEmail;
            CstAdressTextBox.Text=c.CustomerAdress;
            TotalPriceTextBox.Text = c.TotalPrice.ToString();
            OrderStatusComboBox.Text = BO.Enums.OrderStatus.Ordered.ToString();
            //ShipDateTextBox.Text= new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(d);
           
            OrderDateTextBox.Text = DateTime.Today.ToString();
            o.CustomerName=c.CustomerName;
            o.CustomerAdress=c.CustomerAdress;
            o.CustomerEmail=c.CustomerEmail;
            o.OrderDate = mydate;
            o.Status = BO.Enums.OrderStatus.Ordered;


            o.TotalPrice = c.TotalPrice.Value;
            o.ShipDate = null;
            o.DeliveryDate = null;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
