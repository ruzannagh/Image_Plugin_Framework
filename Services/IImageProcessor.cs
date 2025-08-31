using ImagePluginFramework.Models;
using ImagePluginFramework.Plugins;

namespace ImagePluginFramework.Services
{
    public interface IImageProcessor
    {
        void Process(IEnumerable<ImageTask> tasks);
    }
}