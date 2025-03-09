﻿namespace MacroForge;

public class MacroData
{
    private string _name;
    private DateTime _createdAt;
    private DateTime? _lastChanged = null;
    private string _description;
    private List<MacroStep> _macroSteps;

    public MacroData(string name, string description, List<MacroStep> macroSteps)
    {
        _name = name;
        _description = description;
        _macroSteps = macroSteps;
        _createdAt = DateTime.Now;
    }
}