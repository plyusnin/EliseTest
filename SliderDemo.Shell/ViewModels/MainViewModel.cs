using System.Collections.Generic;
using System.Linq;
using ReactiveUI;
using SliderDemo.Shell.ViewModels.Slider;

namespace SliderDemo.Shell.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel(SliderViewModelFactory SliderViewModelFactory)
        {
            var sliderConfigurations = new[]
            {
                new SliderConfiguration
                {
                    Name      = "Double Slider",
                    Minimum   = 0,
                    Maximum   = 1,
                    Rounding  = NumberRounding.Real,
                    Value     = 0.7,
                    Precision = 2
                },
                new SliderConfiguration
                {
                    Name     = "Integer Slider",
                    Minimum  = 0,
                    Maximum  = 10,
                    Rounding = NumberRounding.Natural,
                    Value    = 4
                }
            };

            Controls = sliderConfigurations.Select(SliderViewModelFactory.CreateViewModel)
                                           .OfType<IControlViewModel>()
                                           .ToList();
        }

        public IList<IControlViewModel> Controls { get; }
    }
}