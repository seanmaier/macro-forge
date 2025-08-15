namespace MacroForge.Models;

/// <summary>
/// Represents a mouse action in a macro step.
/// </summary>
public class MouseAction
{
    /// <summary>
    /// Specifies the type of mouse event (e.g., click, move, scroll).
    /// </summary>
    public MouseEventType EventType { get; set; }
    
    /// <summary>
    /// The X-coordinate for the mouse action (used for movement).
    /// </summary>
    public int X { get; set; }
    
    /// <summary>
    /// The Y-coordinate for the mouse action (used for movement).
    /// </summary>
    public int Y { get; set; }
    
    /// <summary>
    /// The amount of vertical scrolling (used for scroll events).
    /// </summary>
    public int VerticalScroll { get; set; }
    
    /// <summary>
    /// The amount of horizontal scrolling (used for scroll events).
    /// </summary>
    public int HorizontalScroll { get; set; }
}