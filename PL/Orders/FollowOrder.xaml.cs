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

namespace PL.Orders
{
    /// <summary>
    /// Interaction logic for FollowOrder.xaml
    /// </summary>
    public partial class FollowOrder : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
       
        public FollowOrder(BO.Order o)
        {
            InitializeComponent();
            OrderIdTXTBX.Text =o.ID.ToString();
            CstNameTextBox.Text = o.CustomerName;
            CstEmailTextBox.Text = o.CustomerEmail;
            CstAdressTextBox.Text = o.CustomerAdress;
            OrderDateTextBox.Text = o.OrderDate.ToString();
            ShipDateTextBox.Text=o.ShipDate.ToString();
            DeliveryDateTextBox.Text =(o.DeliveryDate.ToString());
            TotalPriceTextBox.Text =(o.TotalPrice.ToString());
            statusTXTBX.Text=o.Status.ToString();
            //ItemsListV


        }
    }
}
