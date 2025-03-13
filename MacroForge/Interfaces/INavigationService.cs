using System.Windows;

namespace MacroForge.Interfaces;

public interface INavigationService
{
    void NavigateTo<T>() where T: Window, new();
}