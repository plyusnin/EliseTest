using System.Windows;
using SliderDemo.Shell.Services;

namespace SliderDemo.Shell.Views
{
    public partial class TuningWindow : Window
    {
        public TuningWindow(IControlConfigurationViewModel ViewModel)
        {
            DataContext = ViewModel;
            InitializeComponent();
        }
    }
}