using System.Runtime.InteropServices;

namespace MacroForge.Recorder;

[StructLayout(LayoutKind.Sequential)]
public struct KeyboardInput
{
    public ushort wVk; // Virtual-key code
    public ushort wScan; // Hardware scan code for the key
    public uint dwFlags; // Flags specifying various aspects of function operation
    public uint time; // Time stamp for the event
    public IntPtr dwExtraInfo; // Additional information associated with the keystroke
}