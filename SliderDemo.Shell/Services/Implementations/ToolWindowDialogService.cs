using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows;
using SliderDemo.Shell.Views;

namespace SliderDemo.Shell.Services.Implementations
{
    /// <summary>An implementation of <see cref="IDialogService" /> which shows a configuration window in a ToolWindow</summary>
    public class ToolWindowDialogService : IDialogService
    {
        public async Task<DialogResult> RequestDialog(IControlConfigurationViewModel ViewModel)
        {
            var window = new TuningWindow(ViewModel) { Owner = Application.Current.MainWindow };
            var windowClosed = Observable.FromEventPattern(h => window.Closed += h,
                                                           h => window.Closed -= h);
            var resultAwaiter = ViewModel.Result
                                         .Merge(windowClosed.Select(_ => DialogResult.Cancelled))
                                         .FirstAsync()
                                         .ToTask();
            window.Show();
            try
            {
                var result = await resultAwaiter;
                return result;
            }
            finally
            {
                window.Close();
            }
        }
    }
}