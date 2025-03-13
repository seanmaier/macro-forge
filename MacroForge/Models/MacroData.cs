namespace MacroForge;

public class MacroData
{
    private string _name;
    private DateTime _createdAt;
    private DateTime? _lastChanged;
    private string? _shortcut;
    private string _description;
    private List<MacroStep> _macroSteps;

    public MacroData(string name, string description, List<MacroStep> macroSteps, string? shortcut = null)
    {
        _name = name;
        _shortcut = shortcut;
        _description = description;
        _macroSteps = macroSteps;
        _createdAt = DateTime.Now;
    }
}