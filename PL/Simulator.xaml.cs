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

        DateTime GlobalTime;
        bool flag = true;
        Order order;
        BackgroundWorker worker;
        private int d;

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
            SimulatorDG.ItemsSource =  bl.Order.GetOrderForListM();
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            
           
            OrderForLists = new List<OrderForList?>(bl!.Order.GetOrderForListM());

        }
        private int PValue(BO.Order o)
        {

            if (o.Status == BO.Enums.OrderStatus.Ordered)
            {
                d = 25;
                return d;
            }
            if (o.Status == BO.Enums.OrderStatus.Ordered)
            {
                d = 50;
                return d;
            }
            else
            {

                d = 100;
                return d;

            }
        }


        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != true)
            {
                MessageBox.Show("the upddate order stoped");
            }
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            //IEnumerable<OrderForList> orders;
            var tmp = bl.Order.GetOrderForListM().ToList();

            try
            {
                foreach (var item in tmp)
                {
                    BO.Order demoOrder = bl.Order.GetByOrderIdM(item?.ID ?? throw new NullReferenceException());
                    if (GlobalTime - demoOrder.OrderDate >= new TimeSpan(2, 0, 0, 0) && demoOrder.Status == BO.Enums.OrderStatus.Ordered)
                        bl.Order.UpdateShipDateM(demoOrder.ID);
                    if (GlobalTime - demoOrder.OrderDate >= new TimeSpan(7, 0, 0, 0) && demoOrder.Status == BO.Enums.OrderStatus.Shipped)
                        bl.Order.UpdateDeliveryDateM(demoOrder.ID);
                    //int i =PValue(demoOrder);
                    //orderPBAR.Value = i;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK);
            }
            SimulatorDG.ItemsSource = bl.Order.GetOrderForListM().ToList();
        }
       
        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            GlobalTime = DateTime.Now;
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
                        //time = time.AddHours(4);
                        GlobalTime = GlobalTime.AddHours(4);

                        if (worker.WorkerReportsProgress == true)
                        {

                            worker.ReportProgress(111);//call "Worker_ProgressChanged" func

                        }
                    }
                    Thread.Sleep(2000);

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
