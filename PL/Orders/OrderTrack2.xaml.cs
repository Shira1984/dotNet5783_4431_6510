﻿using BO;
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
    /// Interaction logic for OrderTrack2.xaml
    /// </summary>
    public partial class OrderTrack2 : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        
        MessageBoxResult messageBoxResult;

        BO.Order o;
        public OrderTrack2(int t)
        {
            InitializeComponent();
            try
            {
                BO.OrderTracking ot = bl.Order.FollowOrderM(t);
                ordertrarktxt.Text = ot.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            
            o = bl.Order.GetByOrderIdM(t);
            //o.Items=
        }

        //private void orderDetailsBTN_Click(object sender, RoutedEventArgs e)
        //{
        //    new PL.Orders.FollowOrder().Show();
        //}

        private void orderDetailsBTN_Click(object sender, RoutedEventArgs e)
        {
            new PL.Orders.FollowOrder(o).Show();
        }

        private void orderDetailsBTN_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void orderDetailsBTN_MouseLeave(object sender, MouseEventArgs e)
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
