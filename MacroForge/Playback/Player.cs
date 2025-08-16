using MacroForge.Models;
using WindowsInput;

namespace MacroForge.Playback;

public class Player()
{
    private readonly InputSimulator _inputSimulator = new();

    /// <summary>
    /// Method to play macros asynchronous to allow cancellation of macro
    /// </summary>
    /// <param name="steps">Macro steps to be played</param>
    /// <param name="cts">Cancellation token</param>
    public async Task PlayAsync(List<MacroStep> steps, CancellationToken cts)
    {
        foreach (var step in steps)
        {
            cts.ThrowIfCancellationRequested();


            switch (step.CommandType) // actions to execute based on macro step event
            {
                case CommandType.Delay:
                    if (!step.Delay.HasValue) return;
                    await Task.Delay(step.Delay.Value, cts);
                    break;
                case CommandType.KeyboardEvent:
                    var keyAction = step.KeyboardAction;
                    if (keyAction == null) return;
                    SimulateKeyboard(keyAction);
                    break;
                case CommandType.MouseEvent:
                    var mouseAction = step.MouseAction;
                    if (mouseAction == null) return;
                    SimulateMouse(mouseAction);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    private void SimulateKeyboard(KeyboardAction keyAction)
    {
        switch (keyAction.EventType)
        {
            case KeyEventType.Down:
                _inputSimulator.Keyboard.KeyDown(keyAction.Key);
                break;
            case KeyEventType.Up:
                _inputSimulator.Keyboard.KeyUp(keyAction.Key);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void SimulateMouse(MouseAction mouseAction)
    {
        switch (mouseAction.EventType)
        {
            case MouseEventType.LeftClick:
                _inputSimulator.Mouse.LeftButtonClick();
                break;
            case MouseEventType.RightClick:
                _inputSimulator.Mouse.RightButtonClick();
                break;
            case MouseEventType.MoveTo:
                _inputSimulator.Mouse.MoveMouseTo(mouseAction.X, mouseAction.Y);
                break;
            case MouseEventType.HorizontalScroll:
                _inputSimulator.Mouse.HorizontalScroll(mouseAction.HorizontalScroll);
                break;
            case MouseEventType.VerticalScroll:
                _inputSimulator.Mouse.VerticalScroll(mouseAction.VerticalScroll);
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