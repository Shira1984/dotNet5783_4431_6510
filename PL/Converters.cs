using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PL
{
    class ConvertImagePathToBitmap : IValueConverter
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
            catch(Exception ex)
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
}
