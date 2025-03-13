using System.Collections.ObjectModel;
using System.Windows;

namespace MacroForge.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ObservableCollection<MacroData> macroData =
        [
            new MacroData("1", "A", []),
            new MacroData("2", "B", []),
            new MacroData("3", "C", []),
            new MacroData("4", "D", []),
            new MacroData("5", "E", []),
            new MacroData("6", "F", []),
            new MacroData("7", "G", []),
            new MacroData("8", "H", []),
            new MacroData("9", "I", []),
            new MacroData("1", "A", []),
            new MacroData("2", "B", []),
            new MacroData("3", "C", []),
            new MacroData("4", "D", []),
            new MacroData("5", "E", []),
            new MacroData("6", "F", []),
            new MacroData("7", "G", []),
            new MacroData("8", "H", []),
            new MacroData("9", "I", []),
        ];

        MacroDataGrid.ItemsSource = macroData;
    }
}