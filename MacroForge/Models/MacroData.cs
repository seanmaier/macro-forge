namespace MacroForge.Models;

public class MacroData
{

    public MacroData()
    {
        Name = "";
        MacroSteps = [];
    }

    public MacroData(string name)
    {
        Name = name;
        MacroSteps = [];
    }

    public MacroData(string name, List<MacroStep> macroSteps)
    {
        Name = name;
        MacroSteps = macroSteps;
    }
    
    public Guid Id = new();
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastChanged { get; set; }
    public string? Shortcut { get; set; }
    public string? Description { get; set; }
    public List<MacroStep> MacroSteps { get; set; }
}