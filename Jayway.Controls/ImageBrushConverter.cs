using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Jayway.Controls
{
    public class ImageBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage image = (BitmapImage)value;
            ImageBrush imageBrush = new ImageBrush();
            if (image != null)
            {
                imageBrush.ImageSource = image;
            }
            return imageBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
