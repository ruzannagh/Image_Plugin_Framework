using System.Text.Json;
using ImagePluginFramework.Plugins; 

namespace ImagePluginFramework.Services
{
    public class PluginManager : IPluginManager
    {
        private readonly Dictionary<string, IImagePlugin> _registry = new();

        public void Register(IImagePlugin effect) => _registry[effect.Id] = effect;

        public bool TryGet(string id, out IImagePlugin? effect) =>
            _registry.TryGetValue(id, out effect);

        public static string[] LoadFromJson(string json)
        {
            try
            {
                var doc = JsonDocument.Parse(json);
                if (doc.RootElement.ValueKind == JsonValueKind.Array)
                    return doc.RootElement.EnumerateArray()
                        .Where(e => e.ValueKind == JsonValueKind.String)
                        .Select(e => e.GetString()!)
                        .ToArray();
            }
            catch { }
            return Array.Empty<string>();
        }

        public bool Remove(string id)
        {
            return _registry.Remove(id);
        }
    }
}