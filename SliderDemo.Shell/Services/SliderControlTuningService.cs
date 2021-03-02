using SliderDemo.Shell.ViewModels.Slider;

namespace SliderDemo.Shell.Services
{
    public class
        SliderControlTuningService : ToolWindowControlTuningService<SliderConfiguration, SliderConfigurationViewModel>
    {
        protected override SliderConfiguration CreateConfig(SliderConfigurationViewModel ViewModel)
        {
            return new()
            {
                Name      = ViewModel.CustomName,
                Rounding  = ViewModel.SelectedRounding,
                Minimum   = ViewModel.MinValue,
                Maximum   = ViewModel.MaxValue,
                Value     = ViewModel.UserValue,
                Precision = ViewModel.Precision
            };
        }

        protected override SliderConfigurationViewModel CreateViewModel(SliderConfiguration CurrentConfiguration)
        {
            return new()
            {
                CustomName       = CurrentConfiguration.Name,
                SelectedRounding = CurrentConfiguration.Rounding,
                Digits           = CurrentConfiguration.Precision,
                MinValue         = CurrentConfiguration.Minimum,
                MaxValue         = CurrentConfiguration.Maximum,
                UserValue        = CurrentConfiguration.Value
            };
        }
    }
}