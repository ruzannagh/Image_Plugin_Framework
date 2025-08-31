using ImagePluginFramework.Models;

namespace ImagePluginFramework.Plugins
{
    public class GrayscalePlugin : IImagePlugin
    {
        public string Id => "grayscale";
        public string Name => "Grayscale";
        public string? Description => "Converts image to grayscale.";

        public void Apply(Image image, PluginParameter? parameter)
        {
            Console.WriteLine($"[GrayscalePlugin] {image.Id} -> convert to grayscale");
        }
    }
}