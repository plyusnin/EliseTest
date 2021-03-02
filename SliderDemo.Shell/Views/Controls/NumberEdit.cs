using System;
using System.Windows;
using System.Windows.Controls;

namespace SliderDemo.Shell.Views.Controls
{
    public class NumberEdit : TextBox
    {
        public static readonly DependencyProperty DigitsProperty = DependencyProperty.Register(
            "Digits", typeof(int), typeof(NumberEdit),
            new UIPropertyMetadata(0, DigitsPropertyChangedCallback, DigitsCoerceValueCallback));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(double), typeof(NumberEdit),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                          ValuePropertyChangedCallback));

        public NumberEdit()
        {
            RefreshText();
        }

        public int Digits
        {
            get => (int) GetValue(DigitsProperty);
            set => SetValue(DigitsProperty, value);
        }

        public double Value
        {
            get => (double) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        private static void ValuePropertyChangedCallback(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {
            var sender = (NumberEdit) D;
            sender.RefreshText();
        }

        private static object DigitsCoerceValueCallback(DependencyObject D, object Basevalue)
        {
            var val = (int) Basevalue;
            return Math.Max(0, val);
        }

        private static void DigitsPropertyChangedCallback(DependencyObject D, DependencyPropertyChangedEventArgs E)
        {
            var sender = (NumberEdit) D;
            sender.RefreshText();
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (double.TryParse(Text, out var newValue))
                Value = newValue;
            else
                RefreshText();
        }

        private void RefreshText()
        {
            Text = Value.ToString("F" + Digits);
        }
    }
}