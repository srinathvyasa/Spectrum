using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinSpectrum.Converter
{
    public class CellColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.FromHex("#2196F3");
            else
                return Color.White;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
