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
using static System.Formats.Asn1.AsnWriter;

namespace PL.Orders;





/// <summary>
/// Interaction logic for FollowOrder.xaml
/// </summary>
public partial class FollowOrder : Window
{
    public BO.Order? order
    {
        get { return (BO.Order?)GetValue(orderProperty); }
        set { SetValue(orderProperty, value); }
    }

    // Using a DependencyProperty as the backing store for order.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty orderProperty =
        DependencyProperty.Register("order", typeof(BO.Order), typeof(Window), new PropertyMetadata(null));


    BlApi.IBl bl = BlApi.Factory.Get();
    double dd;
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
        
        statusTXTBX.Text=o.Status.ToString();

        //ObservableCollection<BO.OrderItem?> mc = (BO.OrderItem?)o.Items?.ToList();


        //var mc = 
        //from score in o.Items?.ToList()
        //select score;
        //foreach (var item in mc)
        //{
        //    dd=dd+ item.Price;
        //}
        //ItemsListV.DataContext = mc.ToList();
        order=o;
        ItemsListV.ItemsSource=order.Items;
        TotalPriceTextBox.Text =dd.ToString();
    }
}
