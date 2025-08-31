using ImagePluginFramework.Models;

namespace ImagePluginFramework.Plugins
{
    public interface IImagePlugin
    {
        string Id { get; }
        string Name { get; }
        string? Description { get; }
        void Apply(Image image, PluginParameter? parameter);
    }
}