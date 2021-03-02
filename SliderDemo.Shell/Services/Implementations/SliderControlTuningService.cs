using SliderDemo.Shell.ViewModels.Slider;

namespace SliderDemo.Shell.Services.Implementations
{
    public class
        SliderControlTuningService : ControlTuningServiceBase<SliderConfiguration, SliderConfigurationViewModel>
    {
        public SliderControlTuningService(IDialogService DialogService) : base(DialogService) { }

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