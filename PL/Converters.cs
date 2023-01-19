using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PL;

public class ConvertImagePathToBitmap : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            string ImageRelativeName = (string)value;
            string currentDir = Environment.CurrentDirectory[..^4];
            string ImageFullPath = currentDir + ImageRelativeName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(ImageFullPath));
            return bitmapImage;
        }
        catch (Exception ex)
        {
            string ImageRelativeName = @"\pics\IMG_FAILURE.jpg";
            string currentDir = Environment.CurrentDirectory[..^4];
            string ImageFullPath = currentDir + ImageRelativeName;
            BitmapImage bitmapImage = new BitmapImage(new Uri(ImageFullPath));
            return bitmapImage;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
public class ConvertPTrack : IValueConverter
{
    private BlApi.IBl bl = BlApi.Factory.Get();

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        //if (GlobalTime == null)
        //    GlobalTime.demoTime = DateTime.Now;
        BO.Order order = new();
        int id = (int)value;
        order = bl.Order.GetByOrderIdM(id);
        if (order.Status == BO.Enums.OrderStatus.Delivered)
            return 100; //the order is completed
                        //take the days that passed*10
        if (order.Status == BO.Enums.OrderStatus.Shipped)
            return 50;
        else
            return 25;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

/// <summary>
/// convert the simulation background color by status
/// </summary>
//public class StatusToColor : IValueConverter
//{
//    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        BO.OrderStatus status = (BO.OrderStatus)value;
//        if (status == BO.OrderStatus.Delivered)
//            return Brushes.DeepPink;
//        if (status == BO.OrderStatus.Approved)
//            return Brushes.LightPink;
//        else
//            return Brushes.Salmon;
//    }

//    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//    {
//        throw new NotImplementedException();
//    }
//}

