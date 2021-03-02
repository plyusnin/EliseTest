using System.Threading.Tasks;

namespace SliderDemo.Shell.Services
{
    public interface IControlTuningService<TConfig>
    {
        /// <summary>Opens a tuning dialog and waits for a new configuration</summary>
        /// <param name="CurrentConfiguration">Current configuration of the control</param>
        /// <returns>
        ///     Modified configuration, if the user confirmed changes or <paramref name="CurrentConfiguration" /> if the user
        ///     cancelled the dialog
        /// </returns>
        Task<TConfig> Tune(TConfig CurrentConfiguration);
    }
}