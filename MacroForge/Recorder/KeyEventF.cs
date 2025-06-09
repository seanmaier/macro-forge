namespace MacroForge.Recorder;

[Flags]
public enum KeyEventF
{
    KeyDown = 0x0000, // Key down event
    ExtendedKey = 0x0001, // Extended key event
    KeyUp = 0x0002, // Key up event
    Unicode = 0x0004, // Unicode character event
    Scancode = 0x0008, // Scancode event
}