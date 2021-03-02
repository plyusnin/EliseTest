using System.Windows;
using System.Windows.Controls;

namespace SliderDemo.Shell.Views.Controls
{
    public class ConfigPropertyEditor : ContentControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(ConfigPropertyEditor), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty HasErrorProperty = DependencyProperty.Register(
            "HasError", typeof(bool), typeof(ConfigPropertyEditor), new PropertyMetadata(false));

        public string Label
        {
            get => (string) GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public bool HasError
        {
            get => (bool) GetValue(HasErrorProperty);
            set => SetValue(HasErrorProperty, value);
        }
    }
}