using System.IO;
using System.Reflection;

namespace MacroForge.Schemas;

public static class SchemaLoader
{
    public static string ReadSchema(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName)
                           ?? throw new FileNotFoundException($"Resource {resourceName} not found.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}