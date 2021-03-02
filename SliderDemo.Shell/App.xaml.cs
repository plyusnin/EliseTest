using System.Windows;
using SliderDemo.Shell.Services.Implementations;
using SliderDemo.Shell.ViewModels;
using SliderDemo.Shell.ViewModels.Slider;

namespace SliderDemo.Shell
{
    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // In a real project, all this things should be taken
            // from a DI-container.
            var dialogService          = new ToolWindowDialogService();
            var sliderViewModelFactory = new SliderViewModelFactory(new SliderControlTuningService(dialogService));
            var mainViewModel          = new MainViewModel(sliderViewModelFactory);
            
            var mainWindow             = new MainWindow(mainViewModel);
            mainWindow.Show();
        }
    }
}

// This class is needed to user { init } property attribute
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}