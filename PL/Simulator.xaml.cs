using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Simulator.xaml
    /// </summary>
    public partial class Simulator : Window
    {
        BlApi.IBl bl = BlApi.Factory.Get();
        DateTime time = DateTime.Now;
        bool flag = true;
        Order order;
        BackgroundWorker worker;

        public List<OrderForList?> OrderForLists
        {
            get { return (List<OrderForList?>)GetValue(OrderForListsProperty); }
            set { SetValue(OrderForListsProperty, value); }
        }

        public static readonly DependencyProperty OrderForListsProperty =
        DependencyProperty.Register("OrderForLists", typeof(List<OrderForList?>), typeof(Simulator), new PropertyMetadata(null));

        public Simulator()
        {
            InitializeComponent();
            SimulatorDG.ItemsSource = bl.Order.GetOrderForListM();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            OrderForLists = new List<OrderForList>(bl!.Order.GetOrderForListM());

        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            //OrderForLists = new List<OrderForList>(bl!.Order.GetOrderForListM());
            IEnumerable<OrderForList> orders;

            try
            {
                foreach (var item in OrderForLists)
                {
                    if (item.Status != BO.Enums.OrderStatus.Delivered)
                        order = bl.Order.GetByOrderIdM(item.ID) ?? throw new Exception("order is null");
                    //is it created?
                    if (item.Status == BO.Enums.OrderStatus.Ordered)
                    {
                        order = bl.Order.UpdateShipDateM(item.ID);
                    }
                    else if (item.Status == BO.Enums.OrderStatus.Shipped)
                    {
                        order = bl.Order.UpdateDeliveryDateM(item.ID);
                    }
                    OrderForLists = new List<OrderForList>(bl!.Order.GetOrderForListM());
                }
                //if (order.Status==BO.Enums.OrderStatus.Ordered)
                    //orderPBAR.pr
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK);
            }
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                while (flag == true)//if its false-> we go "Worker_RunWorkerCompleted" func 
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        time = time.AddHours(4);
                        if (worker.WorkerReportsProgress == true)
                            worker.ReportProgress(11);//call "Worker_ProgressChanged" func


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK);
            }


        }

        private void otBTN_Click(object sender, RoutedEventArgs e)
        {
            BO.OrderForList item = (BO.OrderForList)((sender as Button).DataContext);
            new PL.Orders.OrderTrack2(item.ID).Show();
        }

        private void startTrBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (worker.IsBusy != true)
                {
                    this.Cursor = Cursors.Wait;
                    worker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK);
            }
        }

        private void stopTrBTN_Click(object sender, RoutedEventArgs e)
        {
            if (worker.WorkerSupportsCancellation == true)
                worker.CancelAsync();
            this.Cursor = Cursors.Arrow;
        }

        private void BtnLBL_MouseEnter(object sender, MouseEventArgs e)
        {
            Button? b = sender as Button;
            if (b != null)
            {
                b.Height = b.Height * 1.1;
                b.Width = b.Width * 1.1;
            }
        }

        private void BtnLBL_MouseLeave(object sender, MouseEventArgs e)
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
