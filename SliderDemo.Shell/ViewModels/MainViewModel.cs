using ReactiveUI;
using SliderDemo.Shell.Services;
using SliderDemo.Shell.ViewModels.Slider;

namespace SliderDemo.Shell.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Slider = new SliderViewModel(new SliderConfiguration
                                         {
                                             Name      = "Number Slider",
                                             Minimum   = 0,
                                             Maximum   = 1,
                                             Rounding  = NumberRounding.Real,
                                             Value     = 0.7,
                                             Precision = 2
                                         },
                                         new SliderControlTuningService());
            SliderConfiguration = new SliderConfigurationViewModel();
        }

        public SliderViewModel              Slider              { get; }
        public SliderConfigurationViewModel SliderConfiguration { get; }
    }
}