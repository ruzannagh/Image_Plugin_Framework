using ImagePluginFramework.Plugins;

namespace ImagePluginFramework.Models
{
    public class Image
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();     
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<IImagePlugin> Plugins { get; } = new();

        public Image(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddPlugin(IImagePlugin plugin) => Plugins.Add(plugin);
    }
}
