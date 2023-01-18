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
    /// 

    //public BO.Cart cart
    //{
    //    get { return (BO.Cart)GetValue(cartProperty); }
    //    set { SetValue(cartProperty, value); }
    //}
    public partial class OrderWindowC : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();

        public BO.Cart cart;

        //BO.Order o = new BO.Order();
        DateTime mydate = DateTime.Today;
        double d = 3.0;
        BO.OrderForList orderList = new BO.OrderForList();
        public OrderWindowC(BO.Cart c)
        {
            cart = c;
            InitializeComponent();
            OrderStatusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
            
            //o.Items = c.Items;
            //IdTextBox.Text=
            ItemsLSTBX.DataContext = c.Items.ToList();
            //IdTextBox.Text=o.ID.ToString();
            CstNameTextBox.Text=c.CustomerName;
            CstEmailTextBox.Text=c.CustomerEmail;
            CstAdressTextBox.Text=c.CustomerAdress;
            TotalPriceTextBox.Text = c.TotalPrice.ToString();
            OrderStatusComboBox.Text = BO.Enums.OrderStatus.Ordered.ToString();
            OrderDateTextBox.Text = DateTime.Now.ToString();

            //ShipDateTextBox.Text= new DateTime(mydate.Year, mydate.Month, mydate.Day).AddDays(d);

            //OrderDateTextBox.Text = DateTime.Today.ToString();
            //o.CustomerName=c.CustomerName;
            //o.CustomerAdress=c.CustomerAdress;
            //o.CustomerEmail=c.CustomerEmail;
            //o.OrderDate = mydate;
            //o.Status = BO.Enums.OrderStatus.Ordered;

            //o.TotalPrice = c.TotalPrice.Value;
            //o.ShipDate = null;
            //o.DeliveryDate = null;

            //orderList.CustomerName=c.CustomerName;
            //orderList.Status = BO.Enums.OrderStatus.Ordered;
            //orderList.TotalPrice = c.TotalPrice.Value;
            //orderList.ID = o.ID;
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
               int k= bl.Cart.OrderCart(cart, CstNameTextBox.Text, CstEmailTextBox.Text, CstAdressTextBox.Text);
            }
            catch (BO.BlNoFindException ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (BO.BlNotGoodValueException ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            MessageBox.Show(" Your order is finished seccessfuly");
            //MessageBox.Show((string)k);
        }

       
    }
}
