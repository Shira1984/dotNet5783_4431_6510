//using BlApi;
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

namespace PL.Products
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        //private IBl bl = new BlImplementation.Bl();
        /// <summary>
        /// constractoe for ProductListWindow
        /// </summary>
        public ProductListWindow()
        {
            InitializeComponent();
            ProductListView.ItemsSource = bl.Product.GetListedProductsM();
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        }


        /// <summary>
        /// func that make list of the Categories in the ProductListWindow
        /// </summary>

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.Enums.Category c = (Enums.Category)CategorySelector.SelectedItem;
            ProductListView.ItemsSource = bl.Product.GetListedProducts().Where(pro => pro.Category == c);
        }


        /// <summary>
        /// Button_Click for open the option to add product
        /// </summary 
        private void AddProWinButton_Click(object sender, RoutedEventArgs e)
        {
            new ProductWindow().Show();
            ProductListView.ItemsSource = bl.Product.GetListedProducts();
        }


        /// <summary>
        /// Button_Click  for open the option to update product, when you do it on the list of products in ProductListWindow
        /// </summary>
        private void update(object sender, MouseButtonEventArgs e)
        {
            if (ProductListView.SelectedItem is ProductForList p)
                new ProductWindow(p).ShowDialog();
            ProductListView.ItemsSource=bl.Product.GetListedProducts();
        }

        private void AddProBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void AddProBTN_MouseLeave(object sender, MouseEventArgs e)
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
