namespace SliderDemo.Shell.ViewModels.Slider
{
    public record SliderConfiguration
    {
        /// <summary>The name of the slider</summary>
        public string Name { get; init; }

        /// <summary>Minimum value</summary>
        public double Minimum { get; init; }

        /// <summary>Maximum value</summary>
        public double Maximum { get; init; }

        /// <summary>User value</summary>
        public double Value { get; init; }

        /// <summary>A number of digits after a separator</summary>
        public int Precision { get; init; }

        /// <summary>Rounding kind</summary>
        public NumberRounding Rounding { get; init; }
    }
}