using System.Runtime.InteropServices;

namespace MacroForge.Recorder;

[StructLayout(LayoutKind.Sequential)]
public struct HardwareInput
{
    public uint uMsg; // Message identifier
    public ushort wParamL; // Low-order word of the message parameter
    public ushort wParamH; // High-order word of the message parameter
}