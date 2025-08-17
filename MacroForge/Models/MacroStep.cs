namespace MacroForge.Models;

public class MacroStep
{
    /// <summary>
    /// The number of the current step
    /// </summary>
    public int StepNumber { get; set; }
    /// <summary>
    /// Specifies whether the macro step involves a keyboard or mouse action.
    /// </summary>
    public CommandType CommandType { get; set; }
    /// <summary>
    /// Delay before the macro gets executed
    /// </summary>
    public int? Delay { get; set; }
    /// <summary>
    /// The specific action executed for keyboard event
    /// </summary>
    public KeyboardAction? KeyboardAction { get; set; }
    /// <summary>
    /// The specific action executed for mouse event
    /// </summary>
    public MouseAction? MouseAction { get; set; }
}