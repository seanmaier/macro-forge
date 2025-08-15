namespace MacroForge.Models;

public class MacroStep
{
    public CommandType CommandType { get; set; }
    public int Delay { get; set; }
    
    public KeyboardAction? KeyboardAction { get; set; }
    public MouseAction? MouseAction { get; set; }
}