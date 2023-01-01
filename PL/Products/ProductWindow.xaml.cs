//using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace PL.Products
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();

        public BO.Product p
        {
            get { return (BO.Product)GetValue(pProperty); }
            set { SetValue(pProperty, value); }
        }

        // Using a DependencyProperty as the backing store for p.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty pProperty =
            DependencyProperty.Register("p", typeof(BO.Product), typeof(Window), new PropertyMetadata(null));



        //private IBl bl = new BlImplementation.Bl();

        /// <summary>
        /// first constractor for add prodact mode
        /// </summary>
        public ProductWindow()
        {
            InitializeComponent();
            AddCatCOMBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            upadBTN.Content = "Add";
        }

        /// <summary>
        /// first constractor for update prodact mode
        /// </summary>
        public ProductWindow(ProductForList pfl)
        {
            InitializeComponent();
            AddCatCOMBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            IDTextBox.Text=pfl.Id.ToString();
            NameTextBox.Text = pfl.Name;
            AddCatCOMBox.Text = pfl.Category.ToString();
            PriceTextBox.Text = pfl.Price.ToString();
            AmountTextBox.Text=bl.Product.GetProductM(pfl.Id).InStock.ToString();
            upadBTN.Content = "Update";
        }

        /// <summary>
        /// the Button Click that open the option to add/update product
        /// </summary>
        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult;
            //BO.Product p = new BO.Product() { };

            try
            {
                if (upadBTN.Content == "Add")
                {
                    if(IDTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic ID my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        p.Id = int.Parse(IDTextBox.Text);

                        if (IDTextBox.Text.Length!=6)
                            MessageBox.Show("You chose a problematic ID my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if(NameTextBox.Text.Length==0)
                        MessageBox.Show("You chose a problematic name my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        p.Name = NameTextBox.Text;

                    if(AddCatCOMBox.Text.Length==0)
                        MessageBox.Show("You chose a problematic category my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        p.Category = (Enums.Category)AddCatCOMBox.SelectedItem;// fix it

                    if (PriceTextBox.Text.Length==0)
                        MessageBox.Show("You chose a problematic price my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        p.Price = double.Parse(PriceTextBox.Text);

                        if (p.Price <= 0)
                            MessageBox.Show("You chose a problematic price my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    if (AmountTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic amount my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        p.InStock = int.Parse(AmountTextBox.Text);

                        if (p.InStock <= 0)
                            MessageBox.Show("You chose a problematic amount my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    if ((IDTextBox.Text.Length == 6) && (NameTextBox.Text.Length != 0) && (PriceTextBox.Text.Length > 0) && (AmountTextBox.Text.Length > 0) && (AddCatCOMBox.Text.Length != 0))
                    {
                        bl.Product.AddProductM(p);
                        messageBoxResult = MessageBox.Show("Product added succesfully", "Succesfull", MessageBoxButton.OK, MessageBoxImage.None);
                    }
                    Close();
                }
                else //(upadBTN.Content == "Update")
                {
                    p.Id = int.Parse(IDTextBox.Text);
                    if (p.Id < 100000)
                        MessageBox.Show("You chose a problematic ID my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (NameTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic name my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        p.Name = NameTextBox.Text;

                    if (AddCatCOMBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic category my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                        p.Category = (Enums.Category)AddCatCOMBox.SelectedItem;

                    if (PriceTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic price my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        p.Price = double.Parse(PriceTextBox.Text);

                        if (p.Price <= 0)
                            MessageBox.Show("You chose a problematic price my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if (AmountTextBox.Text.Length == 0)
                        MessageBox.Show("You chose a problematic amount my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    else
                    {
                        p.InStock = int.Parse(AmountTextBox.Text);

                        if (p.InStock <= 0)
                            MessageBox.Show("You chose a problematic amount my dear...", "Hey, there is a problem", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    if ((IDTextBox.Text.Length == 6) && (NameTextBox.Text.Length != 0) && (PriceTextBox.Text.Length > 0) && (AmountTextBox.Text.Length > 0) && (AddCatCOMBox.Text.Length != 0))
                    {
                        bl.Product.UpdateProductM(p);
                        messageBoxResult = MessageBox.Show("Product updated succesfully", "Succesfull", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (BO.BlAlredyFindException ex)
            {
                messageBoxResult = MessageBox.Show(ex.InnerException.Message,"ERROR",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //switch(messageBoxResult)
            //{
            //    case MessageBoxResult.OK or MessageBoxResult.Cancel:
            //        Close();
            //        break;
            //    default:
            //        break;
            //}//
        }

        private void upadBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void upadBTN_MouseLeave(object sender, MouseEventArgs e)
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
