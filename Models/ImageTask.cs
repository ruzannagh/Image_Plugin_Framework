namespace ImagePluginFramework.Models
{
    public class ImageTask
    {
        public Image Image { get; }
        public IReadOnlyList<PluginCall> PluginCalls { get; }

        public ImageTask(Image image, IReadOnlyList<PluginCall> pluginCalls)
        {
            Image = image;
            PluginCalls = pluginCalls;
        }
    }
}