using System.Collections.ObjectModel;
using System.Windows;
using MacroForge.Services;
using MacroForge.ViewModels;

namespace MacroForge.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel(new NavigationService());
        
        FileHandler fileHandler = new FileHandler();
        fileHandler.CheckSaveFolder();
        fileHandler.LoadMacrosFromFiles();


        MacroDataGrid.ItemsSource = fileHandler.Macros;
        //MacroDataGrid.ItemsSource = macroData;
    }
}