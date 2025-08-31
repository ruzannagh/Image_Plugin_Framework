using ImagePluginFramework.Models;
using ImagePluginFramework.Plugins;

namespace ImagePluginFramework.Plugins
{
    public class ResizePlugin : IImagePlugin
    {
        public string Id => "resize";
        public string Name => "Resize";
        public string? Description => "Resizes image.";

        public void Apply(Image image, PluginParameter? parameter)
        {
            var width = parameter?.GetValue<int?>() ?? -1;
            Console.WriteLine($"[ResizePlugin] {image.Id} -> resize to {width}px");
        }
    }
}
