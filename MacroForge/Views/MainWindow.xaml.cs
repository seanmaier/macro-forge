using System.Runtime.InteropServices;
using System.Windows;
using MacroForge.Recorder;
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
        
        // TODO aufrauemen wenn wir weiter sind
        MacroDataList mdl = new MacroDataList();

        FileHandler fileHandler = new FileHandler();
        fileHandler.LoadMacrosFromFiles(mdl);


        MacroDataGrid.ItemsSource = mdl.Macros;

        Input[] inputs = new[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x11,
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x11,
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            },
        };

        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

        // zu testzwecken direktes speichern muss natuerlich weg spaeter
        //fileHandler.SaveMacrosToFiles(mdl);
    }
    
    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, Input[] inputs, int cbSize);
    
    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();
}
