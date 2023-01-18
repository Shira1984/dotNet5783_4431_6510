using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Printing.IndexedProperties;
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
using static System.Formats.Asn1.AsnWriter;

namespace PL.Orders;





/// <summary>
/// Interaction logic for FollowOrder.xaml
/// </summary>
public partial class FollowOrder : Window
{
    //public BO.Order order;
    public BO.Order? order
    {
        get { return (BO.Order?)GetValue(orderProperty); }
        set { SetValue(orderProperty, value); }
    }

    // Using a DependencyProperty as the backing store for order.This enables animation, styling, binding, etc...
    public static readonly DependencyProperty orderProperty =
        DependencyProperty.Register("order", typeof(BO.Order), typeof(Window), new PropertyMetadata(null));


    BlApi.IBl bl = BlApi.Factory.Get();
    //double dd;
    public FollowOrder(BO.Order o)
    {
        order = o;
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
        ItemsLSTBX.ItemsSource=o.Items.ToList();

    }
}
