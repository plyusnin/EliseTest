using System.Threading.Tasks;

namespace SliderDemo.Shell.Services
{
    public interface IControlTuningService<TConfig>
    {
        Task<TConfig> Tune(TConfig CurrentConfiguration);
    }
}