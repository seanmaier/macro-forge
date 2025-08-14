using MacroForge.Models;
using WindowsInput;

namespace MacroForge.Playback;

public class Player()
{
    private readonly InputSimulator _sim = new();

    public async Task PlayAsync(MacroData macro, CancellationToken cts)
    {
        foreach (var step in macro.MacroSteps)
        {
            cts.ThrowIfCancellationRequested();
            
            await Task.Delay(step.Delay, cts);

            if (step.CommandType == CommandType.KeyboardEvent)
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
        if (keyAction.Modifiers.Count > 0)
        {
            _sim.Keyboard.ModifiedKeyStroke(keyAction.Modifiers.ToArray(), keyAction.Key);
        }
        else
        {
            switch (keyAction.EventType)
            {
                case KeyEventType.Press: _sim.Keyboard.KeyPress(keyAction.Key);
                    break;
                case KeyEventType.Down: _sim.Keyboard.KeyDown(keyAction.Key);
                    break;
                case KeyEventType.Up: _sim.Keyboard.KeyUp(keyAction.Key);
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
            case MouseEventType.LeftClick: _sim.Mouse.LeftButtonClick();
                break;
            case MouseEventType.LeftDoubleClick: _sim.Mouse.LeftButtonDoubleClick();
                break;
            case MouseEventType.RightClick: _sim.Mouse.RightButtonClick();
                break;
            case MouseEventType.RightDoubleClick: _sim.Mouse.RightButtonDoubleClick();
                break;
            case MouseEventType.MoveTo: _sim.Mouse.MoveMouseTo(mouseAction.X, mouseAction.Y);
                break;
            case MouseEventType.HorizontalScroll:
                _sim.Mouse.HorizontalScroll(mouseAction.HorizontalScroll);
                break;
            case MouseEventType.VerticalScroll: _sim.Mouse.VerticalScroll(mouseAction.VerticalScroll);
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
            _sim.Mouse.MoveMouseBy(stepX, stepY);
            await Task.Delay(delayMs);
        }
    }
    
    public void Cancel()
    {
        // TODO implement cancel
    }
}