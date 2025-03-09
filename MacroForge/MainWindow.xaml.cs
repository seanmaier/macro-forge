using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MacroForge;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        var converter = new BrushConverter();
        
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
        ];

        MacroDataGrid.ItemsSource = macroData;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }
}