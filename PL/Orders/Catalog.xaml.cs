using BO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        private ObservableCollection<OrderItem?> myCart; 


        public Catalog()
        {
            InitializeComponent();
            catView.ItemsSource = bl.Product.GetListedProducts();
            //catView.DataContext = myCart;
            myCart = new ObservableCollection<OrderItem?>();
            //ddd.DataContext = myCart;

        }

        private void addTCBTN_Click(object sender, RoutedEventArgs e)
        {
            OrderItem p = (sender as Button).DataContext as OrderItem;

            if (p != null)
            {
                myCart.Add(p);
                MessageBox.Show("Added!", "", MessageBoxButton.OK);
            }
        }

        private void FinishBTN_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<OrderItem?> mc = myCart;
            new PL.Cart.Cart(mc).Show();
        }

        private void FinishBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void FinishBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height / 1.1;
                b.Width = b.Width / 1.1;
            }
        }
    }
}
