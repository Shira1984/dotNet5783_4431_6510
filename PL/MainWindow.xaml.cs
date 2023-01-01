//using BlApi;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        //private IBl bl = new BlImplementation.Bl();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowAdminView_Click(object sender, RoutedEventArgs e)
        {
            new PL.AdminView().Show();
        }

        private void OrderBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    new PL.Products.ProductListWindow().Show();
        //}

        private void AdminBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height*1.1;
                b.Width = b.Width*1.1;
            }
        }

        private void AdminBTN_MouseLeave(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height / 1.1;
                b.Width = b.Width / 1.1;
            }
        }

        private void OrderBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void OrderBTN_MouseLeave(object sender, MouseEventArgs e)
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
