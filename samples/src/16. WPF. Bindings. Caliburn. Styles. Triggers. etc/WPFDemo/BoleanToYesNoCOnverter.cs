using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFDemo
{
    public class BoleanToYesNoCOnverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool) value;
            return boolValue ? "Yes" : "No";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (string)value;
            return boolValue == "Yes";
        }
    }
}