using ImagePluginFramework.Models;
using ImagePluginFramework.Plugins;

namespace ImagePluginFramework.Services
{
    public class ImageProcessor : IImageProcessor
    {
        private readonly IPluginManager _pluginManager;

        public ImageProcessor(IPluginManager pluginManager) => _pluginManager = pluginManager;

        public void Process(IEnumerable<ImageTask> tasks)
        {
            foreach (var task in tasks)
            {
                foreach (var call in task.PluginCalls)
                {
                    if (_pluginManager.TryGet(call.PluginId, out var plugin))
                    {
                        plugin.Apply(task.Image, call.Parameter);
                    }
                }
            }
        }
    }
}