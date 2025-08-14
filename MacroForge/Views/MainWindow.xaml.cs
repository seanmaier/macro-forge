using System.Runtime.InteropServices;
using System.Windows;
using MacroForge.Models;
using MacroForge.Playback;
using MacroForge.Services;
using MacroForge.ViewModels;
using WindowsInput;
using WindowsInput.Native;

namespace MacroForge.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{


    private CancellationTokenSource _cts;
    private MacroDataList _mdl = new ();
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel(new NavigationService());
        
        // TODO aufrauemen wenn wir weiter sind

        FileHandler fileHandler = new FileHandler();
        fileHandler.LoadMacrosFromFiles(_mdl);


        MacroDataGrid.ItemsSource = _mdl.Macros;

        

        // zu testzwecken direktes speichern muss natuerlich weg spaeter
        //fileHandler.SaveMacrosToFiles(mdl);
    }



    private void BtnClick_Cancel(object sender, RoutedEventArgs e)
    {
        _cts.Cancel();
    }

    private async void BtnClick_Test(object sender, RoutedEventArgs e)
    {
        var player = new Player();

        var macroList = new List<MacroStep>([ 
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Press, Key = VirtualKeyCode.LWIN}
            },
            new MacroStep {
                Delay = 500,
            CommandType = CommandType.KeyboardEvent,
            KeyboardAction = new KeyboardAction{EventType = KeyEventType.Press, Key = VirtualKeyCode.VK_N}
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Press, Key = VirtualKeyCode.VK_O}
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Press, Key = VirtualKeyCode.VK_T}
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Press, Key = VirtualKeyCode.VK_E}
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                Delay = 500,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Press, Key = VirtualKeyCode.RETURN}
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                Delay = 500,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Down, Key = VirtualKeyCode.VK_E}
            },
            new MacroStep
            {
                CommandType = CommandType.MouseEvent,
                MouseAction = new MouseAction{EventType = MouseEventType.MoveTo, X = 200, Y = 100}
            },
            new MacroStep
            {
                CommandType = CommandType.KeyboardEvent,
                Delay = 1000,
                KeyboardAction = new KeyboardAction{EventType = KeyEventType.Up, Key = VirtualKeyCode.VK_S}
            },
        ]);

        var macro = new MacroData("TestMacro", macroList);
        _cts = new CancellationTokenSource();
        try
        {
            await player.PlayAsync(macro, _cts.Token);
        }
        catch
        {
            MessageBox.Show("Macro was cancelled");
        }
    }
}
