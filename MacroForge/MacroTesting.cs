using MacroForge.Models;
using MacroForge.Playback;
using WindowsInput.Native;

namespace MacroForge;

/// <summary>
/// Contains manual written tests and helper methods for creating and running tests
/// </summary>
/// <param name="ct">Cancellation token for the player</param>
public class MacroTesting(CancellationToken ct)
{
    
    /// <summary>
    /// Simulating a Key press (pressing and releasing)
    /// </summary>
    /// <param name="vk">Key to be pressed</param>
    /// <returns></returns>
    private MacroStep[] KeyPress(VirtualKeyCode vk)
    {
        return
        [
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                KeyboardAction = new KeyboardAction { EventType = KeyEventType.Down, Key = vk }
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                KeyboardAction = new KeyboardAction { EventType = KeyEventType.Up, Key = vk }
            }
        ];
    }

    /// <summary>
    /// Simulating a delay
    /// </summary>
    /// <param name="delay">Amount of time in milliseconds</param>
    /// <returns></returns>
    private MacroStep AddDelay(int delay)
    {
        return new MacroStep{CommandType = CommandType.Delay, Delay = delay};
    }

    /// <summary>
    /// Simulating pressing and holding a key
    /// </summary>
    /// <param name="vk">Key to be pressed</param>
    /// <returns></returns>
    private MacroStep KeyDown(VirtualKeyCode vk)
    {
        return new MacroStep
        {
            CommandType = CommandType.KeyboardEvent,
            KeyboardAction = new KeyboardAction { EventType = KeyEventType.Down, Key = vk }
        };
    }
    
    /// <summary>
    /// Simulating releasing a key
    /// </summary>
    /// <param name="vk">Key to be released</param>
    /// <returns></returns>
    private MacroStep KeyUp(VirtualKeyCode vk)
    {
        return new MacroStep
        {
            CommandType = CommandType.KeyboardEvent,
            KeyboardAction = new KeyboardAction { EventType = KeyEventType.Up, Key = vk }
        };
    }
    
    public async Task NotepadViaLWin()
    {
        var testPlayer = new Player();
        
        var macroList = new List<MacroStep>();
        
        macroList.AddRange(KeyPress(VirtualKeyCode.LWIN));
        
        macroList.Add(AddDelay(1000)); // Wait for windows to load
        
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_N));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_O));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_T));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_E));

        macroList.Add(AddDelay(1000)); // wait for results to load
        
        macroList.AddRange(KeyPress(VirtualKeyCode.RETURN));
        
        macroList.Add(AddDelay(2000)); // wait for notepad to open
        
        macroList.Add(KeyDown(VirtualKeyCode.SHIFT)); // write in uppercase
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_N));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_O));
        macroList.Add(KeyUp(VirtualKeyCode.SHIFT)); // remove uppercase
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_T));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_E));

        await testPlayer.PlayAsync(macroList, ct);
    }

    public async Task NotepadViaRun()
    {
        var testPlayer = new Player();
        
        var macroList = new List<MacroStep>();

        macroList.Add(KeyDown(VirtualKeyCode.LWIN));
        macroList.Add(KeyDown(VirtualKeyCode.VK_R));
        macroList.Add(KeyUp(VirtualKeyCode.LWIN));
        macroList.Add(KeyUp(VirtualKeyCode.VK_R));


        macroList.Add(AddDelay(1000)); // Wait for run window to load
        
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_N));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_O));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_T));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_E));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_P));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_A));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_D));
        macroList.AddRange(KeyPress(VirtualKeyCode.RETURN));
        
        macroList.Add(AddDelay(2000)); // wait for notepad to open
        
        macroList.Add(KeyDown(VirtualKeyCode.LWIN));
        macroList.AddRange(KeyPress(VirtualKeyCode.UP));
        macroList.Add(KeyUp(VirtualKeyCode.LWIN));
        macroList.Add(KeyDown(VirtualKeyCode.SHIFT)); // write in uppercase
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_N));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_O));
        macroList.Add(KeyUp(VirtualKeyCode.SHIFT)); // remove uppercase
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_T));
        macroList.AddRange(KeyPress(VirtualKeyCode.VK_E));

        await testPlayer.PlayAsync(macroList, ct);
    }
}