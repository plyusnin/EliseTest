using System.Threading.Tasks;

namespace SliderDemo.Shell.Services
{
    /// <summary>Describes a way of showing a configuration dialog to the user</summary>
    public interface IDialogService
    {
        /// <summary>Shows a dialog to the user and waits for a confirmation</summary>
        /// <param name="ViewModel">Dialog content</param>
        Task<DialogResult> RequestDialog(IControlConfigurationViewModel ViewModel);
    }
}