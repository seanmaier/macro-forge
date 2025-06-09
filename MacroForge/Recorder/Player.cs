using System.Runtime.InteropServices;
using System.Windows;

namespace MacroForge.Recorder;

public class Player
{
    public Player()
    {
    }

    public void PlayMacro(MacroData macro)
    {
        foreach (MacroStep? step in macro.MacroSteps)
        {
            DoInputEvent(step);
        }

        Input[] inputs = new[] {
            new Input
            {
                type = (int)InputType.Mouse,
                u = new InputUnion
                {
                    mi = new MouseInput
                    {
                        dx = 100,
                        dy = 100,
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void DoInputEvent(MacroStep step)
    {
        Input[] inputs = new[] { step.StepInput };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void Cancel()
    {
        // TODO implement cancel
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, Input[] inputs, int cbSize);

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();
}