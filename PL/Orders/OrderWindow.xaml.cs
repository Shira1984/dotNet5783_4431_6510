using BO;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();

        public OrderWindow()
        {
            InitializeComponent();
        }

        public OrderWindow(OrderForList ofl)
        {
            InitializeComponent();
            StatusCombo.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
            IDtTextBox.Text = ofl.ID.ToString();
            csttTextBox.Text = ofl.CustomerName;
            StatusCombo.Text = ofl.Status.ToString();
            TotalpriceTextBox.Text = ofl.TotalPrice.ToString();
            AmountTextBox.Text = ofl.AmountOfItems.ToString();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult;
            BO.OrderForList o = new BO.OrderForList() { };
            try
            {
                if (StatusCombo.Text.Length == 0)
                    MessageBox.Show("You chose a problematic category my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                { 
                    o.Status = (Enums.OrderStatus)StatusCombo.SelectedItem;
                    if(o.Status == )
                 
                    messageBoxResult = MessageBox.Show("Product updated succesfully", "Succesfull", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            catch (BO.BlAlredyFindException ex)
            {
                messageBoxResult = MessageBox.Show(ex.InnerException.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}
    }
}
