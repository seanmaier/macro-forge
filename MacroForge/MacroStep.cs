using MacroForge.Recorder;
using System.Runtime.InteropServices;

namespace MacroForge;

public class MacroStep
{
    private int _stepNumber;
    private CommandType _commandType;
    private Input _input;
    private int delay;

    public int StepNumber { get => _stepNumber; set => _stepNumber = value; }
    public CommandType CommandType { get => _commandType; set => _commandType = value; }
    public Input StepInput { get => _input; set => _input = value; }
    public int Delay { get => delay; set => delay = value; }

    public MacroStep(CommandType commandType, int delay)
    {
        CommandType = commandType;
        //NewInput(type, wscan, iEvent);
        Delay = delay;
    }
    public MacroStep(CommandType commandType, Input input, int delay)
    {
        CommandType = commandType;
        StepInput = input;
        Delay = delay;
    }

    public void NewInput(InputType type, ushort wscan, KeyEventF iEvent)
    {
        StepInput = new Input
        {
            type = (int)InputType.Keyboard,
            u = new InputUnion
            {
                ki = new KeyboardInput
                {
                    wVk = 0,
                    wScan = wscan,
                    dwFlags = (uint)(iEvent),
                    dwExtraInfo = GetMessageExtraInfo()
                }
            }
        };
    }

    public void NewInput(InputType type, int dX, int dY, MouseEventF iEvent)
    {
        StepInput = new Input
        {
            type = (int)InputType.Mouse,
            u = new InputUnion
            {
                mi = new MouseInput
                {
                    dx = dX,
                    dy = dY,
                    dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                }
            }
        };
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();


}