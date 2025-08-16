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
        _cts = new CancellationTokenSource();
        var macroTesting = new MacroTesting(_cts.Token); 
        
        try
        {
            await macroTesting.NotepadViaRun();
        }
        catch
        {
            MessageBox.Show("Macro was cancelled");
        }
    }
}
