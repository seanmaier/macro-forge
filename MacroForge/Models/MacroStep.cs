namespace MacroForge;

public class MacroStep
{
    private int _stepNumber;
    private CommandType _commandType;
    private string _parameter;
    private int delay;

    public int StepNumber { get => _stepNumber; set => _stepNumber = value; }
    public CommandType CommandType { get => _commandType; set => _commandType = value; }
    public string Parameter { get => _parameter; set => _parameter = value; }
    public int Delay { get => delay; set => delay = value; }

    public MacroStep(CommandType commandType, string parameter, int delay)
    {
        CommandType = commandType;
        Parameter = parameter;
        this.Delay = delay;
    }

    
}