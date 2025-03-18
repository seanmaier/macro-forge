namespace MacroForge;

public class MacroData
{
    private string _name;
    private DateTime _createdAt;
    private DateTime? _lastChanged;
    private List<string>? _shortcut;
    private string? _description;
    private List<MacroStep>? _macroSteps;

    public string Name { get => _name; set => _name = value; }
    public DateTime CreatedAt { get => _createdAt; set => _createdAt = value; }
    public DateTime? LastChanged { get => _lastChanged; set => _lastChanged = value; }
    public List<string>? Shortcut { get => _shortcut; set => _shortcut = value; }
    public string? Description { get => _description; set => _description = value; }
    public List<MacroStep>? MacroSteps { get => _macroSteps; set => _macroSteps = value; }

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
        CreatedAt = DateTime.Now;
        LastChanged = CreatedAt;
    }

    public MacroData()
    {
        Name = "";
        CreatedAt = DateTime.Now;
        LastChanged = CreatedAt;
    }





}