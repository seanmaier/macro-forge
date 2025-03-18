using System.Runtime.InteropServices;

namespace MacroForge.Recorder;

[StructLayout(LayoutKind.Sequential)]
public struct HardwareInput
{
    public uint uMsg;
    public ushort wParamL;
    public ushort wParamH;
}