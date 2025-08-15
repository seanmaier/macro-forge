using WindowsInput.Native;

namespace MacroForge.Models;

public class KeyboardAction
{
    public VirtualKeyCode Key { get; set; }
    public List<VirtualKeyCode> Modifiers { get; set; } = [];
    public KeyEventType EventType { get; set; }
}