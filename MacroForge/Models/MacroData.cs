namespace MacroForge.Models;

public class MacroData
{

    public MacroData() // If the user simply clicks create a macro without any options
    {
        Name = "";
        MacroSteps = [];
    }

    public MacroData(string name) // If the user gives the macro just a name
    {
        Name = name;
        MacroSteps = [];
    }

    public MacroData(string name, List<MacroStep> macroSteps)
    {
        Name = name;
        MacroSteps = macroSteps;
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? LastChanged { get; set; }
    public string? Shortcut { get; set; } // Custom shortcut chosen by user
    public string? Description { get; set; }
    public List<MacroStep> MacroSteps { get; set; }
}