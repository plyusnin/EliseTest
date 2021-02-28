using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace SliderDemo.Shell.Views.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public static EnumDescriptionConverter Instance { get; } = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value as Enum;
            if (val == null)
                throw new ArgumentException();

            return GetEnumDescription(val);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi        = value.GetType().GetField(value.ToString())!;
            var       attribute = fi.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }
}