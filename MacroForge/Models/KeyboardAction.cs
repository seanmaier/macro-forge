using WindowsInput.Native;

namespace MacroForge.Models;

public class KeyboardAction
{
    /// <summary>
    /// Single key to be executed
    /// </summary>
    public VirtualKeyCode Key { get; set; }
    /// <summary>
    /// Modifiers like ctrl and shift that are applied to the Key of the current KeyboardAction
    /// </summary>
    public List<VirtualKeyCode> Modifiers { get; set; } = [];
    /// <summary>
    /// Specific Keyboard Event Type like down, up and press (combines up and down)
    /// </summary>
    public KeyEventType EventType { get; set; }
}