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
        double topr;

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
            BO.ProductForList item = (BO.ProductForList)((sender as Button).DataContext);
            BO.Product pro = bl.Product.GetProductM(item.Id);
            if (pro.InStock >= 1)
            {

                //if()
                //     if(chek1.ProductID== pro.Id)
                //     {
                //         chek1.Amount++;
                //         chek1.Price= chek1.Price+pro.Price;
                //     }
                //bool a = DataSource.OrdersList.Any(or => or?.ID == order.ID);

                BO.OrderItem p = new BO.OrderItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    ProductID = item.Id,
                    //Amount = (int)myCart.Where(x => x.ProductID == p.ProductID).Sum() ?? 0,
                    
                };
                foreach (var chek in myCart)
                {
                    if(chek.ProductID==p.ProductID)
                    {
                        p.Amount++;
                        
                    }
                }
                if (p != null)
                {
                    
                    myCart.Add(p);
                    topr = topr + p.Price;
                    MessageBox.Show("Added!", "", MessageBoxButton.OK);

                }
            }

            else
            {
                MessageBox.Show("Out of stok", "", MessageBoxButton.OK);

            }
        }
        private void addTCBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void addTCBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height / 1.1;
                b.Width = b.Width / 1.1;
            }
        }

        private void FinishBTN_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<OrderItem?> mc = myCart;
            new PL.Cart.Cart(mc, topr).Show();
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
