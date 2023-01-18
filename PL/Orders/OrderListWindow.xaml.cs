using BO;
using PL.Products;
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

namespace PL.Orders
{
    /// <summary>
    /// Interaction logic for OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        public OrderListWindow()
        {
            InitializeComponent();
            //ObservableCollection<BO.OrderForList> obs= (ObservableCollection<BO.OrderForList>)bl.Order.GetOrderForListM();
            //OrderListView.ItemsSource = obs;

           OrderListView.ItemsSource= bl.Order.GetOrderForListM();
        }

        void ShowOrder(object sender, MouseButtonEventArgs e)
        {
           
                if (OrderListView.SelectedItem is OrderForList o)
                    new OrderWindow(o).ShowDialog();
                OrderListView.ItemsSource = bl.Product.GetListedProducts();
           
           
        }
    }
}
