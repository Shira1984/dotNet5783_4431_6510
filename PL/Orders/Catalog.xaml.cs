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

namespace PL.Orders
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        private ObservableCollection<ProductForList> _myCollection = new ObservableCollection<ProductForList>();


        public Catalog()
        {
            InitializeComponent();
            //catView.ItemsSource = bl.Product.GetListedProducts();
            this.DataContext = _myCollection;
        }
    }
}
