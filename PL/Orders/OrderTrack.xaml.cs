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
    /// Interaction logic for OrderTrack.xaml
    /// </summary>
    public partial class OrderTrack : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        MessageBoxResult messageBoxResult;
        public OrderTrack()
        {
            InitializeComponent();
        }

        private void OrTrBTN_Click(object sender, RoutedEventArgs e)
        {

            BO.Order order = new BO.Order();

            try
            {
                order = bl.Order.GetByOrderIdM(int.Parse(orIDTXTBX.Text));
            }
            catch (BO.BlNoFindException ex)
            {
                messageBoxResult = MessageBox.Show(ex.InnerException.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            new PL.Orders.OrderTrack2(int.Parse(orIDTXTBX.Text)).Show();
        }
    }
}
//if (orIDTXTBX.Text.Length == 0)
//    MessageBox.Show("You chose a problematic ID my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);