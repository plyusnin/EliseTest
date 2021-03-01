using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace SliderDemo.Shell.Views.Converters
{
    public class SizeToRectConverter : IMultiValueConverter
    {
        public static SizeToRectConverter Instance { get; } = new();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v => v == DependencyProperty.UnsetValue))
                return new Rect();
            
            if (values.Length != 2 || !(values[0] is double) || !(values[1] is double))
                throw new ArgumentException(
                    $"\"{nameof(values)}\" should contain 2 double values for width and height correspondingly");

            var width  = (double) values[0];
            var height = (double) values[1];
            return new Rect(new Size(width, height));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}