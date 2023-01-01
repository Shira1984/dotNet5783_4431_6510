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

namespace PL
{
    /// <summary>
    /// Interaction logic for OrderWindowC.xaml
    /// </summary>
    public partial class OrderWindowC : Window
    {
        public OrderWindowC()
        {
            InitializeComponent();
            OrderStatusComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
            
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult;
            BO.Order o = new BO.Order() { };
            o.ID = Config.NextOrderNumber;
            try
            {
                if (CstNameTextBox.Text.Length == 0)
                    MessageBox.Show("You chose a problematic Customer Name my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    o.CustomerName = CstNameTextBox.Text;
                if (CstEmailTextBox.Text.Length == 0)
                    MessageBox.Show("You chose a problematic Customer Email my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    o.CustomerEmail = CstEmailTextBox.Text;
                if (CstAdressTextBox.Text.Length == 0)
                    MessageBox.Show("You chose a problematic Customer Email my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    o.CustomerAdress = CstAdressTextBox.Text;
                if (OrderStatusComboBox.Text.Length == 0)
                    MessageBox.Show("You chose a problematic Order Status my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    o.Status = (BO.Enums.OrderStatus)OrderStatusComboBox.SelectedItem;

            }
            catch (BO.BlAlredyFindException ex)
            {
                messageBoxResult = MessageBox.Show(ex.InnerException.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            o.OrderDate= DateTime.Today;
            o.ShipDate = null;
            o.DeliveryDate = null;
        }

        //private void IDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
    }
}
