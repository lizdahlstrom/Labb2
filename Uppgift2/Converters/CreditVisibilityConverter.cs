using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Uppgift2.Datatypes;

namespace Uppgift2.Converters
{
    public class CreditVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(AccountType.Checking) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
