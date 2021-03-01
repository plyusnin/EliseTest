using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows;
using SliderDemo.Shell.Views;

namespace SliderDemo.Shell.Services
{
    public abstract class ToolWindowControlTuningService<TConfig, TViewModel> : IControlTuningService<TConfig>
        where TViewModel : IControlConfigurationViewModel
    {
        public async Task<TConfig> Tune(TConfig CurrentConfiguration)
        {
            var viewModel = CreateViewModel(CurrentConfiguration);
            try
            {
                var window = new TuningWindow(viewModel) { Owner = Application.Current.MainWindow };
                var windowClosed = Observable.FromEventPattern(h => window.Closed += h,
                                                               h => window.Closed -= h);
                var resultAwaiter = viewModel.Result
                                             .Merge(windowClosed.Select(_ => DialogResult.Cancelled))
                                             .Do(r => Console.WriteLine(r))
                                             .FirstAsync()
                                             .ToTask();
                window.Show();
                var result = await resultAwaiter;
                window.Close();
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