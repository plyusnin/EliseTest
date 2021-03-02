using System.Windows;
using SliderDemo.Shell.Services;
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
            var mainViewModel = new MainViewModel(new SliderViewModelFactory(new SliderControlTuningService()));
            var mainWindow    = new MainWindow(mainViewModel);
            mainWindow.Show();
        }
    }
}

// This class is needed to user { init } property attribute
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}