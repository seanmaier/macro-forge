using System.Windows;

namespace MacroForge;

public interface INavigationService
{
    void NavigateTo<T>() where T: Window, new();
}