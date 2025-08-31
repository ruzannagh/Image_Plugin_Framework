using ImagePluginFramework.Models;
using ImagePluginFramework.Plugins;

namespace ImagePluginFramework.Plugins
{
    public class BlurPlugin : IImagePlugin
    {
        public string Id => "blur";
        public string Name => "Blur";
        public string? Description => "Blurs image.";

        public void Apply(Image image, PluginParameter? parameter)
        {
            var intensity = parameter?.GetValue<int?>() ?? -1;
            Console.WriteLine($"[BlurPlugin] {image.Id} -> apply blur with intensity {intensity}");
        }
    }
}
