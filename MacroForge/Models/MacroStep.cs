namespace MacroForge;

public class MacroStep
{
    private int _stepNumber;
    private CommandType _commandType;
    private string _parameter;
    private int delay;

    public MacroStep(CommandType commandType, string parameter, int delay)
    {
        _commandType = commandType;
        _parameter = parameter;
        this.delay = delay;
    }

    
}