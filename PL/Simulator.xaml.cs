using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            {
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
                            Thread.Sleep(3000);
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
    }
}
