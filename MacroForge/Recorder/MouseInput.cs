using System.Runtime.InteropServices;

namespace MacroForge.Recorder;

[StructLayout(LayoutKind.Sequential)]
public struct MouseInput
{
    public int dx; // The x-coordinate of the mouse
    public int dy; // The y-coordinate of the mouse
    public uint mouseData; // Additional data associated with the mouse event
    public uint dwFlags; // Flags specifying various aspects of mouse event
    public uint time; // Time stamp for the event
    public IntPtr dwExtraInfo; // Additional information associated with the mouse event
}