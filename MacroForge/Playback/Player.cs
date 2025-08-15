using MacroForge.Models;
using WindowsInput;

namespace MacroForge.Playback;

public class Player()
{
    private readonly InputSimulator _inputSimulator = new();

    /// <summary>
    /// Method to play macros asynchronous to allow cancellation of macro
    /// </summary>
    /// <param name="macro">Macro to be played</param>
    /// <param name="cts">Cancellation token</param>
    public async Task PlayAsync(MacroData macro, CancellationToken cts)
    {
        foreach (var step in macro.MacroSteps)
        {
            cts.ThrowIfCancellationRequested();
            
            await Task.Delay(step.Delay, cts);

            if (step.CommandType == CommandType.KeyboardEvent) // actions to execute based on mouse or keyboard macro step
            {
                var keyAction = step.KeyboardAction;

                if (keyAction == null) return;
                
                SimulateKeyboard(keyAction);
            }
            else
            {
                var mouseAction = step.MouseAction;

                if (mouseAction == null) return;
                
               SimulateMouse(mouseAction);
            }
        }
    }

    private void SimulateKeyboard(KeyboardAction keyAction)
    {
        if (keyAction.Modifiers.Count > 0) // modifiers like [ctrl, shift]
        {
            _inputSimulator.Keyboard.ModifiedKeyStroke(keyAction.Modifiers.ToArray(), keyAction.Key);
        }
        else
        {
            switch (keyAction.EventType)
            {
                case KeyEventType.Press: _inputSimulator.Keyboard.KeyPress(keyAction.Key);
                    break;
                case KeyEventType.Down: _inputSimulator.Keyboard.KeyDown(keyAction.Key);
                    break;
                case KeyEventType.Up: _inputSimulator.Keyboard.KeyUp(keyAction.Key);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void SimulateMouse(MouseAction mouseAction)
    {
        switch (mouseAction.EventType)
        {
            case MouseEventType.LeftClick: _inputSimulator.Mouse.LeftButtonClick();
                break;
            case MouseEventType.LeftDoubleClick: _inputSimulator.Mouse.LeftButtonDoubleClick();
                break;
            case MouseEventType.RightClick: _inputSimulator.Mouse.RightButtonClick();
                break;
            case MouseEventType.RightDoubleClick: _inputSimulator.Mouse.RightButtonDoubleClick();
                break;
            case MouseEventType.MoveTo: _inputSimulator.Mouse.MoveMouseTo(mouseAction.X, mouseAction.Y);
                break;
            case MouseEventType.HorizontalScroll:
                _inputSimulator.Mouse.HorizontalScroll(mouseAction.HorizontalScroll);
                break;
            case MouseEventType.VerticalScroll: _inputSimulator.Mouse.VerticalScroll(mouseAction.VerticalScroll);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private async Task SmoothMoveMouseBy(int deltaX, int deltaY, int steps = 50, int delayMs = 5)
    {
        int stepX = deltaX / steps;
        int stepY = deltaY / steps;

        for (int i = 0; i < steps; i++)
        {
            _inputSimulator.Mouse.MoveMouseBy(stepX, stepY);
            await Task.Delay(delayMs);
        }
    }
}