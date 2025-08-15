namespace MacroForge.Models;

public class MouseAction
{
    public MouseEventType EventType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int VerticalScroll { get; set; }
    public int HorizontalScroll { get; set; }
}