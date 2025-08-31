namespace ImagePluginFramework.Models
{
    public sealed class PluginParameter
    {
        public string? Name { get; init; }
        public object? Value { get; init; }

        public T? GetValue<T>() => (Value is T v) ? v : default;

        public override string ToString() =>
            Name is null ? Value?.ToString() ?? "<null>" : $"{Name}: {Value}";
    }
}
