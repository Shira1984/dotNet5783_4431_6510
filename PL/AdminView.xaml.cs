﻿using System;
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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void ProductListViewBTN_Click(object sender, RoutedEventArgs e)
        {
            new PL.Products.ProductListWindow().Show();
        }

        private void OrdersListViewBTN_Click(object sender, RoutedEventArgs e)
        {
            new PL.Orders.OrderListWindow().Show();
        }
    }
}
