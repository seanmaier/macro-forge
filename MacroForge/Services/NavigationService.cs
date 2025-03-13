using System.Windows;

namespace MacroForge;

public class NavigationService: INavigationService
{
    public void NavigateTo<T>() where T: Window, new()
    {
        var window = new T();
        window.Show();
    }
}