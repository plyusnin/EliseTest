using System;
using System.Threading.Tasks;

namespace SliderDemo.Shell.Services.Implementations
{
    public abstract class ControlTuningServiceBase<TConfig, TViewModel> : IControlTuningService<TConfig>
        where TViewModel : IControlConfigurationViewModel
    {
        private readonly IDialogService _dialogService;

        protected ControlTuningServiceBase(IDialogService DialogService)
        {
            _dialogService = DialogService;
        }

        public async Task<TConfig> Tune(TConfig CurrentConfiguration)
        {
            var viewModel = CreateViewModel(CurrentConfiguration);
            try
            {
                var result = await _dialogService.RequestDialog(viewModel);

                return result switch
                {
                    DialogResult.Accepted => CreateConfig(viewModel),
                    DialogResult.Cancelled => CurrentConfiguration,
                    _ => throw new ArgumentException($"Unknown {nameof(DialogResult)} value: {result}")
                };
            }
            finally
            {
                (viewModel as IDisposable)?.Dispose();
            }
        }

        protected abstract TConfig    CreateConfig(TViewModel ViewModel);
        protected abstract TViewModel CreateViewModel(TConfig CurrentConfiguration);
    }
}