using System.Threading.Tasks;

namespace SliderDemo.Shell.Services
{
    public interface IDialogService
    {
        Task<DialogResult> RequestDialog(IControlConfigurationViewModel ViewModel);
    }
}