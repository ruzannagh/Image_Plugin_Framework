using ImagePluginFramework.Plugins;

namespace ImagePluginFramework.Services
{
    public interface IPluginManager
    {
        void Register(IImagePlugin plugin);
        bool TryGet(string id, out IImagePlugin? plugin);
    }
}