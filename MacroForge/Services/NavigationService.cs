using System.Windows;
using MacroForge.Interfaces;

namespace MacroForge.Services;

public class NavigationService: INavigationService
{
    public void NavigateTo<T>() where T: Window, new()
    {
        var window = new T();

        var mainWindow = Application.Current.MainWindow;

        if (mainWindow != null)
        {
            window.WindowStartupLocation = WindowStartupLocation.Manual;
            window.Left = mainWindow.Left + 30;
            window.Top = mainWindow.Top + 50;
        }
        else
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        
        
        window.Show();
    }
}