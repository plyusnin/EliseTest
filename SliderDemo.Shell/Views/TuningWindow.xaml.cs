using System.Windows;
using System.Windows.Input;
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

        private void StartWindowDrag(object Sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }
}