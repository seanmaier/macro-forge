namespace MacroForge;

public class MacroData
{
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastChanged { get; set; }
    public List<string>? Shortcut { get; set; }
    public string? Description { get; set; }
    public List<MacroStep> MacroSteps { get; set; }

    public MacroData(string name, string description, List<MacroStep> macroSteps, List<string>? shortcut = null)
    {
        Name = name;
        Shortcut = shortcut;
        Description = description;
        MacroSteps = macroSteps;
        CreatedAt = DateTime.Now;
        LastChanged = CreatedAt;
    }

    public MacroData(string name)
    {
        Name = name;
        MacroSteps = [];
        CreatedAt = DateTime.Now;
        LastChanged = CreatedAt;
    }

    public MacroData()
    {
        Name = "";
        MacroSteps = [];
        CreatedAt = DateTime.Now;
        LastChanged = CreatedAt;
    }





}