using SliderDemo.Shell.Services;

namespace SliderDemo.Shell.ViewModels.Slider
{
    public class SliderViewModelFactory
    {
        private readonly IControlTuningService<SliderConfiguration> _tuningService;

        public SliderViewModelFactory(IControlTuningService<SliderConfiguration> TuningService)
        {
            _tuningService = TuningService;
        }

        public SliderViewModel CreateViewModel(SliderConfiguration Configuration)
        {
            return new(Configuration, _tuningService);
        }
    }
}