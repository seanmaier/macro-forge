namespace MacroForge.Recorder;

[Flags]
public enum MouseEventF
{
    Absolute = 0x8000, // The coordinates are absolute
    HWheel = 0x01000, // Horizontal wheel scroll
    Move = 0x0001, // Mouse movement
    MoveNoCoalesce = 0x2000, // Do not coalesce mouse moves
    LeftDown = 0x0002, // Left button down
    LeftUp = 0x0004, // Left button up
    RightDown = 0x0008, // Right button down
    RightUp = 0x0010, // Right button up
    MiddleDown = 0x0020, // Middle button down
    MiddleUp = 0x0040, // Middle button up
    VirtualDesk = 0x4000, // Map to entire virtual desktop
    Wheel = 0x0800, // Vertical wheel scroll
    XDown = 0x0080, // X button down
    XUp = 0x0100 // X button up
}