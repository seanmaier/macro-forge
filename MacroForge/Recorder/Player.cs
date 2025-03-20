using System.Runtime.InteropServices;

namespace MacroForge.Recorder;

public class Player
{
    public void Play(Input[] inputs)
    {
        NativeMethods.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public void Cancel()
    {
        // TODO implement cancel
    }
}