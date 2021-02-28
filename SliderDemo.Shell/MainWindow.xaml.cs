using System.Windows;
using SliderDemo.Shell.ViewModels;

namespace SliderDemo.Shell
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel MainViewModel)
        {
            DataContext = MainViewModel;
            InitializeComponent();
        }
    }
}