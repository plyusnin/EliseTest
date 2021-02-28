using System;
using System.Globalization;

namespace SliderDemo.Shell.ValueConversion
{
    public interface INumberConversion
    {
        string Name { get; }
        string GetString(double Value);
        double GetCorrectedValue(double RawValue);
        object GetValue(double Value);
    }

    public class DoubleNumberConversion : INumberConversion
    {
        public DoubleNumberConversion()
        {
            Name      = "Q";
            Precision = 2;
        }

        public int    Precision { get; set; }
        public string Name      { get; }

        public string GetString(double Value)
        {
            return Value.ToString(new NumberFormatInfo { NumberDecimalDigits = Precision });
        }

        public double GetCorrectedValue(double RawValue)
        {
            return Math.Round(RawValue, Precision);
        }

        public object GetValue(double Value)
        {
            return GetCorrectedValue(Value);
        }
    }

    public class IntNumberConversion : INumberConversion
    {
        public IntNumberConversion()
        {
            Name = "Z";
        }

        public string Name { get; }

        public string GetString(double Value)
        {
            return Value.ToString();
        }

        public double GetCorrectedValue(double RawValue)
        {
            return Math.Round(RawValue);
        }

        public object GetValue(double Value)
        {
            return (int) GetCorrectedValue(Value);
        }
    }
}