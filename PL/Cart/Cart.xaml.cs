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

namespace PL.Cart
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        BO.Cart c = new BO.Cart() { };
        public Cart(ObservableCollection<OrderItem?> mc, double d)
        {
            c.Items = mc;

            InitializeComponent();
           

            ItemsLSTBX.DataContext = mc.ToList();
            TotalPriceTextBox.Text = d.ToString();

            c.TotalPrice = d;
        }

        private void GoToOrBTN_Click(object sender, RoutedEventArgs e)
        {
            if (c.Items == null)
            {
                MessageBox.Show("You don't have any items my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult messageBoxResult;
                try
                {
                    if (CstNameTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic Customer Name my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        c.CustomerName = CstNameTextBox.Text;
                    if (CstEmailTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic Customer Email my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        c.CustomerEmail = CstEmailTextBox.Text;
                    if (CstAdressTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic Customer Email my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        c.CustomerAdress = CstAdressTextBox.Text;
                }
                catch (BO.BlAlredyFindException ex)
                {
                    messageBoxResult = MessageBox.Show(ex.InnerException.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
                new PL.OrderWindowC(c).Show();

        }

        private void GoToOrBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void GoToOrBTN_MouseLeave(object sender, MouseEventArgs e)
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
