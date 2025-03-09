namespace MacroForge;

public class MacroStep
{
    public MacroStep(CommandType commandType, string parameter, int delay)
    {
        _commandType = commandType;
        _parameter = parameter;
        this.delay = delay;
    }

    private int _stepNumber;
    private CommandType _commandType;
    private string _parameter;
    private int delay;
}