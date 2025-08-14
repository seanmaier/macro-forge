namespace MacroForge.Models;

public class MacroStep
{
    public int StepNumber { get; set; }
    public CommandType CommandType { get; set; }
    public string Parameter { get; set; }
    public int Delay { get; set; }

    public MacroStep(CommandType commandType, string parameter, int delay)
    {
        CommandType = commandType;
        Parameter = parameter;
        this.Delay = delay;
    }

    
}