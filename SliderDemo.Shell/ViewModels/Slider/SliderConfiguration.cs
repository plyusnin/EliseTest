namespace SliderDemo.Shell.ViewModels.Slider
{
    public record SliderConfiguration
    {
        public string         Name      { get; init; }
        public double         Minimum   { get; init; }
        public double         Maximum   { get; init; }
        public double         Value     { get; init; }
        public int            Precision { get; init; }
        public NumberRounding Rounding  { get; init; }
    }
}